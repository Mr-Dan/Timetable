using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Departments
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"iddepartments","Id" },
                {"namedepartments","Название" },
            };
        public static List<string>? OrderTitle { get; set; }

        public static List<Departments> GetDepartments(List<object[]> obj, List<string> title)
        {
            List<Departments> list = new List<Departments>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetDepartment(objects, title));
            }
            return list;
        }
        public static Departments GetDepartment(object[] objects, List<string> title)
        {
            Departments department = new Departments();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "iddepartments")
                {
                    department.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namedepartments")
                {
                    department.Name = objects[i].ToString();
                }
            
            }
            OrderTitle = new List<string>(title);
            return department;
        }
    }
}
