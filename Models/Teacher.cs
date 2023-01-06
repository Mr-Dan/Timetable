using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Teacher
    {
        public int Id { get; set; }
        public Departments Departments { get; set; } = new Departments(); 
        public string? LastName { get; set; }

        public string? FirstName { get; set; }
        public string? Name { get; set; }


        public string? Patronymic { get; set; }

        public string? Position { get; set; }
        public string? AcademicDegree { get; set; }

        public static List<string>? OrderTitle { get; set; }

        public static Dictionary<string,string> Title { get; set; } =
        new Dictionary<string, string>()
            {
                {"idteacher","Id" },
                {"iddepartments","Id Кафедры" },
                {"lastname","Фамилия" },
                {"nameteacher","Имя" },
                {"patronymic","Отчество" },
                {"position","Должность" },
                {"academicdegree","Учетная степень" },
                {"namedepartments","Название" },
            };

        public static List<Teacher> GetTeachers(List<object[]> obj, List<string> title)
        {
            List<Teacher> list = new List<Teacher>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetTeacher(objects, title));
            }
            return list;
        }
        public static Teacher GetTeacher(object[] objects, List<string> title)
        {
            Teacher teacher = new Teacher();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idteacher")
                {
                    teacher.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "iddepartments")
                {
                    teacher.Departments.Id = Convert.ToInt32(objects[i].ToString());
                }
                else if (title[i] == "namedepartments")
                {
                    teacher.Departments.Name = objects[i].ToString();
                }
                else if (title[i] == "lastname")
                {
                    teacher.LastName = objects[i].ToString();
                }
                else if (title[i] == "nameteacher")
                {
                    teacher.Name = objects[i].ToString();
                }
                else if (title[i] == "patronymic")
                {
                    teacher.Patronymic = objects[i].ToString();
                }
                else if (title[i] == "position")
                {
                    teacher.Position = objects[i].ToString();
                }
                else if (title[i] == "academicdegree")
                {
                    teacher.AcademicDegree = objects[i].ToString();
                }

            }
            OrderTitle = new List<string>(title);
            return teacher;
        }

    }
}
