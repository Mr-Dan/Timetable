using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    public class Faculty
    {
        private int id;
        private string name;
        private Departments departments = new Departments();
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
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    name = value;
                }
            }
        }

        public Departments Departments
        {
            get
            {
                return departments; // получаем данные
            }
            set
            {
                departments = value;
            }
        }
        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"idfaculty","Id" },
                {"namefaculty","Название факультета" },
                {"iddepartments","Id кафедры"},
                {"namedepartments","Название кафедры" }
            };
        public static List<string>? OrderTitle { get; set; }

        public static List<Faculty> GetFaculties(List<object[]> obj, List<string> title)
        {
            List<Faculty> list = new List<Faculty>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetFaculty(objects, title));
            }
            return list;
        }
        public static Faculty GetFaculty(object[] objects, List<string> title)
        {
            Faculty faculty = new Faculty();
            //faculty.departments = new Departments();
            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idfaculty")
                {
                    faculty.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namefaculty")
                {
                    faculty.Name = objects[i].ToString();
                }
                else if (title[i] == "iddepartments")
                {
                    faculty.Departments.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namedepartments")
                {
                    faculty.Departments.Name = objects[i].ToString();
                }

            }
            OrderTitle = new List<string>(title);
            return faculty;
        }

        public string GetFacultyValue(string title)
        {

            if (title == "idfaculty")
            {
                return Id.ToString();
            }
            else if (title == "namefaculty")
            {
                return Name;
            }
            else if (title == "iddepartments")
            {
                return Departments.Id.ToString();
            }
            else if (title == "namedepartments")
            {
                return Departments.Name;
            }

            return null;
        }
        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idfaculty")
                {
                    objects[i] = Id;
                }
                else if (title[i] == "namefaculty")
                {
                    objects[i] = Name;
                }
                else if (title[i] == "iddepartments")
                {
                    objects[i] = Departments.Id;
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Departments.Name;
                }

            }
            return objects;
        }
    }
}
