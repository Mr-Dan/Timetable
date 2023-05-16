using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Timetable.Controller;

namespace Timetable.Models
{
    internal class Timetable
    {
        public int Id { get; set; }
        //public TypeLesson TypeLesson { get; set; } = new TypeLesson();
        public string ClassTime { get; set; }

        public Audience Audience { get; set; } = new Audience();

        public Teacher Teacher { get; set; } = new Teacher();

        public Discipline Discipline { get; set; } = new Discipline();

        public GroupTable Group { get; set; } = new GroupTable();

        public string WeekDay { get; set; }
        public string Periodicity { get; set; }

        public static List<string>? OrderTitle { get; set; }

        public static Dictionary<string, string> Title { get; set; } =
            new Dictionary<string, string>()
            {
                
                {"idtimetable","id" },
                {"namegroup","Название группы/потка" },
                {"idgroups","id Название группы/потка" },

                
                {"idteacher","id" },
                {"lastname","Фамилия" },
                {"nameteacher","Имя" },
                {"patronymic","Отчество" },
                {"position","Должность" },
                {"academicdegree","Учетная степень" },

                {"namediscipline","Название дисциплины" },
                {"typelesson","Тип занятия" },

                {"weekday","День недели"},
                {"classtime","Время пары"},
                {"periodicity","Периодичность"},

                
                { "idaudience", "id аудитории" },
                { "nameaudience", "Название аудитории" },

            };

        public static List<Timetable> GetTimetables(List<object[]> obj, List<string> title)
        {
            List<Timetable> list = new List<Timetable>();

            for (int i = 0; i < obj.Count; i++)
            {
                object[] objects = obj[i];

                list.Add(GetTimetable(objects, title));
            }
            return list;
        }
        public static Timetable GetTimetable(object[] objects, List<string> title)
        {
            Timetable timetable = new Timetable();

           
                for (int i = 0; i < title.Count; i++)
                {
                try
                {
                    if (title[i] == "namegroup")
                    {
                        timetable.Group.Name = objects[i].ToString();
                    }
                    else if(title[i] == "idgroups")
                    {
                        timetable.Group.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                    }
                    else if (title[i] == "idteacher")
                    {
                        timetable.Teacher.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                    }
                    else if (title[i] == "lastname")
                    {
                        timetable.Teacher.LastName = objects[i].ToString();
                    }
                    else if (title[i] == "nameteacher")
                    {
                        timetable.Teacher.Name = objects[i].ToString();
                    }
                    else if (title[i] == "patronymic")
                    {
                        timetable.Teacher.Patronymic = objects[i].ToString();
                    }
                    else if (title[i] == "position")
                    {
                        timetable.Teacher.Position = objects[i].ToString();
                    }
                    else if (title[i] == "academicdegree")
                    {
                        timetable.Teacher.AcademicDegree = objects[i].ToString();
                    }
                    else if (title[i] == "namediscipline")
                    {
                        timetable.Discipline.Name = objects[i].ToString();
                    }
                    else if (title[i] == "typelesson")
                    {
                        timetable.Discipline.TypeLesson = objects[i].ToString();
                    }
                    else if (title[i] == "weekday")
                    {
                        timetable.WeekDay = objects[i].ToString();
                    }
                    else if (title[i] == "classtime")
                    {
                        timetable.ClassTime = objects[i].ToString();
                    }
                    else if (title[i] == "periodicity")
                    {
                        timetable.Periodicity = objects[i].ToString();
                    }
                    else if (title[i] == "nameaudience")
                    {
                        timetable.Audience.Name = objects[i].ToString();
                    }
                    else if (title[i] == "idaudience")
                    {
                        timetable.Audience.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                    }
                    else if (title[i] == "idtimetable")
                    {
                        timetable.Id = ConvertCustom.ConvertToInt(objects[i].ToString());
                    }
                }
                catch { }


                }
            
            OrderTitle = new List<string>(title);
            return timetable;
        }

        public string GetTimetableValue(string title)
        {
            // Функция для получения данных с помощью имен полей таблицы.
            
            if (title == "idtimetable")
            {
                return Id.ToString();
            }
            else if (title == "idgroups")
            {
                return Group.Id.ToString();
            }
            else if (title == "idteacher")
            {
                return Teacher.Id.ToString();
            }
            else if (title == "namegroup")
            {
                return Group.Name;
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
            else if (title == "namediscipline")
            {
                return Discipline.Name;
            }
            else if (title == "typelesson")
            {
                return Discipline.TypeLesson;
            }
            else if (title == "weekday")
            {
                return WeekDay;
            }
            else if (title == "classtime")
            {
                return ClassTime ;
            }
            else if (title == "periodicity")
            {
                return Periodicity;
            }
            else if (title == "nameaudience")
            {
                return Audience.Name;
            }            
            else if (title == "idaudience")
            {
                return Audience.Id.ToString();
            }
            return null;
        }

        public object[] ConvertToObject(List<string> title)
        {
            object[] objects = new object[title.Count];

            for (int i = 0; i < title.Count; i++)
            {
                if (title[i] == "namegroup")
                {
                    objects[i] = Group.Name;
                }
                else if(title[i] == "idgroups")
                {
                    objects[i] = Group.Id;
                }              
                else if (title[i] == "idteacher")
                {
                    objects[i] = Teacher.Id;
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
                else if (title[i] == "namediscipline")
                {
                    objects[i] = Discipline.Name;
                }
                else if (title[i] == "typelesson")
                {
                    objects[i] = Discipline.TypeLesson;
                }
                else if (title[i] == "weekday")
                {
                    objects[i] = WeekDay;
                }
                else if (title[i] == "classtime")
                {
                    objects[i] = ClassTime;
                }
                else if (title[i] == "periodicity")
                {
                    objects[i] = Periodicity;
                }
                else if (title[i] == "nameaudience")
                {
                    objects[i] = Audience.Name;
                }
                else if (title[i] == "idtimetable")
                {
                    objects[i] = Id;
                }              
                else if (title[i] == "idaudience")
                {
                    objects[i] =  Audience.Id;
                }
            }

            return objects;
        }

        public static bool operator ==(Timetable left, Timetable right)
        {
            return left.Id == right.Id && left.ClassTime == right.ClassTime && left.Audience.Id == right.Audience.Id && left.Teacher.Id == right.Teacher.Id && left.Discipline.Id == right.Discipline.Id && left.Group.Id == right.Group.Id && left.WeekDay == right.WeekDay && left.Periodicity == right.Periodicity;
        }
        public static bool operator !=(Timetable left, Timetable right) => !(left == right);
    }
}
