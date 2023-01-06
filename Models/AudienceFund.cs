using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class AudienceFund
    {
        public int Id { get; set; }

        public Departments Departments { get; set; } = new Departments();

        public Audience Audience { get; set; } = new Audience();

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"idaudiencefund","Id" },
                {"iddepartments","Id" },
                {"namedepartments","Название" },
                { "idaudience", "Id" },
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

        private static AudienceFund GetAudienceFund(object[] objects, List<string> title)
        {
            AudienceFund audienceFund = new AudienceFund();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "iddepartments")
                {
                    audienceFund.Id = Convert.ToInt32(objects[i]);
                }

                else if(title[i] == "iddepartments")
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
                else if (title[i] == "name")
                {
                    audienceFund.Audience.Name = objects[i].ToString();
                }
                else if (title[i] == "address")
                {
                    audienceFund.Audience.Address = objects[i].ToString();
                }
                else if (title[i] == "typeAudience")
                {
                    audienceFund.Audience.Type = objects[i].ToString();
                }
                else if (title[i] == "capacity")
                {
                    audienceFund.Audience.Capacity = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "travelTime")
                {
                    audienceFund.Audience.TravelTime = TimeSpan.Parse( objects[i].ToString());
                }

            }
            OrderTitle = new List<string>(title);
            return audienceFund;
        }
    }
}
