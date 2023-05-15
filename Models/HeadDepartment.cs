using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Timetable.Controller;

namespace Timetable.Models
{
    internal class HeadDepartment
    {
        private int id;
        private Departments departments;
        private Teacher teacher;
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
        public Departments Department
        {
            get
            {
                return departments; // получаем данные
            }
            set
            {
               // if (value.Id < 0)// Если данные не проходят, то выкидываем ошибку
               // {
                    //throw new Exception("Значение не может быть меньше 0");
              //  }
               // else // Иначе записывем 
                //{
                    departments = value;
               // }
            }
        }
        public Teacher Teacher
        {
            get
            {
                return teacher; // получаем данные
            }
            set
            {
             //   if (value.Id < 0)// Если данные не проходят, то выкидываем ошибку
              //  {
                //    throw new Exception("Значение не может быть меньше 0");
              //  }
              //  else // Иначе записывем 
               // {
                    teacher = value;
               // }
            }
        }

        public static Dictionary<string, string> Title { get; set; } =
           new Dictionary<string, string>()
           {
                {"idheaddepartment","Id" },

                {"iddepartments","Id кафедры" },
                {"namedepartments","Название" },

                { "idaudience", "Id аудитории" },
                { "nameaudience", "Название" },
                { "address", "Адрес" },
                { "typeaudience", "Тип" },
                { "capacity", "Вместительность" },
                { "traveltime", "Время в пути к аудитории" },

                {"idteacher","Id Зав. кафедры" },
                {"lastname","Фамилия" },
                {"nameteacher","Имя" },
                {"patronymic","Отчество" },
                {"position","Должность" },
                {"academicdegree","Учетная степень" },
           };
        public static List<string>? OrderTitle { get; set; }

        public static List<HeadDepartment> GetHeadDepartments(List<object[]> obj, List<string> title)
        {
            List<HeadDepartment> list = new List<HeadDepartment>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetHeadDepartment(objects, title));
            }
            return list;
        }
        public static HeadDepartment GetHeadDepartment(object[] objects, List<string> title)
        {
            HeadDepartment headDepartment = new HeadDepartment();
            headDepartment.Department = new Departments();
            headDepartment.Department.Audience = new Audience();
            headDepartment.Teacher = new Teacher();
            for (int i = 0; i < title.Count; i++)
            {

                if (title[i] == "idheaddepartment")
                {
                    headDepartment.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "iddepartments")
                {
                    headDepartment.Department.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namedepartments")
                {
                    headDepartment.Department.Name = objects[i].ToString();
                }
                else if (title[i] == "idaudience")
                {
                    headDepartment.Department.Audience.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "nameaudience")
                {
                    headDepartment.Department.Audience.Name = objects[i].ToString();
                }
                else if (title[i] == "address")
                {
                    headDepartment.Department.Audience.Address = objects[i].ToString();
                }
                else if (title[i] == "typeaudience")
                {
                    headDepartment.Department.Audience.Type = objects[i].ToString();
                }
                else if (title[i] == "capacity")
                {
                    headDepartment.Department.Audience.Capacity = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "traveltime")
                {
                    headDepartment.Department.Audience.TravelTime = TimeSpan.Parse(objects[i].ToString());
                }
                else if (title[i] == "idteacher")
                {
                    headDepartment.Teacher.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "iddepartments")
                {
                    headDepartment.Teacher.Departments.Id = Convert.ToInt32(objects[i].ToString());
                }
                else if (title[i] == "namedepartments")
                {
                    headDepartment.Teacher.Departments.Name = objects[i].ToString();
                }
                else if (title[i] == "lastname")
                {
                    headDepartment.Teacher.LastName = objects[i].ToString();
                }
                else if (title[i] == "nameteacher")
                {
                    headDepartment.Teacher.Name = objects[i].ToString();
                }
                else if (title[i] == "patronymic")
                {
                    headDepartment.Teacher.Patronymic = objects[i].ToString();
                }
                else if (title[i] == "position")
                {
                    headDepartment.Teacher.Position = objects[i].ToString();
                }
                else if (title[i] == "academicdegree")
                {
                    headDepartment.Teacher.AcademicDegree = objects[i].ToString();
                }


            }
            OrderTitle = new List<string>(title);
            return headDepartment;
        }

        public string GetHeadDepartmentValue(string title)
        {
            if (title == "idheaddepartment")
            {
                return Id.ToString();
            }
            else if (title == "iddepartments")
            {
                return Department.Id.ToString();
            }
            else if (title == "namedepartments")
            {
                return Department.Name;
            }
            else if (title == "idaudience")
            {
                return Department.Audience.Id.ToString();
            }
            else if (title == "nameaudience")
            {
                return Department.Audience.Name;
            }
            else if (title == "address")
            {
                return Department.Audience.Address;
            }
            else if (title == "typeaudience")
            {
                return Department.Audience.Type;
            }
            else if (title == "capacity")
            {
                return Department.Audience.Capacity.ToString();
            }
            else if (title == "traveltime")
            {
                return Department.Audience.TravelTime.ToString();
            }
            else if (title == "idteacher")
            {
                return Teacher.Id.ToString();
            }
            else if (title == "iddepartments")
            {
                return Teacher.Departments.Id.ToString();
            }
            else if (title == "namedepartments")
            {
                return Teacher.Departments.Name;
            }
            else if (title == "lastname")
            {
                return Teacher.LastName;
            }
            else if (title == "nameteacher")
            {
                return Teacher.Name;
            }
            else if (title == "patronymic")
            {
                return Teacher.Patronymic;
            }
            else if (title == "position")
            {
                return Teacher.Position;
            }
            else if (title == "academicdegree")
            {
                return Teacher.AcademicDegree;
            }
            return null;
        }
        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idheaddepartment")
                {
                    objects[i] = Id.ToString();
                }
                else if (title[i] == "iddepartments")
                {
                    objects[i] = Department.Id.ToString();
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Department.Name;
                }
                else if (title[i] == "idaudience")
                {
                    objects[i] = Department.Audience.Id.ToString();
                }
                else if (title[i] == "nameaudience")
                {
                    objects[i] = Department.Audience.Name;
                }
                else if (title[i] == "address")
                {
                    objects[i] = Department.Audience.Address;
                }
                else if (title[i] == "typeaudience")
                {
                    objects[i] = Department.Audience.Type;
                }
                else if (title[i] == "capacity")
                {
                    objects[i] = Department.Audience.Capacity.ToString();
                }
                else if (title[i] == "traveltime")
                {
                    objects[i] = Department.Audience.TravelTime.ToString();
                }
                else if (title[i] == "idteacher")
                {
                    objects[i] = Teacher.Id.ToString();
                }
                else if (title[i] == "iddepartments")
                {
                    objects[i] = Teacher.Departments.Id.ToString();
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Teacher.Departments.Name;
                }
                else if (title[i] == "lastname")
                {
                    objects[i] = Teacher.LastName;
                }
                else if (title[i] == "nameteacher")
                {
                    objects[i] = Teacher.Name;
                }
                else if (title[i] == "patronymic")
                {
                    objects[i] = Teacher.Patronymic;
                }
                else if (title[i] == "position")
                {
                    objects[i] = Teacher.Position;
                }
                else if (title[i] == "academicdegree")
                {
                    objects[i] = Teacher.AcademicDegree;
                }
            }
            return objects;
        }


        public static bool operator ==(HeadDepartment left, HeadDepartment right)
        {
            //return left.Id == right.Id && left.Name == right.Name && left.Audience == right.Audience && left.Teacher == right.Teacher;
            return false;
        }
        public static bool operator !=(HeadDepartment left, HeadDepartment right) => !(left == right);
    }
}
