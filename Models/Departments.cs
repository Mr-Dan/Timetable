using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Timetable.Controller;

namespace Timetable.Models
{
    public class Departments
    {
        private int id;
        private string name;
        private Audience audience;
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

        public Audience Audience
        {
            get
            {
                return audience;
            }
            set
            {
                //if (value.Id <0)
                //{
                    //throw new Exception("Значение не может быть пустым");
                //}
                //else
                //{
                    audience = value;
                //}
            }
        }


        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"iddepartments","Id" },
                {"namedepartments","Название" },

                { "idaudience", "Id аудитории" },
                { "nameaudience", "Название" },
                { "address", "Адрес" },
                { "typeaudience", "Тип" },
                { "capacity", "Вместительность" },
                { "traveltime", "Время в пути к аудитории" },

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
            department.Audience = new Audience();
            
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
                    else if (title[i] == "idaudience")
                    {
                        department.Audience.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                    }
                    else if (title[i] == "nameaudience")
                    {
                        department.Audience.Name = objects[i].ToString();
                    }
                    else if (title[i] == "address")
                    {
                        department.Audience.Address = objects[i].ToString();
                    }
                    else if (title[i] == "typeaudience")
                    {
                        department.Audience.Type = objects[i].ToString();
                    }
                    else if (title[i] == "capacity")
                    {
                        department.Audience.Capacity = Convert.ToInt32(objects[i]);
                    }
                    else if (title[i] == "traveltime")
                    {
                        department.Audience.TravelTime = TimeSpan.Parse(objects[i].ToString());
                    }
                }
            
            OrderTitle = new List<string>(title);
            return department;
        }

        public string GetDepartmentValue(string title)
        {

            if (title == "iddepartments")
            {
                return Id.ToString();
            }
            else if (title == "namedepartments")
            {
                return Name;
            }
            else if (title == "idaudience")
            {
                return Audience.Id.ToString();
            }
            else if (title == "nameaudience")
            {
                return Audience.Name;
            }
            else if (title == "address")
            {
                return Audience.Address;
            }
            else if (title == "typeaudience")
            {
                return Audience.Type;
            }
            else if (title == "capacity")
            {
                return Audience.Capacity.ToString();
            }
            else if (title == "traveltime")
            {
                return Audience.TravelTime.ToString();
            }
            
            return null;
        }
        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "iddepartments")
                {
                    objects[i] = Id;
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Name;
                }
                else if (title[i] == "idaudience")
                {
                    objects[i] = Audience.Id;
                }
                else if (title[i] == "nameaudience")
                {
                    objects[i] = Audience.Name;
                }
                else if (title[i] == "address")
                {
                    objects[i] = Audience.Address;
                }
                else if (title[i] == "typeaudience")
                {
                    objects[i] =  Audience.Type;
                }
                else if (title[i] == "capacity")
                {
                    objects[i] = Audience.Capacity;
                }
                else if (title[i] == "traveltime")
                {
                    objects[i] = Audience.TravelTime;
                }
            }
       
            return objects;
        }


        public static bool operator ==(Departments left, Departments right)
        {
            return left.Id == right.Id && left.Name == right.Name && left.Audience.Id == right.Audience.Id;
        }
        public static bool operator !=(Departments left, Departments right) => !(left == right);
    }
}
