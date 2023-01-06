using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Faculty
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Departments Departments { get; set; } = new Departments();
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
    }
}
