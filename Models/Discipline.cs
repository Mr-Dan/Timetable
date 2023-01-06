using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Discipline
    {
        public int Id { get; set; } 
        public string? Name { get; set; }

        //public TypeLesson TypeLesson { get; set; }
        public string? TypeLesson { get; set; }
        public TimeSpan volume { get; set; }

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"iddiscipline","Id" },
                {"namediscipline","Название" },
                {"typelesson","Тип занятия" },
                {"volume","Количество часов" },

            };

        public static List<string>? OrderTitle { get; set; }

        public static List<Discipline> GetDisciplines(List<object[]> obj, List<string> title)
        {
            List<Discipline> list = new List<Discipline>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetDiscipline(objects, title));
            }
            return list;
        }
        private static Discipline GetDiscipline(object[] objects, List<string> title)
        {
            Discipline discipline = new Discipline();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "iddiscipline")
                {
                    discipline.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "name")
                {
                    discipline.Name = objects[i].ToString();
                }
                else if (title[i] == "typelesson")
                {
                    discipline.TypeLesson = objects[i].ToString();
                }
                else if (title[i] == "volume")
                {
                    discipline.volume = TimeSpan.Parse(objects[i].ToString());
                }

            }
            OrderTitle = new List<string>(title);
            return discipline;
        }


    }
}
