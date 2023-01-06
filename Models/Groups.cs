using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models
{
    internal class Groups
    {
        public int Id { get; set; }
        public int IdGroups { get; set; }
        public Group Group { get; set; } = new Group();

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                {"id","Id" },
                {"idgroups","Id потока" },
                {"idgroup","Id Группы" },
                {"idfaculty","Id Факультет" },
                {"namegroup","Название" },
                {"formeducation","Форма обучения" },
                {"recruitmentyear","Год набора" },
                {"amount","Количество студентов" },
                {"namefaculty","Название факультета" },
                {"iddepartments","Id кафедры"},
                {"namedepartments","Название кафедры" }
            };
        public static List<string>? OrderTitle { get; set; }

        public static List<Groups> GetGroups(List<object[]> obj, List<string> title)
        {
            List<Groups> list = new List<Groups>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetGroup(objects, title));
            }
            return list;
        }
        public static Groups GetGroup(object[] objects, List<string> title)
        {
            Groups groups = new Groups();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idfaculty")
                {
                    groups.Group.Faculty.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "namefaculty")
                {
                    groups.Group.Faculty.Name = objects[i].ToString();
                }
                else if (title[i] == "iddepartments")
                {
                    groups.Group.Faculty.Departments.Id = Convert.ToInt32(objects[i]);
                }
                else if (title[i] == "idgroup")
                {
                    groups.Group.Id = Convert.ToInt32(objects[i].ToString());
                }
                else if (title[i] == "namegroup")
                {
                    groups.Group.Name = objects[i].ToString();
                }
                else if (title[i] == "formeducation")
                {
                    groups.Group.Formeducation = objects[i].ToString();
                }
                else if (title[i] == "recruitmentYear")
                {
                    groups.Group.RecruitmentYear = objects[i].ToString();
                }
                else if (title[i] == "amount")
                {
                    groups.Group.Amount = Convert.ToInt32(objects[i].ToString());
                }
                else if (title[i] == "idgroups")
                {
                    groups.IdGroups = Convert.ToInt32(objects[i].ToString());
                }
                else if (title[i] == "namedepartments")
                {
                    groups.Group.Faculty.Departments.Name = objects[i].ToString();
                }
                else if (title[i] == "Id")
                {
                    groups.Id = Convert.ToInt32(objects[i].ToString());
                }

            }
            OrderTitle = new List<string>(title);
            return groups;
        }
    }
}
