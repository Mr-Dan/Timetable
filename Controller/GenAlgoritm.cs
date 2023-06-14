using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Timetable.Models;

namespace Timetable.Controller
{
   
    class GenAlgoritm
    {
        public static Dictionary<int, int> GroupLessen;
        public static List<AudienceDayHour> AudienceList;
        public static List<GroupGen> GroupGenBusy;
        public static List<string> TeacherList;
        // 1 = каждый  2 - числитель 3 - знаменатель переодичность

        public TimetablePlan Main(List<GroupGen> groups, List<AudienceDayHour> audienceList, List<GroupGen> groupGenBusy,List<string> teacherList )
        {

           try
            {
            GroupLessen = new Dictionary<int, int>();
            AudienceList = audienceList;
            GroupGenBusy = groupGenBusy;
            TeacherList = teacherList;

            // добавляем предметы не распределенных десциплин
            var list = new List<Lessоn>();
            for (int i = 0; i < groups.Count; i++)
            {
                if (!GroupLessen.ContainsKey(groups[i].Id))
                {
                    GroupLessen.Add(groups[i].Id, 1);
                }
                else { GroupLessen[groups[i].Id]++; }


                list.Add(new Lessоn(groups[i], new AudienceDayHour()));
            }

            // добавляем предметы распределенных десциплин
            for (int i = 0; i < groupGenBusy.Count; i++)
            {
                if (!GroupLessen.ContainsKey(groupGenBusy[i].Id))
                {
                    GroupLessen.Add(groupGenBusy[i].Id, 1);
                }
                else { GroupLessen[groupGenBusy[i].Id]++; }
            }

            var solver = new Gen();

                TimetablePlan.DaysPerWeek = 6;// Дни недели
                TimetablePlan.HoursPerDay = 6; // Время пар

            solver.FitnessFunctions.Add(PenaltyFunctions.Windows);//будем штрафовать за окна
            solver.FitnessFunctions.Add(PenaltyFunctions.OneLesson);//будем штрафовать за одну пару
            solver.FitnessFunctions.Add(PenaltyFunctions.MoreFourLesson);//будем штрафовать за больше 4 пары
            solver.FitnessFunctions.Add(PenaltyFunctions.LessonCount);//большое количество предметов

            var res = solver.Solve(list);//находим лучший план

            return res;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }

    /// Фитнесс функции
    static class PenaltyFunctions
    {
        public static int GroupWindowPenalty = 12;//штраф за окно у группы
        public static int TeacherWindowPenalty = 8;//штраф за окно у преподавателя
        public static int OneLessonPenalty = 40;//штраф одну пару
        public static int MoreFourLessonPenalty = 40;//штраф за 4 пары
        public static int LessonCountPenalty = 400;//штраф за большое колличесвто предметов

        public static int test()
        {
            return 0;
        }


        /// Штраф за окна
        public static Penalty Windows(TimetablePlan planOld)
        {
            Penalty penalty = new Penalty();
            TimetablePlan plan = ComboPlan(planOld);
            for (int day = 0; day < TimetablePlan.DaysPerWeek; day++)
            {
                List<Lessоn> windowsLessоns = new List<Lessоn>();
                for (int hour = 0; hour < TimetablePlan.HoursPerDay; hour++)
                {
                    foreach (Lessоn lessоn in plan.HourTimetablePlan[day, hour].lessоns)
                    {
                        var group = lessоn.Group;
                        var teacher = lessоn.Group.Teacher;
                        var periodicity = lessоn.Group.Periodicity;

                        #region group
                        List<Lessоn> list = windowsLessоns.FindAll(x => x.Group.Id == group.Id);

                        if(list.Count >= 1 && hour != 0)
                        {
                            List<Lessоn> lessоnsOnehour = plan.HourTimetablePlan[day, hour - 1].lessоns.FindAll(x => x.Group.Id == group.Id);
                            if (lessоnsOnehour.Count == 0)
                            {
                                penalty.Value += GroupWindowPenalty;
                                penalty.Error.Add("Окно у группы");
                            }
                            else if (lessоnsOnehour.Count >= 1)
                            {
                                for (int k = hour; k >= 2; k--)
                                {
                                    List<Lessоn> lessоnsTwohour = plan.HourTimetablePlan[day, k - 2].lessоns.FindAll(x => x.Group.Id == group.Id);

                                    if (lessоnsTwohour.Count == 1)
                                    {
                                        // тут проверяем что третий блок равен 1 или первый блок равен третьему
                                        if (lessоnsTwohour[0].Group.Periodicity == 1 || periodicity == lessоnsTwohour[0].Group.Periodicity)
                                        {
                                            lessоnsOnehour = plan.HourTimetablePlan[day, k - 1].lessоns.FindAll(x => x.Group.Id == group.Id);
                                            // проверяем второй блок
                                            if (lessоnsOnehour.Count == 1)
                                            {   // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                {   // тогда сравниваем первый и второй блок
                                                    if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                    {
                                                        penalty.Value += GroupWindowPenalty;
                                                        penalty.Error.Add("Окно у группы");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //если две то пропускаем (числитель/знаменатель)
                                            }
                                        }
                                        else//если третий блок не равен 1 и не равен первому
                                        {
                                            lessоnsOnehour = plan.HourTimetablePlan[day, k - 1].lessоns.FindAll(x => x.Group.Id == group.Id);

                                            if (lessоnsOnehour.Count == 1)
                                            {
                                                // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                { // если второй блок и третий не равен окно
                                                    if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                    {
                                                         k--;
                                                          if (k >= 2)// если есть
                                                          {
                                                              penalty.Value += GroupWindowPenalty;
                                                              penalty.Error.Add("Окно у группы");
                                                          }
                                                       
                                                    }
                                                    // если равен, то проверяем четвертый блок, если он есть
                                                    else
                                                    {
                                                        k--;
                                                        if (k >= 2)// если есть
                                                        {
                                                            lessоnsTwohour = plan.HourTimetablePlan[day, k - 2].lessоns.FindAll(x => x.Group.Id == group.Id);
                                                            if (lessоnsTwohour.Count == 1)
                                                            {
                                                                if (lessоnsTwohour[0].Group.Periodicity != 1)
                                                                {
                                                                    if (lessоnsOnehour[0].Group.Periodicity != lessоnsTwohour[0].Group.Periodicity)
                                                                    {
                                                                        penalty.Value += GroupWindowPenalty;
                                                                        penalty.Error.Add("Окно у группы");
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                               
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //если две то пропускаем (числитель/знаменатель)
                                            }
                                        }
                                    }
                                    else
                                    {
                                       
                                        lessоnsOnehour = plan.HourTimetablePlan[day, k - 1].lessоns.FindAll(x => x.Group.Id == group.Id);
                                        // проверяем второй блок
                                        if (lessоnsOnehour.Count == 1)
                                        {   // если второй блок не равен 1
                                            if (lessоnsOnehour[0].Group.Periodicity != 1)
                                            {   // тогда сравниваем первый и второй блок
                                                if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                {
                                                    penalty.Value += GroupWindowPenalty;
                                                    penalty.Error.Add("Окно у группы");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //если две то пропускаем (числитель/знаменатель)
                                        }
                                    }
                                }
                            }
                            
                        }
                        #endregion


                        #region teacher

                        list = windowsLessоns.FindAll(x => x.Group.Teacher == teacher);

                        if (list.Count >= 1 && hour != 0)
                        {
                            List<Lessоn> lessоnsOnehour = plan.HourTimetablePlan[day, hour - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);
                            if (lessоnsOnehour.Count == 0)
                            {
                                penalty.Value += TeacherWindowPenalty;
                                penalty.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                            }
                            else if (lessоnsOnehour.Count >= 1)
                            {
                                for (int k = hour; k >= 2; k--)
                                {
                                    List<Lessоn> lessоnsTwohour = plan.HourTimetablePlan[day, k - 2].lessоns.FindAll(x => x.Group.Teacher == teacher);

                                    if (lessоnsTwohour.Count == 1)
                                    {
                                        // тут проверяем что третий блок равен 1 или первый блок равен третьему
                                        if (lessоnsTwohour[0].Group.Periodicity == 1 || periodicity == lessоnsTwohour[0].Group.Periodicity)
                                        {
                                            lessоnsOnehour = plan.HourTimetablePlan[day, k - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);
                                            // проверяем второй блок
                                            if (lessоnsOnehour.Count == 1)
                                            {   // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                {   // тогда сравниваем первый и второй блок
                                                    if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                    {
                                                        penalty.Value += TeacherWindowPenalty;
                                                        penalty.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //если две то норм
                                            }
                                        }
                                        else//если третий блок не равен 1 и не равен первому
                                        {
                                            lessоnsOnehour = plan.HourTimetablePlan[day, k - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);

                                            if (lessоnsOnehour.Count == 1)
                                            {
                                                // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                { // если второй блок и третий не равен окно
                                                    if (lessоnsOnehour[0].Group.Periodicity != lessоnsTwohour[0].Group.Periodicity)
                                                    {
                                                        penalty.Value += TeacherWindowPenalty;
                                                        penalty.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                    }
                                                    // если равен, то проверяем четвертый блок, если он есть
                                                    else
                                                    {
                                                        k--;
                                                        if (k >= 2)// если есть
                                                        {
                                                            lessоnsTwohour = plan.HourTimetablePlan[day, k - 2].lessоns.FindAll(x => x.Group.Teacher == teacher);
                                                            if (lessоnsOnehour.Count == 1 && lessоnsTwohour.Count == 1)
                                                            {
                                                                if (lessоnsOnehour[0].Group.Periodicity != lessоnsTwohour[0].Group.Periodicity)
                                                                {
                                                                    penalty.Value += TeacherWindowPenalty;
                                                                    penalty.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                penalty.Value += TeacherWindowPenalty;
                                                                penalty.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //если две то норм
                                            }
                                        }
                                    }
                                    else
                                    {
                                        lessоnsOnehour = plan.HourTimetablePlan[day, k - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);
                                        // проверяем второй блок
                                        if (lessоnsOnehour.Count == 1)
                                        {   // если второй блок не равен 1
                                            if (lessоnsOnehour[0].Group.Periodicity != 1)
                                            {   // тогда сравниваем первый и второй блок
                                                if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                {
                                                    penalty.Value += TeacherWindowPenalty;
                                                    penalty.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //если две то норм
                                        }
                                    }
                                }
                            }

                        }
                        #endregion
                        if (group.Id == -1)
                        windowsLessоns.Add(new Lessоn(new GroupGen() { Id = group.Id }, new AudienceDayHour()));
                        if(GenAlgoritm.TeacherList.FindIndex(x => x == teacher.ToString())>-1)
                        windowsLessоns.Add(new Lessоn(new GroupGen() { Teacher = group.Teacher }, new AudienceDayHour()));
                    }
                }
            }
            DeletePlan(planOld);
            return penalty;
        }

        public static Penalty OneLesson(TimetablePlan planOld)
        {
            Penalty penalty = new Penalty();
            TimetablePlan plan = ComboPlan(planOld);
            for (int day = 0; day < TimetablePlan.DaysPerWeek; day++)
            {
                Dictionary<int, Periodicity> unic = new Dictionary<int, Periodicity>();

                for (int hour = 0; hour < TimetablePlan.HoursPerDay; hour++)
                {
                    foreach (Lessоn pair in plan.HourTimetablePlan[day, hour].lessоns)
                    {
                        if (pair.Group.Id == -1)
                        {
                            if (!unic.ContainsKey(pair.Group.Id))
                            {
                                unic.Add(pair.Group.Id, new Periodicity());
                            }
                            if (pair.Group.Periodicity == 1) unic[pair.Group.Id].k++;
                            else if (pair.Group.Periodicity == 2) unic[pair.Group.Id].ch++;
                            else if (pair.Group.Periodicity == 3) unic[pair.Group.Id].z++;
                        }
                    }
                }

                foreach (var pair in unic)
                {
                    if (pair.Value.k == 1)
                    {
                        if (pair.Value.ch == 0 || pair.Value.z == 0)
                        {
                            penalty.Value += OneLessonPenalty;
                            penalty.Error.Add($"Одна пара у группы {day} {pair} {pair.Value.k} {pair.Value.ch}  {pair.Value.z}");
                        }
                    
                    }
                    else if (pair.Value.k == 0)
                    {
                        if (pair.Value.ch < 2 && pair.Value.ch != 0)
                        {
                            penalty.Value += OneLessonPenalty;
                            penalty.Error.Add($"Одна пара у группы {day} {pair} {pair.Value} {pair.Value.k} {pair.Value.ch}  {pair.Value.z}");
                        }
                        else if (pair.Value.z < 2 && pair.Value.z != 0)
                        {
                            penalty.Value += OneLessonPenalty;
                            penalty.Error.Add($"Одна пара у группы {day} {pair} {pair.Value}  {pair.Value.k} {pair.Value.ch}  {pair.Value.z}");
                        }
                    }
                }
            }
            DeletePlan(planOld);
            return penalty;
        }

        public static Penalty MoreFourLesson(TimetablePlan planOld)
        {
            Penalty penalty = new Penalty();
            TimetablePlan plan = ComboPlan(planOld);
            for (byte day = 0; day < TimetablePlan.DaysPerWeek; day++)
            {
                Dictionary<int, Periodicity> groupUnic = new Dictionary<int, Periodicity>();
                Dictionary<int, Periodicity> teacherUnic = new Dictionary<int, Periodicity>();
                for (byte hour = 0; hour < TimetablePlan.HoursPerDay; hour++)
                {
                    foreach (var pair in plan.HourTimetablePlan[day, hour].lessоns)
                    {
                        if (pair.Group.Id == -1)
                        {
                            if (!groupUnic.ContainsKey(pair.Group.Id))
                            {
                                groupUnic.Add(pair.Group.Id, new Periodicity());
                            }
                            if (pair.Group.Periodicity == 1) groupUnic[pair.Group.Id].k++;
                            else if (pair.Group.Periodicity == 2) groupUnic[pair.Group.Id].ch++;
                            else if (pair.Group.Periodicity == 3) groupUnic[pair.Group.Id].z++;
                        }

                        if (GenAlgoritm.TeacherList.FindIndex(x => x == pair.Group.Teacher.ToString()) > -1)
                        {
                            if (!teacherUnic.ContainsKey(pair.Group.Teacher))
                            {
                                teacherUnic.Add(pair.Group.Teacher, new Periodicity());
                            }
                            if (pair.Group.Periodicity == 1) teacherUnic[pair.Group.Teacher].k++;
                            else if (pair.Group.Periodicity == 2) teacherUnic[pair.Group.Teacher].ch++;
                            else if (pair.Group.Periodicity == 3) teacherUnic[pair.Group.Teacher].z++;
                        }
                    }
                }

                foreach (var pair in groupUnic)
                {
                    if (pair.Value.k + pair.Value.ch > 4 || pair.Value.k + pair.Value.z > 4)
                    {
                        penalty.Value += MoreFourLessonPenalty;
                        penalty.Error.Add("Больше 4 пары у группы");
                    }
                }
                foreach (var pair in teacherUnic)
                {
                    if (pair.Value.k + pair.Value.ch > 4 || pair.Value.k + pair.Value.z > 4)
                    {
                        penalty.Value += MoreFourLessonPenalty;
                        penalty.Error.Add("Больше 4 пар у преподавателя");
                    }
                }
            }
            DeletePlan(planOld);
            return penalty;
        }

        public static Penalty LessonCount(TimetablePlan planOld)
        {
            Penalty penalty = new Penalty();
            TimetablePlan plan = ComboPlan(planOld);
            Dictionary<int, int> unic = new Dictionary<int, int>();

            for (byte day = 0; day < TimetablePlan.DaysPerWeek; day++)
            {
                for (byte hour = 0; hour < TimetablePlan.HoursPerDay; hour++)
                {
                    foreach (var pair in plan.HourTimetablePlan[day, hour].lessоns)
                    {
                        if (pair.Group.Id == -1)
                            if (!unic.ContainsKey(pair.Group.Id))
                            {
                                unic.Add(pair.Group.Id, 1);
                            }
                            else
                            {
                                unic[pair.Group.Id]++;
                            }
                    }
                }
            }

            foreach (var pair in unic)
            {
                if (GenAlgoritm.GroupLessen[pair.Key] < pair.Value)
                {
                    penalty.Value += LessonCountPenalty;
                    penalty.Error.Add("Больше пар");
                }
            }
            DeletePlan(planOld);
            return penalty;
        }

        private static TimetablePlan ComboPlan(TimetablePlan plan)
        {
            for (byte day = 0; day < TimetablePlan.DaysPerWeek; day++)
            {
                for (byte hour = 0; hour < TimetablePlan.HoursPerDay; hour++)
                {
                    List<GroupGen> group = GenAlgoritm.GroupGenBusy.FindAll(x => x.Audience.day == day && x.Audience.hour == hour);
                    for (int i = 0; i < group.Count; i++)
                    {
                       // if(group[i].Id == -1)
                        plan.HourTimetablePlan[day, hour].AddLesson(group[i], group[i].Audience);
                    }
                }
            }
            return plan;
        }
        private static TimetablePlan DeletePlan(TimetablePlan plan)
        {
            for (int day = 0; day < TimetablePlan.DaysPerWeek; day++)
            {
                for (int hour = 0; hour < TimetablePlan.HoursPerDay; hour++)
                {
                    List<GroupGen> group = GenAlgoritm.GroupGenBusy.FindAll(x => x.Audience.day == day && x.Audience.hour == hour);
                    for (int i = 0; i < group.Count; i++)
                    {
                        plan.HourTimetablePlan[day, hour].RemoveLesson(group[i], group[i].Audience);
                    }
                }
            }
            return plan;
        }
    }

    /// Генетический алгоритм
    class Gen
    {
        public static int iter = 100;
        public static int PopulationCount = 400;//должно делиться на 4

        public List<Func<TimetablePlan, Penalty>> FitnessFunctions = new List<Func<TimetablePlan, Penalty>>();

        public Penalty Penalty(TimetablePlan plan)
        {
            Penalty res = new Penalty();

            foreach (var f in FitnessFunctions)
                res += f(plan);

            return res;
        }

        public TimetablePlan Solve(List<Lessоn> lessоn)
        {
            //создаем популяцию
            Population pop = new Population(lessоn, PopulationCount);
            if (pop.Count == 0)
            {
                throw new Exception("Невозможно создать план");
            }

            var count = iter;
            while (count-- > 0)
            {
                pop.ForEach(p => p.PenaltyValue = Penalty(p));
                pop.Sort((p1, p2) => p1.PenaltyValue.Value.CompareTo(p2.PenaltyValue.Value));

                if (pop.Count == 0) throw new Exception("Невозможно создать план");

                if (pop[0].PenaltyValue.Value == 0)
                {
                    return pop[0];
                }

                if (20 % pop.Count != 0)
                {
                    pop.RemoveRange(20 % pop.Count, pop.Count - 20 % pop.Count);
                }
                //от каждого создаем трех потомков с мутациями
                int c = pop.Count;
                for (int i = 0; i < c; i++)
                {
                    pop.AddChildOfParent(pop[i]);
                    pop.AddChildOfParent(pop[i]);
                    pop.AddChildOfParent(pop[i]);
                }
            }

            //считаем штрафные функции для всех планов
            pop.ForEach(p => p.PenaltyValue = Penalty(p));
            //сортруем популяцию по сумме штрафов
            pop.Sort((p1, p2) => p1.PenaltyValue.Value.CompareTo(p2.PenaltyValue.Value));

            //возвращаем лучший план
            return pop[0];
        }
    }

    /// Популяция планов
    class Population : List<TimetablePlan>
    {
        public Population(List<Lessоn> lessоn, int count)
        {
            int i = count * 2;

            do
            {
                TimetablePlan plan = new TimetablePlan();
                if (plan.Init(lessоn))
                {
                    Add(plan);
                }
            }while (i -- > 0 && Count < count);
        }

        public bool AddChildOfParent(TimetablePlan parent)
        {
            int i = 30;

            do
            {
                TimetablePlan plan = new TimetablePlan();
                if (plan.Init(parent))
                {
                    Add(plan);

                    return true;
                }

            } while (i-- > 0);
            return false;
        }
    }

    class Penalty
    {
        public int Value { get; internal set; }
        public List<string> Error { get; internal set; } = new List<string>();

        public static Penalty operator +(Penalty left, Penalty rihgt)
        {
            List<string> strings = new List<string>(left.Error);
            strings.AddRange(rihgt.Error);
            return new Penalty() { Value = left.Value + rihgt.Value, Error = strings };
        }

    }

    /// План занятий
    class TimetablePlan
    {
        public static int DaysPerWeek = 6;//6 учебных дня в неделю
        public static int HoursPerDay = 6;//до 6 пар в день

        /// План по дням (первый индекс) и часам (второй индекс)
        public HourTimetablePlan[,] HourTimetablePlan = new HourTimetablePlan[DaysPerWeek, HoursPerDay];


        public Penalty PenaltyValue { get; set; }

        public bool AddLesson(Lessоn les)
        {
            return HourTimetablePlan[les.Day, les.Hour].AddLesson(les.Group, les.Group.Audience);
        }

        public void RemoveLesson(Lessоn les)
        {
            HourTimetablePlan[les.Day, les.Hour].RemoveLesson(les.Group, les.Group.Audience);
        }

        /// Добавить группу с преподом на любой день и любой час
        public bool AddToAnyDayAndHour(GroupGen group, AudienceDayHour audience)
        {
            int i = 40;
            do
            {
                List<AudienceDayHour> sortType = new List<AudienceDayHour>();
                if (group.Type == "лаб")
                {
                    sortType = GenAlgoritm.AudienceList.FindAll(x => x.TypeAudiens == "лабораторная");
                }
                else
                {
                    sortType = GenAlgoritm.AudienceList.FindAll(x => x.TypeAudiens != "лабораторная" && x.CapacityAudiens >= group.Amount && x.CapacityAudiens - group.Amount - 5 <= group.Amount);
                }

                Random random = new Random();
                int x = random.Next(sortType.Count);
                if (sortType.Count == 0) return false;
                audience = sortType[x];

                int day = random.Next(DaysPerWeek);
                if (AddToAnyHour(day, group, audience))
                {
                    return true;
                }
            } while (i-- > 0);

            return false;
        }

        /// Добавить группу с преподом на любой час
        bool AddToAnyHour(int day, GroupGen group, AudienceDayHour audience)
        {
            Random random = new Random();
            int hour = random.Next(HoursPerDay);
            Lessоn les = new Lessоn(day, hour, group, audience);
            //  тут проверка на занятое время
            if (DayHourAudiensFree(day, hour, audience, group))
            {
                if (AddLesson(les))
                {
                    return true;
                }
            }
            return false;
        }

        bool DayHourAudiensFree(int day, int hour, AudienceDayHour audience, GroupGen group)
        {
            List<GroupGen> find = GenAlgoritm.GroupGenBusy.FindAll(x => x.Audience.day == day && x.Audience.hour == hour && x.Id == group.Id);
            foreach (var item in find)
            {
                if (item.Periodicity == 1) return false;
                if (group.Periodicity == 1) return false;
                if (item.Periodicity == group.Periodicity) return false;
            }

            find = GenAlgoritm.GroupGenBusy.FindAll(x => x.Audience.day == day && x.Audience.hour == hour && x.Audience.Id == audience.Id);

            foreach (var item in find)
            {
                if (item.Audience.periodicity == 1) return false;
                if (group.Periodicity == 1) return false;
                if (item.Audience.periodicity == group.Periodicity) return false;
            }

            return true;
        }


        /// Создание плана по списку пар
        public bool Init(List<Lessоn> lessоns)
        {
            for (int i = 0; i < HoursPerDay; i++)
            {
                for (int j = 0; j < DaysPerWeek; j++)
                {
                    HourTimetablePlan[j, i] = new HourTimetablePlan();
                }
            }

            foreach (Lessоn p in lessоns)
            {
                if (!AddToAnyDayAndHour(p.Group, p.Group.Audience))
                { 
                    return false; 
                }
                   
            }
            return true;
        }

        /// Создание наследника с мутацией
        public bool Init(TimetablePlan parent)
        {
            //копируем предка
            for (int i = 0; i < HoursPerDay; i++)
                for (int j = 0; j < DaysPerWeek; j++)
                    HourTimetablePlan[j, i] = parent.HourTimetablePlan[j, i].Clone();
            
            Random random = new Random();
            //выбираем два случайных дня
            var day1 = (byte)random.Next(DaysPerWeek);
            var day2 = (byte)random.Next(DaysPerWeek);

            //находим пары в эти дни
            var pairs1 = GetLessonsOfDay(day1).ToList();
            var pairs2 = GetLessonsOfDay(day2).ToList();

            //выбираем случайные пары
            if (pairs1.Count == 0 || pairs2.Count == 0) return false;
            var pair1 = pairs1[random.Next(pairs1.Count)];
            var pair2 = pairs2[random.Next(pairs2.Count)];

            //создаем мутацию - переставляем случайные пары местами
            RemoveLesson(pair1);//удаляем
            RemoveLesson(pair2);//удаляем
            var res1 = AddToAnyHour(pair2.Day, pair1.Group, pair1.Group.Audience);//вставляем в случайное место
            var res2 = AddToAnyHour(pair1.Day, pair2.Group, pair2.Group.Audience);//вставляем в случайное место
            return res1 && res2;
        }

        public IEnumerable<Lessоn> GetLessonsOfDay(int day)
        {
            for (byte hour = 0; hour < HoursPerDay; hour++)
                foreach (var p in HourTimetablePlan[day, hour].lessоns)
                    yield return new Lessоn(day, hour, p.Group, p.Group.Audience);
        }

        public IEnumerable<Lessоn> GetLessons()
        {
            for (byte day = 0; day < DaysPerWeek; day++)
                for (byte hour = 0; hour < HoursPerDay; hour++)
                    foreach (var p in HourTimetablePlan[day, hour].lessоns)
                        yield return new Lessоn(day, hour, p.Group, p.Group.Audience);
        }


    }

    /// План на час
    class HourTimetablePlan
    {

        public List<Lessоn> lessоns = new List<Lessоn>();

        public bool AddLesson(GroupGen group, AudienceDayHour audiens)
        {
            int indexTeacher = lessоns.FindIndex(c => c.Group.Teacher == group.Teacher);
            int indexGroup = lessоns.FindIndex(c => c.Group.Id == group.Id);
            int indexAudiens = lessоns.FindIndex(c => c.Group.Audience.Id == audiens.Id);
            if (lessоns.FindAll(c => c.Group.Id == group.Id).Count > 1)
            {
                return false;
            }
            if (lessоns.FindAll(c => c.Group.Teacher == group.Teacher).Count > 1)
            {
                return false;
            }

            if (indexGroup > -1)
            {
                if (lessоns[indexGroup].Group.Periodicity == 1)
                {
                    return false;
                }
                else if (group.Periodicity == 1)
                {
                    return false;
                }
                else if (lessоns[indexGroup].Group.Periodicity == group.Periodicity)
                {
                    return false;
                }
            }

            if (indexTeacher > -1)
            {
                if (lessоns[indexTeacher].Group.Periodicity == 1)
                {
                    return false;
                }
                else if (group.Periodicity == 1)
                {
                    return false;

                }
                else if (lessоns[indexTeacher].Group.Periodicity == group.Periodicity)
                {
                    return false;
                }
            }

            if (indexAudiens > -1)
            {
                return false;
            }

            lessоns.Add(new Lessоn(group, audiens));

            return true;
        }

        public void RemoveLesson(GroupGen group, AudienceDayHour audience)
        {
            int index = lessоns.FindIndex(c => c.Group.Teacher == group.Teacher && c.Group.Id == group.Id && c.Group.Periodicity == group.Periodicity);
            if (index != -1)
                lessоns.RemoveAt(index);
        }

        public HourTimetablePlan Clone()
        {
            var res = new HourTimetablePlan();
            res.lessоns = new List<Lessоn>(lessоns);
            return res;
        }
    }

    /// Пара
    class Lessоn
    {
        public int Day = 255;
        public int Hour = 255;

        // public AudienceDayHour Audience;
        public GroupGen Group;


        public Lessоn(int day, int hour, GroupGen group, AudienceDayHour audiens) : this(group, audiens)
        {
            Day = day;
            Hour = hour;
        }

        public Lessоn(GroupGen group, AudienceDayHour audiens)
        {
            Group = group;
            Group.Audience = audiens;
        }
    }

    class Periodicity
    {
        public int k = 0;  // каждый день
        public int ch = 0;  // числитель
        public int z = 0;  // знаменатель
    }

    class GroupGen
    {
        public int Id;
        public int Teacher;
        public string NameTeacher;
        public int Discipline;
        public string Type;
        public int Periodicity;
        public int Amount;
        public int Idtimetable;
        public AudienceDayHour Audience;
    }

    class AudienceDayHour
    {
        public int Id;
        public string TypeAudiens;
        public string Name;
        public int CapacityAudiens;

        public int day = -1;
        public int hour = -1;
        public int periodicity;
    }


    
}
