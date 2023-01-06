using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    public class Audience
    {

        private int id;
        private string? name;
        private string? address;
        private string? type;
        public int capacity;
        public TimeSpan? travelTime;

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

        public string? Name {
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

        public string? Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    address = value;
                }
            }
        }

        public string? Type {
            get
            {
                return type;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    type = value;
                }
            }
        }

        public int Capacity {
            get
            {
                return capacity;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Значение не может быть меньше 0");
                }
                else
                {
                    capacity = value;
                }
            }
        }

        public TimeSpan? TravelTime {
            get
            {
                return travelTime;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    travelTime = value;
                }
            }
        }

        public static Dictionary<string, string> Title { get; set; } =
        new Dictionary<string, string>
        {
                { "idaudience", "Id" },
                { "nameaudience", "Название" },
                { "address", "Адрес" },
                { "typeaudience", "Тип" },
                { "capacity", "Вместительность" },
                { "traveltime", "Время в пути к аудитории" }

        };

        public static List<string>? OrderTitle { get; set; }

        public static List<Audience> GetAudiences(List<object[]> obj, List<string> title)
        {
            List<Audience> list = new List<Audience>();

            for (int i = 0; i < obj.Count; i++) // Передали строку данных и ее обрабатываем
            {
                object[] objects = obj[i];

                list.Add(GetAudience(objects, title)); // функция для преобразования объектов в класс
            }
            return list;
        }

        public static Audience GetAudience(object[] objects, List<string> title)
        {    
            Audience audience = new Audience();
            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idaudience")
                {
                    audience.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "nameaudience")
                {
                    audience.Name = objects[i].ToString();
                }
                else if (title[i] == "address")
                {
                    audience.Address = objects[i].ToString();
                }
                else if (title[i] == "typeaudience")
                {
                    audience.Type = objects[i].ToString();
                }
                else if (title[i] == "capacity")
                {
                    audience.Capacity = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "traveltime")
                {
                    audience.TravelTime = TimeSpan.Parse(objects[i].ToString());
                }
            }
            OrderTitle = new List<string>(title);
            return audience;     
        }

        public string GetAudienceValue(string title)
        {

            if (title == "idaudience")
            {
                return Id.ToString();
            }
            else if (title == "nameaudience")
            {
                return Name;
            }
            else if (title == "address")
            {
                return Address;
            }
            else if (title == "typeaudience")
            {
                return Type;
            }
            else if (title == "capacity")
            {
                return Capacity.ToString();
            }
            else if (title == "traveltime")
            {
                return TravelTime.ToString();
            }

            return null;
        }

        public static bool operator ==(Audience a1, Audience a2)
        {
            return a1.Id == a2.Id && a1.Name == a2.Name && a1.Address == a2.Address && a1.Type == a2.Type && a1.Capacity == a2.Capacity && a1.TravelTime == a2.TravelTime;
        }
        public static bool operator !=(Audience a1, Audience a2)
        {
            return a1.Id != a2.Id && a1.Name != a2.Name && a1.Address != a2.Address && a1.Type != a2.Type && a1.Capacity != a2.Capacity && a1.TravelTime != a2.TravelTime;
        }

    }
}
