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
        public GroupTable Group { get; set; } = new GroupTable();

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
                    groups.Group.RecruitmentYear = Convert.ToDateTime(objects[i].ToString());
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
                else if (title[i] == "id")
                {
                    groups.Id = Convert.ToInt32(objects[i].ToString());
                }

            }
            OrderTitle = new List<string>(title);
            return groups;
        }

        public string GetGroupsValue(string title)
        {
            if (title == "idfaculty")
            {
                return Group.Faculty.Id.ToString();
            }
            else if (title == "namefaculty")
            {
                return Group.Faculty.Name;
            }
            else if (title == "iddepartments")
            {
                return Group.Faculty.Departments.Id.ToString();
            }
            else if (title == "idgroup")
            {
                return Group.Id.ToString();
            }
            else if (title == "namegroup")
            {
                return Group.Name;
            }
            else if (title == "formeducation")
            {
                return Group.Formeducation;
            }
            else if (title == "recruitmentYear")
            {
                return Group.RecruitmentYear.ToString();
            }
            else if (title == "amount")
            {
                return Group.Amount.ToString();
            }
            else if (title == "idgroups")
            {
                return IdGroups.ToString();
            }
            else if (title == "namedepartments")
            {
                return Group.Faculty.Departments.Name;
            }
            else if (title == "id")
            {
                return Id.ToString();
            }
            return null;
        }

        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idfaculty")
                {
                    objects[i] = Group.Faculty.Id;
                }
                else if (title[i] == "namefaculty")
                {
                    objects[i] =  Group.Faculty.Name ;
                }
                else if (title[i] == "iddepartments")
                {
                    objects[i] =  Group.Faculty.Departments.Id ;
                }
                else if (title[i] == "idgroup")
                {
                    objects[i] = Group.Id;
                }
                else if (title[i] == "namegroup")
                {
                    objects[i] = Group.Name;
                }
                else if (title[i] == "formeducation")
                {
                    objects[i] = Group.Formeducation;
                }
                else if (title[i] == "recruitmentYear")
                {
                    objects[i] = Group.RecruitmentYear;
                }
                else if (title[i] == "amount")
                {
                    objects[i] = Group.Amount;
                }
                else if (title[i] == "idgroups")
                {
                    objects[i] = IdGroups;
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Group.Faculty.Departments.Name;
                }
                else if (title[i] == "id")
                {
                    objects[i] = Id;
                }

            }
            return objects;
        }
    }
}
