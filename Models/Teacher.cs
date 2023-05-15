using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Teacher
    {
        private int id;
        private Departments departments;
        private string lastName;
        private string name;
        private string patronymic;
        private string position;
        private string academicDegree;

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
        public Departments Departments { get; set; } = new Departments();
        public string? LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    lastName = value;
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
        public string? Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    patronymic = value;
                }
            }
        }
        public string? Position
        {
            get
            {
                return position;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    position = value;
                }
            }
        }
        public string? AcademicDegree
        {
            get
            {
                return academicDegree;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    academicDegree = value;
                }
            }
        }


        public static List<string>? OrderTitle { get; set; }

        public static Dictionary<string, string> Title { get; set; } =
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


        public string GetTeacherValue(string title)
        {

            if (title == "idteacher")
            {
                return Id.ToString();
            }
            else if (title == "iddepartments")
            {
                return Departments.Id.ToString();
            }
            else if (title == "namedepartments")
            {
                return Departments.Name;
            }
            else if (title == "lastname")
            {
                return LastName;
            }
            else if (title == "nameteacher")
            {
                return Name;
            }
            else if (title == "patronymic")
            {
                return Patronymic;
            }
            else if (title == "position")
            {
                return Position;
            }
            else if (title == "academicdegree")
            {
                return AcademicDegree;
            }
            return null;


        }
        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idteacher")
                {
                    objects[i] = Id;
                }
                else if (title[i] == "iddepartments")
                {
                    objects[i] = Departments.Id;
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Departments.Name;
                }
                else if (title[i] == "lastname")
                {
                    objects[i] = LastName;
                }
                else if (title[i] == "nameteacher")
                {
                    objects[i] = Name;
                }
                else if (title[i] == "patronymic")
                {
                    objects[i] = Patronymic;
                }
                else if (title[i] == "position")
                {
                    objects[i] = Position;
                }
                else if (title[i] == "academicdegree")
                {
                    objects[i] = AcademicDegree;
                }

            }

            return objects;
        }


        public static bool operator ==(Teacher left, Teacher right)
        {
            return left.Id == right.Id && left.departments == right.departments && left.lastName == right.lastName && left.name == right.name && left.patronymic == right.patronymic && left.position == right.position && left.academicDegree == right.academicDegree;
        }
        public static bool operator !=(Teacher left, Teacher right) => !(left == right);
    }
}
