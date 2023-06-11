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

        public Plan Main(List<GroupGen> groups, List<AudienceDayHour> audienceList, List<GroupGen> groupGenBusy,List<string> teacherList )
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

            Plan.DaysPerWeek = 6;// Дни недели
            Plan.HoursPerDay = 6; // Время пар

            solver.FitnessFunctions.Add(FitnessFunctions.Windows);//будем штрафовать за окна
            solver.FitnessFunctions.Add(FitnessFunctions.OneLesson);//будем штрафовать за одну пару
            solver.FitnessFunctions.Add(FitnessFunctions.MoreFourLesson);//будем штрафовать за больше 4 пары
            solver.FitnessFunctions.Add(FitnessFunctions.LessonCount);//большое количество предметов

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
    static class FitnessFunctions
    {
        public static int GroupWindowPenalty = 10;//штраф за окно у группы
        public static int TeacherWindowPenalty = 7;//штраф за окно у преподавателя
        public static int OneLessonPenalty = 40;//штраф одну пару
        public static int MoreFourLessonPenalty = 40;//штраф за 4 пары
        public static int LessonCountPenalty = 400;//штраф за большое колличесвто предметов

        public static int test()
        {
            return 0;
        }


        /// Штраф за окна
        public static Fitness Windows(Plan planOld)
        {
            Fitness fitness = new Fitness();
            Plan plan = ComboPlan(planOld);
            for (int day = 0; day < Plan.DaysPerWeek; day++)
            {
                List<Lessоn> windowsLessоns = new List<Lessоn>();
                for (int hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    foreach (Lessоn lessоn in plan.HourPlans[day, hour].lessоns)
                    {
                        var group = lessоn.Group;
                        var teacher = lessоn.Group.Teacher;
                        var periodicity = lessоn.Group.Periodicity;

                        #region group
                        List<Lessоn> list = windowsLessоns.FindAll(x => x.Group.Id == group.Id);

                        if(list.Count >= 1 && hour != 0)
                        {
                            List<Lessоn> lessоnsOnehour = plan.HourPlans[day, hour - 1].lessоns.FindAll(x => x.Group.Id == group.Id);
                            if (lessоnsOnehour.Count == 0)
                            {
                                fitness.Value += GroupWindowPenalty;
                                fitness.Error.Add("Окно у группы");
                            }
                            else if (lessоnsOnehour.Count >= 1)
                            {
                                for (int k = hour; k >= 2; k--)
                                {
                                    List<Lessоn> lessоnsTwohour = plan.HourPlans[day, k - 2].lessоns.FindAll(x => x.Group.Id == group.Id);

                                    if (lessоnsTwohour.Count == 1)
                                    {
                                        // тут проверяем что третий блок равен 1 или первый блок равен третьему
                                        if (lessоnsTwohour[0].Group.Periodicity == 1 || periodicity == lessоnsTwohour[0].Group.Periodicity)
                                        {
                                            lessоnsOnehour = plan.HourPlans[day, k - 1].lessоns.FindAll(x => x.Group.Id == group.Id);
                                            // проверяем второй блок
                                            if (lessоnsOnehour.Count == 1)
                                            {   // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                {   // тогда сравниваем первый и второй блок
                                                    if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                    {
                                                        fitness.Value += GroupWindowPenalty;
                                                        fitness.Error.Add("Окно у группы");
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
                                            lessоnsOnehour = plan.HourPlans[day, k - 1].lessоns.FindAll(x => x.Group.Id == group.Id);

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
                                                              fitness.Value += GroupWindowPenalty;
                                                              fitness.Error.Add("Окно у группы");
                                                          }
                                                       
                                                    }
                                                    // если равен, то проверяем четвертый блок, если он есть
                                                    else
                                                    {
                                                        k--;
                                                        if (k >= 2)// если есть
                                                        {
                                                            lessоnsTwohour = plan.HourPlans[day, k - 2].lessоns.FindAll(x => x.Group.Id == group.Id);
                                                            if (lessоnsTwohour.Count == 1)
                                                            {
                                                                if (lessоnsTwohour[0].Group.Periodicity != 1)
                                                                {
                                                                    if (lessоnsOnehour[0].Group.Periodicity != lessоnsTwohour[0].Group.Periodicity)
                                                                    {
                                                                        fitness.Value += GroupWindowPenalty;
                                                                        fitness.Error.Add("Окно у группы");
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
                                       
                                        lessоnsOnehour = plan.HourPlans[day, k - 1].lessоns.FindAll(x => x.Group.Id == group.Id);
                                        // проверяем второй блок
                                        if (lessоnsOnehour.Count == 1)
                                        {   // если второй блок не равен 1
                                            if (lessоnsOnehour[0].Group.Periodicity != 1)
                                            {   // тогда сравниваем первый и второй блок
                                                if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                {
                                                    fitness.Value += GroupWindowPenalty;
                                                    fitness.Error.Add("Окно у группы");
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
                            List<Lessоn> lessоnsOnehour = plan.HourPlans[day, hour - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);
                            if (lessоnsOnehour.Count == 0)
                            {
                                fitness.Value += TeacherWindowPenalty;
                                fitness.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                            }
                            else if (lessоnsOnehour.Count >= 1)
                            {
                                for (int k = hour; k >= 2; k--)
                                {
                                    List<Lessоn> lessоnsTwohour = plan.HourPlans[day, k - 2].lessоns.FindAll(x => x.Group.Teacher == teacher);

                                    if (lessоnsTwohour.Count == 1)
                                    {
                                        // тут проверяем что третий блок равен 1 или первый блок равен третьему
                                        if (lessоnsTwohour[0].Group.Periodicity == 1 || periodicity == lessоnsTwohour[0].Group.Periodicity)
                                        {
                                            lessоnsOnehour = plan.HourPlans[day, k - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);
                                            // проверяем второй блок
                                            if (lessоnsOnehour.Count == 1)
                                            {   // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                {   // тогда сравниваем первый и второй блок
                                                    if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                    {
                                                        fitness.Value += TeacherWindowPenalty;
                                                        fitness.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
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
                                            lessоnsOnehour = plan.HourPlans[day, k - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);

                                            if (lessоnsOnehour.Count == 1)
                                            {
                                                // если второй блок не равен 1
                                                if (lessоnsOnehour[0].Group.Periodicity != 1)
                                                { // если второй блок и третий не равен окно
                                                    if (lessоnsOnehour[0].Group.Periodicity != lessоnsTwohour[0].Group.Periodicity)
                                                    {
                                                        fitness.Value += TeacherWindowPenalty;
                                                        fitness.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                    }
                                                    // если равен, то проверяем четвертый блок, если он есть
                                                    else
                                                    {
                                                        k--;
                                                        if (k >= 2)// если есть
                                                        {
                                                            lessоnsTwohour = plan.HourPlans[day, k - 2].lessоns.FindAll(x => x.Group.Teacher == teacher);
                                                            if (lessоnsOnehour.Count == 1 && lessоnsTwohour.Count == 1)
                                                            {
                                                                if (lessоnsOnehour[0].Group.Periodicity != lessоnsTwohour[0].Group.Periodicity)
                                                                {
                                                                    fitness.Value += TeacherWindowPenalty;
                                                                    fitness.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                fitness.Value += TeacherWindowPenalty;
                                                                fitness.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
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
                                        lessоnsOnehour = plan.HourPlans[day, k - 1].lessоns.FindAll(x => x.Group.Teacher == teacher);
                                        // проверяем второй блок
                                        if (lessоnsOnehour.Count == 1)
                                        {   // если второй блок не равен 1
                                            if (lessоnsOnehour[0].Group.Periodicity != 1)
                                            {   // тогда сравниваем первый и второй блок
                                                if (lessоnsOnehour[0].Group.Periodicity != periodicity)
                                                {
                                                    fitness.Value += TeacherWindowPenalty;
                                                    fitness.Error.Add($"Окно у преподователя {group.Teacher} у группы в день {day} в час {hour}");
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
            return fitness;
        }

        public static Fitness OneLesson(Plan planOld)
        {
            Fitness fitness = new Fitness();
            Plan plan = ComboPlan(planOld);
            for (byte day = 0; day < Plan.DaysPerWeek; day++)
            {
                Dictionary<int, Periodicity> unic = new Dictionary<int, Periodicity>();

                for (byte hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    foreach (var pair in plan.HourPlans[day, hour].lessоns)
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
                            fitness.Value += OneLessonPenalty;
                            fitness.Error.Add($"Одна пара у группы {day} {pair} {pair.Value.k} {pair.Value.ch}  {pair.Value.z}");
                        }
                    
                    }
                    else if (pair.Value.k == 0)
                    {
                        if (pair.Value.ch < 2 && pair.Value.ch != 0)
                        {
                            fitness.Value += OneLessonPenalty;
                            fitness.Error.Add($"Одна пара у группы {day} {pair} {pair.Value} {pair.Value.k} {pair.Value.ch}  {pair.Value.z}");
                        }
                        else if (pair.Value.z < 2 && pair.Value.z != 0)
                        {
                            fitness.Value += OneLessonPenalty;
                            fitness.Error.Add($"Одна пара у группы {day} {pair} {pair.Value}  {pair.Value.k} {pair.Value.ch}  {pair.Value.z}");
                        }
                    }
                }
            }
            DeletePlan(planOld);
            return fitness;
        }

        public static Fitness MoreFourLesson(Plan planOld)
        {
            Fitness fitness = new Fitness();
            Plan plan = ComboPlan(planOld);
            for (byte day = 0; day < Plan.DaysPerWeek; day++)
            {
                Dictionary<int, Periodicity> groupUnic = new Dictionary<int, Periodicity>();
                Dictionary<int, Periodicity> teacherUnic = new Dictionary<int, Periodicity>();
                for (byte hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    foreach (var pair in plan.HourPlans[day, hour].lessоns)
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
                        fitness.Value += MoreFourLessonPenalty;
                        fitness.Error.Add("Больше 4 пары у группы");
                    }
                }
                foreach (var pair in teacherUnic)
                {
                    if (pair.Value.k + pair.Value.ch > 4 || pair.Value.k + pair.Value.z > 4)
                    {
                        fitness.Value += MoreFourLessonPenalty;
                        fitness.Error.Add("Больше 4 пар у преподавателя");
                    }
                }
            }
            DeletePlan(planOld);
            return fitness;
        }

        public static Fitness LessonCount(Plan planOld)
        {
            Fitness fitness = new Fitness();
            Plan plan = ComboPlan(planOld);
            Dictionary<int, int> unic = new Dictionary<int, int>();

            for (byte day = 0; day < Plan.DaysPerWeek; day++)
            {
                for (byte hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    foreach (var pair in plan.HourPlans[day, hour].lessоns)
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
                    fitness.Value += LessonCountPenalty;
                    fitness.Error.Add("Больше пар");
                }
            }
            DeletePlan(planOld);
            return fitness;
        }

        private static Plan ComboPlan(Plan plan)
        {
            for (byte day = 0; day < Plan.DaysPerWeek; day++)
            {
                for (byte hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    List<GroupGen> group = GenAlgoritm.GroupGenBusy.FindAll(x => x.Audience.day == day && x.Audience.hour == hour);
                    for (int i = 0; i < group.Count; i++)
                    {
                       // if(group[i].Id == -1)
                        plan.HourPlans[day, hour].AddLesson(group[i], group[i].Audience);
                    }
                }
            }
            return plan;
        }
        private static Plan DeletePlan(Plan plan)
        {
            for (byte day = 0; day < Plan.DaysPerWeek; day++)
            {
                for (byte hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    List<GroupGen> group = GenAlgoritm.GroupGenBusy.FindAll(x => x.Audience.day == day && x.Audience.hour == hour);
                    for (int i = 0; i < group.Count; i++)
                    {
                        plan.HourPlans[day, hour].RemoveLesson(group[i], group[i].Audience);
                    }
                }
            }
            return plan;
        }
    }

    /// Генетический алгоритм
    class Gen
    {
        public static int MaxIterations = 100;
        public static int PopulationCount = 400;//должно делиться на 4

        public List<Func<Plan, Fitness>> FitnessFunctions = new List<Func<Plan, Fitness>>();

        public Fitness Fitness(Plan plan)
        {
            Fitness res = new Fitness();

            foreach (var f in FitnessFunctions)
                res += f(plan);

            return res;
        }

        public Plan Solve(List<Lessоn> lessоn)
        {
            //создаем популяцию
            Population pop = new Population(lessоn, PopulationCount);
            if (pop.Count == 0)
                throw new Exception("Невозможно создать план");

            var count = MaxIterations;
            while (count-- > 0)
            {
                //считаем штрафные функции для всех планов
                pop.ForEach(p => p.FitnessValue = Fitness(p));
                //сортруем популяцию по штрафам
                pop.Sort((p1, p2) => p1.FitnessValue.Value.CompareTo(p2.FitnessValue.Value));

                if (pop.Count == 0) throw new Exception("Невозможно создать план");

                if (pop[0].FitnessValue.Value == 0)
                {
                    return pop[0];
                }

                //отбираем 25% лучших планов
                if (25 % pop.Count != 0)
                    pop.RemoveRange(25 % pop.Count, pop.Count - 25 % pop.Count);
                //от каждого создаем трех потомков с мутациями
                var c = pop.Count;
                for (int i = 0; i < c; i++)
                {
                    pop.AddChildOfParent(pop[i]);
                    pop.AddChildOfParent(pop[i]);
                    pop.AddChildOfParent(pop[i]);
                }
            }

            //считаем штрафные функции для всех планов
            pop.ForEach(p => p.FitnessValue = Fitness(p));
            //сортруем популяцию по сумме штрафов
            pop.Sort((p1, p2) => p1.FitnessValue.Value.CompareTo(p2.FitnessValue.Value));

            //возвращаем лучший план
            return pop[0];
        }
    }

    /// Популяция планов
    class Population : List<Plan>
    {
        public Population(List<Lessоn> lessоn, int count)
        {
            var maxIterations = count * 2;

            do
            {
                var plan = new Plan();
                if (plan.Init(lessоn))
                    Add(plan);
            } while (maxIterations-- > 0 && Count < count);
        }

        public bool AddChildOfParent(Plan parent)
        {
            int maxIterations = 30;

            do
            {
                var plan = new Plan();
                if (plan.Init(parent))
                {
                    Add(plan);

                    return true;
                }

            } while (maxIterations-- > 0);
            return false;
        }
    }

    class Fitness
    {
        public int Value { get; internal set; }
        public List<string> Error { get; internal set; } = new List<string>();

        public static Fitness operator +(Fitness left, Fitness rihgt)
        {
            List<string> strings = new List<string>(left.Error);
            strings.AddRange(rihgt.Error);
            return new Fitness() { Value = left.Value + rihgt.Value, Error = strings };
        }

    }

    /// План занятий
    class Plan
    {
        public static int DaysPerWeek = 6;//6 учебных дня в неделю
        public static int HoursPerDay = 6;//до 6 пар в день

        static Random rnd = new Random();

        /// План по дням (первый индекс) и часам (второй индекс)
        public HourPlan[,] HourPlans = new HourPlan[DaysPerWeek, HoursPerDay];


        public Fitness FitnessValue { get; set; }

        public bool AddLesson(Lessоn les)
        {
            return HourPlans[les.Day, les.Hour].AddLesson(les.Group, les.Group.Audience);
        }

        public void RemoveLesson(Lessоn les)
        {
            HourPlans[les.Day, les.Hour].RemoveLesson(les.Group, les.Group.Audience);
        }

        /// Добавить группу с преподом на любой день и любой час
        public bool AddToAnyDayAndHour(GroupGen group, AudienceDayHour audience)
        {
            int maxIterations = 40;
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

                Random test = new Random();
                int x = test.Next(sortType.Count);
                if (sortType.Count == 0) return false;
                audience = sortType[x];

                int day = rnd.Next(DaysPerWeek);
                if (AddToAnyHour(day, group, audience))
                    return true;
            } while (maxIterations-- > 0);

            return false;//не смогли добавить никуда
        }

        /// Добавить группу с преподом на любой час
        bool AddToAnyHour(int day, GroupGen group, AudienceDayHour audience)
        {

            int hour = rnd.Next(HoursPerDay);
            Lessоn les = new Lessоn(day, hour, group, audience);
            //  тут проверка на занятое время
            if (DayHourAudiensFree(day, hour, audience, group))
                if (AddLesson(les))
                    return true;

            return false;//нет свободных часов в этот день
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
                for (int j = 0; j < DaysPerWeek; j++)
                    HourPlans[j, i] = new HourPlan();

            foreach (var p in lessоns)
            {

                if (!AddToAnyDayAndHour(p.Group, p.Group.Audience))
                    return false;
            }
            return true;
        }

        /// Создание наследника с мутацией
        public bool Init(Plan parent)
        {
            //копируем предка
            for (int i = 0; i < HoursPerDay; i++)
                for (int j = 0; j < DaysPerWeek; j++)
                    HourPlans[j, i] = parent.HourPlans[j, i].Clone();

            //выбираем два случайных дня
            var day1 = (byte)rnd.Next(DaysPerWeek);
            var day2 = (byte)rnd.Next(DaysPerWeek);

            //находим пары в эти дни
            var pairs1 = GetLessonsOfDay(day1).ToList();
            var pairs2 = GetLessonsOfDay(day2).ToList();

            //выбираем случайные пары
            if (pairs1.Count == 0 || pairs2.Count == 0) return false;
            var pair1 = pairs1[rnd.Next(pairs1.Count)];
            var pair2 = pairs2[rnd.Next(pairs2.Count)];

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
                foreach (var p in HourPlans[day, hour].lessоns)
                    yield return new Lessоn(day, hour, p.Group, p.Group.Audience);
        }

        public IEnumerable<Lessоn> GetLessons()
        {
            for (byte day = 0; day < DaysPerWeek; day++)
                for (byte hour = 0; hour < HoursPerDay; hour++)
                    foreach (var p in HourPlans[day, hour].lessоns)
                        yield return new Lessоn(day, hour, p.Group, p.Group.Audience);
        }


    }

    /// План на час
    class HourPlan
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

        public HourPlan Clone()
        {
            var res = new HourPlan();
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
