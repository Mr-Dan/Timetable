using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Controller;

namespace Timetable.Models
{
    public class GroupTable
    {
        private int id;
        private string name;
        private DateTime recruitmentYear;
        private int amount;
        private string formeducation;
        private Faculty faculty = new Faculty();

        private Curriculum curriculum = new Curriculum();
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

        public string Name
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

        public DateTime RecruitmentYear
        {
            get
            {
                return recruitmentYear; // получаем данные
            }
            set
            {
                if (recruitmentYear == null)// Если данные не проходят, то выкидываем ошибку
                {
                    throw new Exception("Значение не может быть меньше 0");
                }
                else // Иначе записывем 
                {
                    recruitmentYear = value;
                }
            }
        }

        public int Amount
        {
            get
            {
                return amount; // получаем данные
            }
            set
            {
                if (value < 0)// Если данные не проходят, то выкидываем ошибку
                {
                    throw new Exception("Значение не может быть меньше 0");
                }
                else // Иначе записывем 
                {
                    amount = value;
                }
            }
        }

        public string Formeducation
        {
            get
            {
                return formeducation;
            }
            set
            {
                if (value == "" || value == null)
                {
                    throw new Exception("Значение не может быть пустым");
                }
                else
                {
                    formeducation = value;
                }
            }
        }

        public Faculty Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
            }
        }
        public Curriculum Curriculum
        {
            get
            {
                return curriculum;
            }
            set
            {
                curriculum = value;
            }
        }
        public static List<string>? OrderTitle { get; set; }

        public static Dictionary<string, string> Title { get; set; } =
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
                {"namedepartments","Название кафедры" },
                {"idcurriculum","Id учебного плана"},
                {"namecurriculum","Название учебного плана "},
                {"qualification","Квалификация"},
            };

        public static List<GroupTable> GetGroupsTable(List<object[]> obj, List<string> title)
        {
            List<GroupTable> list = new List<GroupTable>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetGroupTable(objects, title));
            }
            return list;
        }
        public static GroupTable GetGroupTable(object[] objects, List<string> title)
        {
            GroupTable group = new GroupTable();

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "idfaculty")
                {
                    group.Faculty.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "namefaculty")
                {
                    group.Faculty.Name = objects[i].ToString();
                }
                else if (title[i] == "iddepartments")
                {
                    group.Faculty.Departments.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "namedepartments")
                {
                    group.Faculty.Departments.Name = objects[i].ToString();
                }
                else if (title[i] == "idgroup")
                {
                    group.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "namegroup")
                {
                    group.Name = objects[i].ToString();
                }
                else if (title[i] == "formeducation")
                {
                    group.Formeducation = objects[i].ToString();
                }
                else if (title[i] == "recruitmentyear")
                {
                    group.RecruitmentYear = Convert.ToDateTime(objects[i]);
                }
                else if (title[i] == "amount")
                {
                    group.Amount = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "idcurriculum")
                {
                    group.Curriculum.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                }
                else if (title[i] == "namecurriculum")
                {
                    group.Curriculum.Name = objects[i].ToString();
                }
                else if (title[i] == "amount")
                {
                    group.Curriculum.Qualification = objects[i].ToString();
                }


            }
            OrderTitle = new List<string>(title);
            return group;
        }

        public string GetGroupTableValue(string title)
        {
            if (title == "idfaculty")
            {
                return Faculty.Id.ToString();
            }
            else if (title == "namefaculty")
            {
                return Faculty.Name;
            }
            else if (title == "iddepartments")
            {
                return Faculty.Departments.Id.ToString();
            }
            else if (title == "namedepartments")
            {
                return Faculty.Departments.Name;
            }
            else if (title == "idgroup")
            {
                return Id.ToString();
            }
            else if (title == "namegroup")
            {
                return Name;
            }
            else if (title == "formeducation")
            {
                return Formeducation;
            }
            else if (title == "recruitmentyear")
            {
                return RecruitmentYear.ToString("dd/MM/yyyy");
            }
            else if (title == "amount")
            {
                return Amount.ToString();
            }
            else if (title == "idcurriculum")
            {
                return Curriculum.Id.ToString();
            }
            else if (title == "namecurriculum")
            {
                return Curriculum.Name ;
            }
            else if (title == "amount")
            {
                return Curriculum.Qualification;
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
                    objects[i] = Faculty.Id;
                }
                else if (title[i] == "namefaculty")
                {
                    objects[i] = Faculty.Name;
                }
                else if (title[i] == "iddepartments")
                {
                    objects[i] = Faculty.Departments.Id;
                }
                else if (title[i] == "namedepartments")
                {
                    objects[i] = Faculty.Departments.Name;
                }
                else if (title[i] == "idgroup")
                {
                    objects[i] = Id;
                }
                else if (title[i] == "namegroup")
                {
                    objects[i] = Name;
                }
                else if (title[i] == "formeducation")
                {
                    objects[i] = Formeducation;
                }
                else if (title[i] == "recruitmentyear")
                {
                    objects[i] = RecruitmentYear.ToString("dd/MM/yyyy");
                }
                else if (title[i] == "amount")
                {
                    objects[i] = Amount;
                }
                else if (title[i] == "idcurriculum")
                {
                    objects[i] = Curriculum.Id;
                }
                else if (title[i] == "namecurriculum")
                {
                    objects[i] = Curriculum.Name;
                }
                else if (title[i] == "qualification")
                {
                    objects[i] = Curriculum.Qualification;
                }
            }

            return objects;
        }
    }
}
