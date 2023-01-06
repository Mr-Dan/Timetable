using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Group
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string RecruitmentYear { get; set; }

        public int Amount { get; set; }

        public string Formeducation { get; set;}

        public Faculty Faculty { get; set; } = new Faculty();

        public static List<string>? OrderTitle { get; set; }

        public static Dictionary<string,string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"idgroup","Id" },
                {"idfaculty","Id Факультет" },
                {"namegroup","Название" },
                {"formeducation","Форма обучения" },
                {"recruitmentyear","Год набора" },
                {"amount","Количество студентов" },
                {"namefaculty","Название факультета" },
                {"iddepartments","Id кафедры"},
                {"namedepartments","Название кафедры" }

            };

        public static List<Group> GetGroups(List<object[]> obj, List<string> title)
        {
            List<Group> list = new List<Group>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetGroup(objects, title));
            }
            return list;
        }
        public static Group GetGroup(object[] objects, List<string> title)
        {
            Group group = new Group();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idfaculty")
                {
                    group.Faculty.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namefaculty")
                {
                    group.Faculty.Name = objects[i].ToString();
                }
                else if (title[i] == "iddepartments")
                {
                    group.Faculty.Departments.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namedepartments")
                {
                    group.Faculty.Departments.Name = objects[i].ToString();
                }
                else if (title[i] == "idgroup")
                {
                    group.Id = Convert.ToInt32(objects[i].ToString());
                }
                else if (title[i] == "namegroup")
                {
                    group.Name = objects[i].ToString();
                }
                else if (title[i] == "formeducation")
                {
                    group.Formeducation = objects[i].ToString();
                }
                else if (title[i] == "recruitmentYear")
                {
                    group.RecruitmentYear = objects[i].ToString();
                }
                else if (title[i] == "amount")
                {
                    group.Amount = Convert.ToInt32(objects[i].ToString());
                }
                

            }
            OrderTitle = new List<string>(title);
            return group;
        }
    }
}
