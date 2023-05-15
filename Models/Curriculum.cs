using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Timetable.Models
{
    public class Curriculum
    {
        private int id;
        private string name;
        private string qualification;

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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == "" || value == null)
                {
                    //throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    name = value;
                }
            }
        }
        public string Qualification
        {
            get
            {
                return qualification;
            }
            set
            {
                if (value == "" || value == null)
                {
                    //throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    qualification = value;
                }
            }
        }


        public static Dictionary<string, string> Title { get; set; } =
           new Dictionary<string, string>
           {
                { "idcurriculum", "Id" },
                { "namecurriculum", "Название" },
                { "qualification", "Квалификация" },
           };
        public static List<string>? OrderTitle { get; set; }

        public static List<Curriculum> GetCurriculums(List<object[]> obj, List<string> title)
        {
            List<Curriculum> list = new List<Curriculum>();

            for (int i = 0; i < obj.Count; i++) // Передали строку данных и ее обрабатываем
            {
                object[] objects = obj[i];

                list.Add(GetCurriculum(objects, title)); // функция для преобразования объектов в класс
            }
            return list;
        }

        public static Curriculum GetCurriculum(object[] objects, List<string> title)
        {
            Curriculum curriculum = new Curriculum();
            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idcurriculum")
                {
                    curriculum.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namecurriculum")
                {
                    curriculum.Name = objects[i].ToString();
                }
                else if (title[i] == "qualification")
                {
                    curriculum.Qualification = objects[i].ToString();
                }
               
            }
            OrderTitle = new List<string>(title);
            return curriculum;
        }

        public string GetCurriculumValue(string title)
        {
            // Функция для получения данных с помощью имен полей таблицы.
            if (title == "idcurriculum")
            {
                return Id.ToString();
            }
            else if (title == "namecurriculum")
            {
                return Name;
            }
            else if (title == "qualification")
            {
                return Qualification;
            }
            
            return null;
        }

        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idcurriculum")
                {
                    objects[i] = Id.ToString();
                }
                else if (title[i] == "namecurriculum")
                {
                    objects[i] = Name;
                }
                else if (title[i] == "qualification")
                {
                    objects[i] = Qualification;
                }
            }
      
            return objects;
        }

        public static bool operator ==(Curriculum left, Curriculum right)
        {
            return left.Id == right.Id && left.Name == right.Name && left.Qualification == right.Qualification;
        }
        public static bool operator !=(Curriculum left, Curriculum right) => !(left == right);
    }
}
