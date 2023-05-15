using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Timetable.Models
{
    internal class AudienceFund
    {
        private int id;
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

        public Audience Audience { get; set; } = new Audience();

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"idaudiencefund","Id" },
                {"iddepartments","Id кафедры" },
                {"namedepartments","Название" },
                { "idaudience", "Id аудитории" },
                { "nameaudience", "Название" },
                { "address", "Адрес" },
                { "typeaudience", "Тип" },
                { "capacity", "Вместительность" },
                { "traveltime", "Время в пути к аудитории" }
            };
        public static List<string>? OrderTitle { get; set; }

        public static List<AudienceFund> GetAudiencesFund(List<object[]> obj, List<string> title)
        {
            List<AudienceFund> list = new List<AudienceFund>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetAudienceFund(objects, title));
            }
            return list;
        }

        public static AudienceFund GetAudienceFund(object[] objects, List<string> title)
        {
            AudienceFund audienceFund = new AudienceFund();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idaudiencefund")
                {
                    audienceFund.Id = Convert.ToInt32(objects[i]);
                }

                else if (title[i] == "iddepartments")
                {
                    audienceFund.Departments.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namedepartments")
                {
                    audienceFund.Departments.Name = objects[i].ToString();
                }
                if (title[i] == "idaudience")
                {
                    audienceFund.Audience.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "nameaudience")
                {
                    audienceFund.Audience.Name = objects[i].ToString();
                }
                else if (title[i] == "address")
                {
                    audienceFund.Audience.Address = objects[i].ToString();
                }
                else if (title[i] == "typeaudience")
                {
                    audienceFund.Audience.Type = objects[i].ToString();
                }
                else if (title[i] == "capacity")
                {
                    audienceFund.Audience.Capacity = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "traveltime")
                {
                    audienceFund.Audience.TravelTime = TimeSpan.Parse(objects[i].ToString());
                }

            }
            OrderTitle = new List<string>(title);
            return audienceFund;
        }

        public string GetAudienceFundValue(string title)
        {
            if (title == "idaudiencefund")
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
            if (title == "idaudience")
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
                if (title[i] == "idaudiencefund")
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
                if (title[i] == "idaudience")
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
                    objects[i] = Audience.Type;
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
    }
}
