using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models;

namespace Timetable.Controller
{
    internal class SqlAssistant
    {
        private static Tuple<object[], List<string>> GetValue(NpgsqlDataReader reader, int count)
        // Функция для получения строки данных. Также универсальная функция для всех таблиц
        {
            List<string> title = new List<string>();
            object[] values = new object[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = reader[i].ToString(); //  Получаем данные таблицы
                title.Add(reader.GetName(i)); // Получаем имена полей таблицы
            }
            return Tuple.Create(values, title); // Возврат значений
        }

        public static Tuple<List<object[]>, List<string>> SelectAll(string cmdText, int count, NpgsqlConnection conn)
        // Выборка всех значений. Универсальная функция для всех таблиц
        {
            List<object[]> obj = new List<object[]>(); // массив значений
            List<string> title = new List<string>(); // масив заголовков 
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdText, conn); // SQL комманда
                NpgsqlDataReader reader = command.ExecuteReader(); // Чтение результата
                while (reader.Read())
                {
                    object[] values;
                    (values, title) = GetValue(reader, count); // Функция для получения строки данных
                    obj.Add(values);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Tuple.Create(obj, title); // Возврат значений
        }

        public static List<string> SelectOne(string cmdText, NpgsqlConnection conn)
        {
            List<string> list = new List<string>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdText, conn);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }


        public static (List<Audience>, List<string> title) SelectAudience(string cmdText, int countTitle, NpgsqlConnection conn)
         // Функция для получения таблицы Аудиторий
        {           
            List<object[]> obj = new List<object[]>(); // массив значений
            List<string> title = new List<string>(); // масив заголовков 
            (obj, title) = SelectAll(cmdText, countTitle, conn); // Функция для получения ВСЕХ значений

            List<Audience> audiencesList = new List<Audience>(Audience.GetAudiences(obj, title)); // Функция получения из объектов класс Audience
            // Данная функция нужна для правильного присвоения данных. Например можно выбрать
            // SELECT nameaudience, address FROM audience; и также  SELECT address, nameaudience FROM audience;
            // Программа в любом случае правильно считает данные для класса.
            return  (audiencesList,title);
        }

        public static (List<Departments>, List<string> title) SelectDepartments(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Departments> departmentsList = new List<Departments>(Departments.GetDepartments(obj, title));

           return (departmentsList,title);
        }


        public static (List<Discipline>, List<string> title) SelectDiscipline(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Discipline> disciplinesList = new List<Discipline>(Discipline.GetDisciplines(obj, title));

            return(disciplinesList,title);
        }

        public static (List<AudienceFund>, List<string> title) SelectAudienceFund(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<AudienceFund>  audienceFundList = new List<AudienceFund>(AudienceFund.GetAudiencesFund(obj, title));

            return (audienceFundList, title);
        }

        public static (List<Teacher>, List<string> title) SelectTeacher(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Teacher>  teacherList = new List<Teacher>(Teacher.GetTeachers(obj, title));

            return (teacherList, title);
        }

        public static (List<Faculty>, List<string> title) SelectFaculty(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Faculty> facultiesList = new List<Faculty>(Faculty.GetFaculties(obj, title));

            return(facultiesList, title); 
        }

        public static (List<GroupTable>, List<string> title) SelectGroup(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<GroupTable> groupList = new List<GroupTable>(GroupTable.GetGroupsTable(obj, title));

            return (groupList, title);
        }

        public static (List<Groups>, List<string> title) SelectGroups(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Groups> groupsList = new List<Groups>(Groups.GetGroups(obj, title));

            return (groupsList, title);
        }

        public static (List<Models.Timetable>, List<string> title) SelectTimeTable(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Models.Timetable> timetablesList = new List<Models.Timetable>(Models.Timetable.GetTimetables(obj, title));

            return (timetablesList, title);
        }


        public static (List<Curriculum>, List<string> title) SelectCurriculum(string cmdText, int countTitle, NpgsqlConnection conn)
        {

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);


            List<Curriculum> curriculaList = new List<Curriculum>(Curriculum.GetCurriculums(obj, title));

            return (curriculaList, title);
        }

        public static (List<CurriculumDiscipline>, List<string> title) SelectCurriculumDiscipline(string cmdText, int countTitle, NpgsqlConnection conn)
        {
            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);

            List<CurriculumDiscipline> curriculumDisciplinesList = new List<CurriculumDiscipline>(CurriculumDiscipline.GetCurriculumsDiscipline(obj, title));

            return (curriculumDisciplinesList, title);
        }

        public static (List<HeadDepartment>, List<string> title) SelectHeadDepartment(string cmdText, int countTitle, NpgsqlConnection conn)
        {
            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, countTitle, conn);

            List<HeadDepartment> headDepartmentList = new List<HeadDepartment>(HeadDepartment.GetHeadDepartments(obj, title));

            return (headDepartmentList, title);
        }

        public static bool CheckInfo(string cmdTxt, NpgsqlConnection conn)
        {
            if (conn?.State == ConnectionState.Open)
            {
                NpgsqlCommand command = new NpgsqlCommand(cmdTxt, conn);
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetInt32(0) > 0)
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
            }
            return false;
        }
    }

}
