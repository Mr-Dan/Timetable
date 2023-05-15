using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Controller;

namespace Timetable.Models
{
    internal class Discipline
    {
        private int id;
        private string name;
        private string typeLesson;

        private CurriculumDiscipline curriculumDiscipline = new CurriculumDiscipline() ;
        public int Id
        {
            get
            {
                return id; // получаем данные
            }
            set
            {
                if (value < 0)// Если данные не проходят, то выкидываем ошибку
                {
                    throw new Exception("Значение не может быть меньше 0");
                }
                else // Иначе записывем 
                {
                    id = value;
                }
            }
        }
        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    name = value;
                }
            }
        }

        public string? TypeLesson
        {
            get
            {
                return typeLesson;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    typeLesson = value;
                }
            }
        }

        public CurriculumDiscipline CurriculumDiscipline
        {
            get
            {
                return curriculumDiscipline;
            }
            set
            {

                curriculumDiscipline = value;
                
            }
        }
        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"iddiscipline","Id" },
                {"namediscipline","Название" },
                {"typelesson","Тип занятия" },

                {"idcurriculumdiscipline","Id план дисцеплин" },
                {"idcurriculum","Id Учебный план" },
                {"course","Курс" },
                {"semester","Семестр" },
                {"hours","Часы" },
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
        public static Discipline GetDiscipline(object[] objects, List<string> title)
        {
            Discipline discipline = new Discipline();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "iddiscipline")
                {
                    discipline.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namediscipline")
                {
                    discipline.Name = objects[i].ToString();
                }
                else if (title[i] == "typelesson")
                {
                    discipline.TypeLesson = objects[i].ToString();
                }
                else if (title[i] == "idcurriculumdiscipline")
                {
                    discipline.CurriculumDiscipline.Id = ConvertCustom.ConvertToInt(objects[i].ToString()) ;
                }
                else if (title[i] == "idcurriculum")
                {
                    discipline.CurriculumDiscipline.Curriculum.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "course")
                {
                     discipline.CurriculumDiscipline.Course = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "semester")
                {
                    discipline.CurriculumDiscipline.Semester = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "hours")
                {
                    discipline.CurriculumDiscipline.Hours = ConvertCustom.ConvertToInt(objects[i].ToString());
                }


            }
            OrderTitle = new List<string>(title);
            return discipline;
        }

        public string GetDisciplineValue(string title)
        {

            if (title == "iddiscipline")
            {
                return Id.ToString();
            }
            else if (title == "namediscipline")
            {
                return Name;
            }
            else if (title == "typelesson")
            {
                return TypeLesson;
            }
            else if (title == "idcurriculumdiscipline")
            {
                return CurriculumDiscipline.Id.ToString();
            }
            else if (title == "idcurriculum")
            {
                return CurriculumDiscipline.Curriculum.Id.ToString();
            }
            else if (title == "course")
            {
                return CurriculumDiscipline.Course.ToString();
            }
            else if (title == "semester")
            {
                return CurriculumDiscipline.Semester.ToString();
            }
            else if (title == "hours")
            {
                return CurriculumDiscipline.Hours.ToString();
            }
            return null;
        }

        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "iddiscipline")
                {
                    objects[i] = Id;
                }
                else if (title[i] == "namediscipline")
                {
                    objects[i] = Name;
                }
                else if (title[i] == "typelesson")
                {
                    objects[i] =  TypeLesson;
                }
                else if (title[i] == "idcurriculumdiscipline")
                {
                    objects[i] = CurriculumDiscipline.Id;
                }
                else if (title[i] == "idcurriculum")
                {
                    objects[i] = CurriculumDiscipline.Curriculum.Id;
                }
                else if (title[i] == "course")
                {
                    objects[i] = CurriculumDiscipline.Course;
                }
                else if (title[i] == "semester")
                {
                    objects[i] = CurriculumDiscipline.Semester;
                }
                else if (title[i] == "hours")
                {
                    objects[i] = CurriculumDiscipline.Hours;
                }
                
            }
            
            return objects;
        }

    }
}
