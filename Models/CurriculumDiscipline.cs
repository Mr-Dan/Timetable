using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Timetable.Controller;

namespace Timetable.Models
{
    internal class CurriculumDiscipline
    {
       
        public int Id;
        public Curriculum Curriculum;
        public Discipline Discipline;
        public int Course;
        public int Semester;
        public int Hours;

        public static Dictionary<string, string> Title { get; set; } =
         new Dictionary<string, string>
         {
                { "idcurriculumdiscipline", "Id" },

                { "idcurriculum", "id учебного плана" },
                { "namecurriculum", "Название" },
                { "qualification", "Квалификация" },

                { "iddiscipline", "id дисциплины" },
                { "namediscipline","Название" },
                { "typelesson","Тип занятия" },

                { "course", "курс" },
                { "semester", "семестр" },
                { "hours", "часы" },
         };
        public static List<string>? OrderTitle { get; set; }


        public static List<CurriculumDiscipline> GetCurriculumsDiscipline(List<object[]> obj, List<string> title)
        {
            List<CurriculumDiscipline> list = new List<CurriculumDiscipline>();

            for (int i = 0; i < obj.Count; i++) // Передали строку данных и ее обрабатываем
            {
                object[] objects = obj[i];

                list.Add(GetCurriculumDiscipline(objects, title)); // функция для преобразования объектов в класс
            }
            return list;
        }

        public static CurriculumDiscipline GetCurriculumDiscipline(object[] objects, List<string> title)
        {
            CurriculumDiscipline curriculum = new CurriculumDiscipline();
            curriculum.Curriculum = new Curriculum();
            curriculum.Discipline = new Discipline();
            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idcurriculumdiscipline")
                {
                    curriculum.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "idcurriculum")
                {
                    curriculum.Curriculum.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "namecurriculum")
                {
                    curriculum.Curriculum.Name = objects[i].ToString();
                }
                else if (title[i] == "qualification")
                {
                    curriculum.Curriculum.Qualification = objects[i].ToString();
                }
                else if (title[i] == "iddiscipline")
                {
                    curriculum.Discipline.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "namediscipline")
                {
                    curriculum.Discipline.Name = objects[i].ToString();
                }
                else if (title[i] == "typelesson")
                {
                    curriculum.Discipline.TypeLesson = objects[i].ToString();
                }
                else if (title[i] == "course")
                {
                    curriculum.Course = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "semester")
                {
                    curriculum.Semester = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "hours")
                {
                    curriculum.Hours = ConvertCustom.ConvertToInt(objects[i].ToString());
                }

            }
            OrderTitle = new List<string>(title);
            return curriculum;
        }

        public string GetCurriculumDisciplineValue(string title)
        {
            // Функция для получения данных с помощью имен полей таблицы.
            if (title == "idcurriculumdiscipline")
            {
                return Id.ToString();
            }
            else if (title == "idcurriculum")
            {
                return Curriculum.Id.ToString();
            }
            else if (title == "namecurriculum")
            {
                return Curriculum.Name;
            }
            else if (title == "qualification")
            {
                return Curriculum.Qualification;
            }
            else if (title == "iddiscipline")
            {
                return Discipline.Id.ToString();
            }
            else if (title == "namediscipline")
            {
                return Discipline.Name;
            }
            else if (title == "typelesson")
            {
                return Discipline.TypeLesson;
            }
            else if (title == "course")
            {
                return Course.ToString();
            }
            else if (title == "semester")
            {
                return Semester.ToString();
            }
            else if (title == "hours")
            {
                return Hours.ToString();
            }

            return null;
        }

        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idcurriculumdiscipline")
                {
                    objects[i] = Id.ToString();
                }
                else if (title[i] == "idcurriculum")
                {
                    objects[i] = Curriculum.Id.ToString();
                }
                else if (title[i] == "namecurriculum")
                {
                    objects[i] = Curriculum.Name;
                }
                else if (title[i] == "qualification")
                {
                    objects[i] = Curriculum.Qualification;
                }
                else if (title[i] == "iddiscipline")
                {
                    objects[i] = Discipline.Id.ToString();
                }
                else if (title[i] == "namediscipline")
                {
                    objects[i] = Discipline.Name;
                }
                else if (title[i] == "typelesson")
                {
                    objects[i] = Discipline.TypeLesson;
                }
                else if (title[i] == "course")
                {
                    objects[i] = Course.ToString();
                }
                else if (title[i] == "semester")
                {
                    objects[i] = Semester.ToString();
                }
                else if (title[i] == "hours")
                {
                    objects[i] = Hours.ToString();
                }
            }

            return objects;
        }

        public static bool operator ==(CurriculumDiscipline left, CurriculumDiscipline right)
        {
            return left.Id == right.Id && left.Curriculum == right.Curriculum && left.Discipline == right.Discipline && left.Course == right.Course && left.Semester == right.Semester && left.Hours == right.Hours;
        }
        public static bool operator !=(CurriculumDiscipline left, CurriculumDiscipline right) => !(left == right);
    }

}
