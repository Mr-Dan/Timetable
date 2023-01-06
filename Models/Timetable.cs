using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Timetable
    {
        public int Id { get; set; }
        public TypeLesson TypeLesson { get; set; } = new TypeLesson();
        public TimeSpan ClassTime { get; set; }

        public Audience Audience { get; set; } = new Audience();

        public Teacher Teacher { get; set; } = new Teacher();

        public Discipline Discipline { get; set; } = new Discipline();

        public Group Group { get; set; } = new Group();

        public string WeekDay { get; set; }
        public string Periodicity { get; set; }

        public static List<string>? OrderTitle { get; set; }

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"namegroup","Название группы/потка" },

                {"lastname","Фамилия" },
                {"nameteacher","Имя" },
                {"patronymic","Отчество" },
                {"position","Должность" },
                {"academicdegree","Учетная степень" },

                {"namediscipline","Название дисциплины" },
                {"typelesson","Тип занятия" },

                {"weekday","День недели"},
                {"classtime","Время пары"},
                {"periodicity","Периодичность"},

                { "nameaudience", "Название аудитории" },

            };

        public static List<Timetable> GetTimetables(List<object[]> obj, List<string> title)
        {
            List<Timetable> list = new List<Timetable>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetTimetable(objects, title));
            }
            return list;
        }
        public static Timetable GetTimetable(object[] objects, List<string> title)
        {
            Timetable timetable = new Timetable();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "namegroup")
                {
                    timetable.Group.Name = objects[i].ToString();
                }
                else if (title[i] == "lastname")
                {
                    timetable.Teacher.LastName = objects[i].ToString();
                }
                else if (title[i] == "nameteacher")
                {
                    timetable.Teacher.Name = objects[i].ToString();
                }
                else if (title[i] == "patronymic")
                {
                    timetable.Teacher.Patronymic = objects[i].ToString();
                }
                else if (title[i] == "position")
                {
                    timetable.Teacher.Position = objects[i].ToString();
                }
                else if (title[i] == "academicdegree")
                {
                    timetable.Teacher.AcademicDegree = objects[i].ToString();
                }
                else if (title[i] == "namediscipline")
                {
                    timetable.Discipline.Name = objects[i].ToString();
                }
                else if (title[i] == "typelesson")
                {
                    timetable.Discipline.TypeLesson =objects[i].ToString();
                }
                else if (title[i] == "weekday")
                {
                    timetable.WeekDay =objects[i].ToString();
                }
                else if (title[i] == "classtime")
                {
                    timetable.ClassTime = TimeSpan.Parse(objects[i].ToString());
                }
                else if (title[i] == "periodicity")
                {
                    timetable.Periodicity =objects[i].ToString();
                }
                else if (title[i] == "nameaudience")
                {
                    timetable.Audience.Name = objects[i].ToString();
                }
              

            }
            OrderTitle = new List<string>(title);
            return timetable;
        }

    }
}
