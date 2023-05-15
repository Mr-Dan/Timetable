using Npgsql;
using Npgsql.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Timetable.Controller;
using Timetable.Controls;
using Timetable.Models;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Timetable.Forms
{
    public partial class DBForm : Form
    {
        private NpgsqlConnection conn;
        private string nameTable;

        private List<Audience> audiencesList;
        private List<Departments> departmentsList;
        private List<Discipline> disciplinesList;
        private List<AudienceFund> audienceFundList;
        private List<Teacher> teacherList;
        private List<Faculty> facultiesList;
        private List<GroupTable> groupTableList;
        private List<Groups> groupsList;
        private List<Models.Timetable> timetablesList;
        private List<Curriculum> curriculumList;
        private List<CurriculumDiscipline> curriculumDisciplinesList;
        private List<HeadDepartment> headDepartmentList;

        private bool backup;
        private List<Audience> AudienceListUpdate = new List<Audience>();
        private List<Departments> DepartmentsListUpdate = new List<Departments>();
        private List<HeadDepartment> HeadDepartmentListUpdate = new List<HeadDepartment>();
        private List<Discipline> DisciplineListUpdate = new List<Discipline>();
        private List<Faculty> FacultyListUpdate = new List<Faculty>();
        private List<GroupTable> GroupTableListUpdate = new List<GroupTable>();
        private List<Teacher> TeacherListUpdate = new List<Teacher>();
        private List<AudienceFund> AudienceFundListUpdate = new List<AudienceFund>();
        private List<Groups> GroupsListUpdate = new List<Groups>();
        private List<Curriculum> CurriculumListUpdate = new List<Curriculum>();
        private List<CurriculumDiscipline> CurriculumDisciplineListUpdate = new List<CurriculumDiscipline>();



        public DBForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

        }

        public void ClearDataGrid()
        {
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            insertPanel.Visible = false;
            AudienceListUpdate.Clear();
            DepartmentsListUpdate.Clear();
            HeadDepartmentListUpdate.Clear();
        }

        #region Update
        public void UpdateAudience(string cmdText, int countTitle) // Функция для обновления таблицы Аудиторий
        {
            ClearDataGrid(); // очистка таблицы

            List<string> title = new List<string>(); // масив заголовков 
            (audiencesList, title) = SqlAssistant.SelectAudience(cmdText, countTitle, conn); // Функция получения из объектов класс Audience
            // Данная функция нужна для правильного присвоения данных. Например можно выбрать
            // SELECT nameaudience, address FROM audience; и также  SELECT address, nameaudience FROM audience;
            // Программа в любом случае правильно считает данные для класса.
            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Audience.Title[item]); // Добавляем заголовки
                if (item.IndexOf("idaudience") > -1)
                {
                    dataGridViewTable.Columns[dataGridViewTable.Columns.Count - 1].ReadOnly = true;// Ставим запрет на редактирования id
                }
            }
            for (int i = 0; i < audiencesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(audiencesList[i].ConvertToObject(title)); // Добавляем данные в таблицу
            }
        }

        public void UpdateDepartments(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();

            (departmentsList, title) = SqlAssistant.SelectDepartments(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Departments.Title[item]);
                if (item.IndexOf("iddepartments") > -1)
                {
                    dataGridViewTable.Columns[dataGridViewTable.Columns.Count - 1].ReadOnly = true;// Ставим запрет на редактирования id
                }
            }

            for (int i = 0; i < departmentsList.Count; i++)
            {
                dataGridViewTable.Rows.Add(departmentsList[i].ConvertToObject(title));
            }
        }

        public void UpdateDiscipline(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (disciplinesList, title) = SqlAssistant.SelectDiscipline(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Discipline.Title[item]);
            }

            for (int i = 0; i < disciplinesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(disciplinesList[i].ConvertToObject(title));
            }
        }

        public void UpdateAudienceFund(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (audienceFundList, title) = SqlAssistant.SelectAudienceFund(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, AudienceFund.Title[item]);
            }

            for (int i = 0; i < audienceFundList.Count; i++)
            {
                dataGridViewTable.Rows.Add(audienceFundList[i].ConvertToObject(title));
            }
        }

        public void UpdateTeacher(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (teacherList, title) = SqlAssistant.SelectTeacher(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Teacher.Title[item]);
            }

            for (int i = 0; i < teacherList.Count; i++)
            {
                dataGridViewTable.Rows.Add(teacherList[i].ConvertToObject(title));
            }
        }

        public void UpdateFaculty(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (facultiesList, title) = SqlAssistant.SelectFaculty(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Faculty.Title[item]);
            }

            for (int i = 0; i < facultiesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(facultiesList[i].ConvertToObject(title));
            }
        }

        public void UpdateGroupTable(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (groupTableList, title) = SqlAssistant.SelectGroup(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Models.GroupTable.Title[item]);
            }

            for (int i = 0; i < groupTableList.Count; i++)
            {
                dataGridViewTable.Rows.Add(groupTableList[i].ConvertToObject(title));
            }
        }

        public void UpdateGroups(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (groupsList, title) = SqlAssistant.SelectGroups(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Groups.Title[item]);
            }

            for (int i = 0; i < groupsList.Count; i++)
            {
                dataGridViewTable.Rows.Add(groupsList[i].ConvertToObject(title));
            }
        }

        private void UpdateTimeTable(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (timetablesList, title) = SqlAssistant.SelectTimeTable(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Models.Timetable.Title[item]);
            }

            for (int i = 0; i < timetablesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(timetablesList[i]);
            }
        }

        public void UpdateCurriculum(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (curriculumList, title) = SqlAssistant.SelectCurriculum(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Curriculum.Title[item]);
            }

            for (int i = 0; i < curriculumList.Count; i++)
            {
                dataGridViewTable.Rows.Add(curriculumList[i].ConvertToObject(title));
            }
        }

        public void UpdateCurriculumDiscipline(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (curriculumDisciplinesList, title) = SqlAssistant.SelectCurriculumDiscipline(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, CurriculumDiscipline.Title[item]);
            }
            //dataGridViewTable.Columns[0].Visible = false;

            for (int i = 0; i < curriculumDisciplinesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(curriculumDisciplinesList[i].ConvertToObject(title));
            }
            /// !!!!!!!!!MessageBox.Show(dataGridViewTable.Rows[0].Cells[0].Value.ToString());
        }

        public void UpdateHeadDepartment(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (headDepartmentList, title) = SqlAssistant.SelectHeadDepartment(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, HeadDepartment.Title[item]);
                if (item.IndexOf("idheaddepartment") > -1)
                {
                    dataGridViewTable.Columns[dataGridViewTable.Columns.Count - 1].ReadOnly = true;// Ставим запрет на редактирования id
                }
            }

            // dataGridViewTable.Columns[0].Visible = false;

            for (int i = 0; i < headDepartmentList.Count; i++)
            {
                dataGridViewTable.Rows.Add(headDepartmentList[i].ConvertToObject(title));
            }
        }


        #endregion

        #region Button_Click
        private void audienceButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateAudience("SELECT * FROM audience;", 6);
                nameTable = "audience";
            }

        }

        private void timetableButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                //UpdateTimeTable("SELECT idtimetable,grouptable.namegroup,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience;",13);
                nameTable = "timetable";
            }
        }

        private void departmentsButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateDepartments("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6);
                nameTable = "departments";
            }
        }

        private void disciplineButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateDiscipline("SELECT * FROM discipline;", 3);
                nameTable = "discipline";
            }
        }

        private void facultyButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {

                UpdateFaculty("SELECT idfaculty, namefaculty,faculty.iddepartments," +
            " namedepartments FROM faculty LEFT JOIN departments USING(iddepartments);", 4);
                nameTable = "faculty";
            }
        }

        private void groupTableButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateGroupTable("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                    "idfaculty, namefaculty, iddepartments, namedepartments,idcurriculum,namecurriculum,qualification" +
                    " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN curriculum USING(idcurriculum);", 12);
                nameTable = "grouptable";
            }
        }

        private void teacherButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateTeacher("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    " FROM teacher LEFT JOIN departments  USING(iddepartments);", 8);
                nameTable = "teacher";
            }
        }

        private void groupsButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateGroups("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    " FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments);", 8);

                nameTable = "groups";
            }
        }

        private void audienceFundButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateAudienceFund("SELECT idaudiencefund," +
                    "iddepartments,namedepartments," +
                    "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                    " FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments);", 9);
                nameTable = "audiencefund";
            }
        }

        private void curriculumButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateCurriculum("SELECT * FROM curriculum;", 3);
                nameTable = "curriculum";
            }
        }

        private void curriculumDisciplineButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateCurriculumDiscipline("SELECT idcurriculumdiscipline,course,semester,hours," +
                    "idcurriculum,namecurriculum,qualification," +
                    "iddiscipline,namediscipline,typelesson" +
                    " FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline);", 10);
                nameTable = "curriculumdiscipline";
            }
        }

        private void headDepartmentButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateHeadDepartment("SELECT idheaddepartment," +
            "headdepartment.iddepartments,namedepartments," +
            "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
            "FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher);", 9);
                nameTable = "headdepartment";
            }
        }
        #endregion

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    if (nameTable == "audience")
                    {
                        UpdateAudience($"SELECT * FROM audience WHERE nameaudience ~*'{SearchTextBox.Text.Trim()}' OR address ~*'{SearchTextBox.Text.Trim()}'", 6);
                    }
                    else if (nameTable == "timetable")
                    {

                    }
                    else if (nameTable == "departments")
                    {
                        UpdateDepartments("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    $"FROM departments LEFT JOIN audience USING(idaudience) WHERE namedepartments ~*'{SearchTextBox.Text.Trim()}'", 6);
                    }
                    else if (nameTable == "discipline")
                    {
                        UpdateDiscipline($"SELECT * FROM discipline WHERE namediscipline ~*'{SearchTextBox.Text.Trim()}';", 3);


                    }

                    else if (nameTable == "faculty")
                    {
                        UpdateFaculty("SELECT idfaculty, namefaculty,faculty.iddepartments," +
            $" namedepartments FROM faculty LEFT JOIN departments USING(iddepartments) WHERE namefaculty ~*'{SearchTextBox.Text.Trim()}';", 4);
                    }
                    else if (nameTable == "grouptable")
                    {
                        UpdateGroupTable("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                       "idfaculty, namefaculty, iddepartments, namedepartments,idcurriculum,namecurriculum,qualification" +
                       $" FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN curriculum USING(idcurriculum); WHERE namegroup ~*'{SearchTextBox.Text.Trim()}' OR namefaculty ~*'{SearchTextBox.Text.Trim()}';", 12);
                    }
                    else if (nameTable == "teacher")
                    {

                        UpdateTeacher("SELECT " +
                        "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                        "iddepartments,namedepartments " +
                        $" FROM teacher LEFT JOIN departments  USING(iddepartments) WHERE lastname ~*'{SearchTextBox.Text.Trim()}' OR nameteacher ~*'{SearchTextBox.Text.Trim()}' OR namedepartments ~*'{SearchTextBox.Text.Trim()}';", 8);
                    }
                    else if (nameTable == "groups")
                    {
                        UpdateGroups("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    $" FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments) WHERE namegroup ~*'{SearchTextBox.Text.Trim()}';", 8);
                    }
                    else if (nameTable == "audiencefund")
                    {
                        UpdateAudienceFund("SELECT idaudiencefund," +
                        "iddepartments,namedepartments," +
                        "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                        $" FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments) WHERE namedepartments ~*'{SearchTextBox.Text.Trim()}' OR nameaudience ~*'{SearchTextBox.Text.Trim()}';", 9);
                    }
                    else if (nameTable == "curriculum")
                    {
                        UpdateCurriculum($"SELECT * FROM curriculum WHERE namecurriculum ~*'{SearchTextBox.Text.Trim()}';", 3);
                    }
                    else if (nameTable == "curriculumdiscipline")
                    {

                        UpdateCurriculumDiscipline("SELECT idcurriculumdiscipline,course,semester,hours," +
                        "idcurriculum,namecurriculum,qualification," +
                        "iddiscipline,namediscipline,typelesson" +
                        $" FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline) WHERE namecurriculum ~*'{SearchTextBox.Text.Trim()} OR namediscipline ~*'{SearchTextBox.Text.Trim()}';", 10);
                    }
                    else if (nameTable == "headdepartment")
                    {

                        UpdateHeadDepartment("SELECT idheaddepartment," +
                        "headdepartment.iddepartments,namedepartments," +
                        "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
                        $"FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher) WHERE namedepartments ~*'{SearchTextBox.Text.Trim()}' OR lastname ~*'{SearchTextBox.Text.Trim()}' OR nameteacher ~*'{SearchTextBox.Text.Trim()}';", 9);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {// Срабатывает когда оператор нажимает на кнопку
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    if (nameTable == "audience")
                    {
                        for (int i = 0; i < AudienceListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("update audience " +
                                "set nameaudience=@nameaudience,address =@address, typeaudience =@typeaudience::typeaudience," +
                                "capacity=@capacity,travelTime=@travelTime " +
                                "WHERE idaudience=@idaudience;", conn);
                            command.Parameters.AddWithValue("nameaudience", AudienceListUpdate[i].Name);
                            command.Parameters.AddWithValue("address", AudienceListUpdate[i].Address);
                            command.Parameters.AddWithValue("typeaudience", AudienceListUpdate[i].Type);
                            command.Parameters.AddWithValue("capacity", AudienceListUpdate[i].Capacity);
                            command.Parameters.AddWithValue("travelTime", AudienceListUpdate[i].travelTime);
                            command.Parameters.AddWithValue("idaudience", AudienceListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        AudienceListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateAudience("SELECT * FROM audience;", 6); // Обновляем данные
                    }
                    else if (nameTable == "timetable")
                    {

                    }
                    else if (nameTable == "departments")
                    {
                        for (int i = 0; i < DepartmentsListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE departments " +
                                "SET namedepartments = @namedepartments,idaudience = @idaudience " +
                                "WHERE iddepartments = @iddepartments", conn);
                            command.Parameters.AddWithValue("namedepartments", DepartmentsListUpdate[i].Name);
                            command.Parameters.AddWithValue("idaudience", DepartmentsListUpdate[i].Audience.Id);
                            command.Parameters.AddWithValue("iddepartments", DepartmentsListUpdate[i].Id);

                            command.ExecuteNonQuery();
                        }
                        DepartmentsListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateDepartments("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6); // Обновляем данные
                    }
                    else if (nameTable == "discipline")
                    {
                        for (int i = 0; i < DisciplineListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE discipline " +
                                "SET namediscipline=@namediscipline, typelesson =@typelesson::typelesson " +
                                "WHERE iddiscipline=@iddiscipline;", conn);
                            command.Parameters.AddWithValue("namediscipline", DisciplineListUpdate[i].Name);
                            command.Parameters.AddWithValue("typelesson", DisciplineListUpdate[i].TypeLesson);
                            command.Parameters.AddWithValue("iddiscipline", DisciplineListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        DisciplineListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateDiscipline("SELECT * FROM discipline;", 3); // Обновляем данные
                    }
                    else if (nameTable == "faculty")
                    {
                        for (int i = 0; i < FacultyListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE faculty " +
                                "SET namefaculty=@namefaculty, iddepartments =@iddepartments " +
                                "WHERE idfaculty=@idfaculty;", conn);
                            command.Parameters.AddWithValue("namefaculty", FacultyListUpdate[i].Name);
                            command.Parameters.AddWithValue("iddepartments", FacultyListUpdate[i].Departments.Id);
                            command.Parameters.AddWithValue("idfaculty", FacultyListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        FacultyListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateFaculty("SELECT idfaculty, namefaculty,faculty.iddepartments," +
            " namedepartments FROM faculty LEFT JOIN departments USING(iddepartments);", 4); // Обновляем данные
                    }
                    else if (nameTable == "grouptable")
                    {
                        for (int i = 0; i < GroupTableListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE grouptable " +
                                "SET idfaculty = @idfaculty, namegroup = @namegroup,formeducation = @formeducation::formeducation, recruitmentyear = @recruitmentyear, amount = @amount,idcurriculum =@idcurriculum " +
                                "WHERE idgroup = @idgroup;", conn);
                            command.Parameters.AddWithValue("idfaculty", GroupTableListUpdate[i].Faculty.Id);
                            command.Parameters.AddWithValue("namegroup", GroupTableListUpdate[i].Name);
                            command.Parameters.AddWithValue("formeducation", GroupTableListUpdate[i].Formeducation);
                            command.Parameters.AddWithValue("recruitmentyear", GroupTableListUpdate[i].RecruitmentYear);
                            command.Parameters.AddWithValue("amount", GroupTableListUpdate[i].Amount);
                            command.Parameters.AddWithValue("idcurriculum", GroupTableListUpdate[i].Curriculum.Id);
                            command.Parameters.AddWithValue("idgroup", GroupTableListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        GroupTableListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateGroupTable("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                    "idfaculty, namefaculty, iddepartments, namedepartments,idcurriculum,namecurriculum,qualification" +
                    " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN curriculum USING(idcurriculum);", 12); // Обновляем данные

                    }
                    else if (nameTable == "teacher")
                    {
                        for (int i = 0; i < TeacherListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE teacher " +
                                "SET iddepartments = @iddepartments, lastname = @lastname,nameteacher = @nameteacher, patronymic = @patronymic, position = @position,academicdegree = @academicdegree " +
                                "WHERE idteacher = @idteacher;", conn);
                            command.Parameters.AddWithValue("iddepartments", TeacherListUpdate[i].Departments.Id);
                            command.Parameters.AddWithValue("lastname", TeacherListUpdate[i].LastName);
                            command.Parameters.AddWithValue("nameteacher", TeacherListUpdate[i].Name);
                            command.Parameters.AddWithValue("patronymic", TeacherListUpdate[i].Patronymic);
                            command.Parameters.AddWithValue("position", TeacherListUpdate[i].Position);
                            command.Parameters.AddWithValue("academicdegree", TeacherListUpdate[i].AcademicDegree);
                            command.Parameters.AddWithValue("idteacher", TeacherListUpdate[i].Id);

                            command.ExecuteNonQuery();
                        }
                        TeacherListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateTeacher("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    " FROM teacher LEFT JOIN departments  USING(iddepartments);", 8); // Обновляем данные
                    }
                    else if (nameTable == "groups")
                    {
                        for (int i = 0; i < GroupsListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE groups " +
                                "SET idgroups = @idgroups, idgroup = @idgroup " +
                                "WHERE id = @id;", conn);
                            command.Parameters.AddWithValue("idgroups", GroupsListUpdate[i].IdGroups);
                            command.Parameters.AddWithValue("idgroup", GroupsListUpdate[i].Group.Id);
                            command.Parameters.AddWithValue("id", GroupsListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        GroupsListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateGroups("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    " FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments);", 8); // Обновляем данные
                    }
                    else if (nameTable == "audiencefund")
                    {
                        for (int i = 0; i < AudienceFundListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE audienceFund " +
                                "SET iddepartments = @iddepartments, idaudience = @idaudience " +
                                "WHERE idaudiencefund = @idaudiencefund;", conn);
                            command.Parameters.AddWithValue("iddepartments", AudienceFundListUpdate[i].Departments.Id);
                            command.Parameters.AddWithValue("idaudience", AudienceFundListUpdate[i].Audience.Id);
                            command.Parameters.AddWithValue("idaudiencefund", AudienceFundListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        AudienceFundListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateAudienceFund("SELECT idaudiencefund," +
                    "iddepartments,namedepartments," +
                    "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                    " FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments);", 9); // Обновляем данные
                    }
                    else if (nameTable == "curriculum")
                    {
                        for (int i = 0; i < CurriculumListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE curriculum " +
                                "SET namecurriculum = @namecurriculum, qualification = @qualification::qualification " +
                                "WHERE idcurriculum = @idcurriculum;", conn);
                            command.Parameters.AddWithValue("namecurriculum", CurriculumListUpdate[i].Name);
                            command.Parameters.AddWithValue("qualification", CurriculumListUpdate[i].Qualification);
                            command.Parameters.AddWithValue("idcurriculum", CurriculumListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        CurriculumListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateCurriculum("SELECT * FROM curriculum;", 3); // Обновляем данные
                    }
                    else if (nameTable == "curriculumdiscipline")
                    {
                        for (int i = 0; i < CurriculumDisciplineListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE curriculumdiscipline " +
                                "SET idcurriculum = @idcurriculum, iddiscipline = @iddiscipline, course = @course, semester = @semester, hours = @hours " +
                                "WHERE idcurriculumdiscipline = @idcurriculumdiscipline;", conn);
                            command.Parameters.AddWithValue("idcurriculum", CurriculumDisciplineListUpdate[i].Curriculum.Id);
                            command.Parameters.AddWithValue("iddiscipline", CurriculumDisciplineListUpdate[i].Discipline.Id);
                            command.Parameters.AddWithValue("course", CurriculumDisciplineListUpdate[i].Course);
                            command.Parameters.AddWithValue("semester", CurriculumDisciplineListUpdate[i].Semester);
                            command.Parameters.AddWithValue("hours", CurriculumDisciplineListUpdate[i].Hours);
                            command.Parameters.AddWithValue("idcurriculumdiscipline", CurriculumDisciplineListUpdate[i].Id);
                            command.ExecuteNonQuery();
                        }
                        CurriculumDisciplineListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateCurriculumDiscipline("SELECT idcurriculumdiscipline,course,semester,hours," +
                    "idcurriculum,namecurriculum,qualification," +
                    "iddiscipline,namediscipline,typelesson" +
                    " FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline);", 10); // Обновляем данные
                    }
                    else if (nameTable == "headdepartment")
                    {
                        for (int i = 0; i < HeadDepartmentListUpdate.Count; i++) // Пробегаем по этим строкам
                        {
                            NpgsqlCommand command = new NpgsqlCommand("UPDATE headdepartment " +
                                "SET idteacher = @idteacher " +
                                "WHERE idheaddepartment = @idheaddepartment", conn);
                            command.Parameters.AddWithValue("idteacher", HeadDepartmentListUpdate[i].Teacher.Id);
                            command.Parameters.AddWithValue("idheaddepartment", HeadDepartmentListUpdate[i].Id);

                            command.ExecuteNonQuery();
                        }
                        HeadDepartmentListUpdate.Clear(); // Очищаем таблицу для обновлений 
                        UpdateHeadDepartment("SELECT idheaddepartment," +
            "headdepartment.iddepartments,namedepartments," +
            "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
            "FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher);", 9); // Обновляем данные
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private object[] GetValueDataGrid(int row) // Функция для получения данных из строки DataGridView
        {
            object[] objects = new object[dataGridViewTable.ColumnCount];

            for (int i = 0; i < objects.Length; i++)
            {
                if (dataGridViewTable.Rows[row].Cells[i].Value != null)
                {
                    objects[i] = dataGridViewTable.Rows[row].Cells[i].Value;
                }
                else
                {
                    objects[i] = "";
                }
            }
            return objects;
        }

        private void dataGridViewTable_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        { // событые которое возникает из-за удаления строки
            if (conn?.State == ConnectionState.Open)
            {
                try
                {
                    if (nameTable == "audience") // Проверка на активную таблицу
                    {
                        int pos = dataGridViewTable.Columns["idaudience"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Audience? audience = audiencesList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM  audience WHERE idaudience=@idaudience", conn);// Удаляем 
                        command.Parameters.AddWithValue("idaudience", audience.Id);
                        command.ExecuteNonQuery();
                        UpdateAudience("SELECT * FROM audience;", 6);// Обновляем таблицу.
                    }
                    else if (nameTable == "timetable")
                    {
                        int pos = dataGridViewTable.Columns["idtimetable"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Models.Timetable? timetable = timetablesList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM timetable WHERE idtimetable=@idtimetable", conn);// Удаляем 
                        command.Parameters.AddWithValue("idtimetable", timetable.Id);
                        command.ExecuteNonQuery();
                        //UpdateAudience("SELECT idtimetable,grouptable.namegroup,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience;");// Обновляем таблицу.
                    }
                    else if (nameTable == "departments")
                    {
                        int pos = dataGridViewTable.Columns["iddepartments"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Departments department = departmentsList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM departments WHERE iddepartments=@iddepartments", conn);// Удаляем 
                        command.Parameters.AddWithValue("iddepartments", department.Id);
                        command.ExecuteNonQuery();
                        UpdateDepartments("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6);
                    }
                    else if (nameTable == "discipline")
                    {
                        int pos = dataGridViewTable.Columns["iddiscipline"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Discipline discipline = disciplinesList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM discipline WHERE iddiscipline=@iddiscipline", conn);// Удаляем 
                        command.Parameters.AddWithValue("iddiscipline", discipline.Id);
                        command.ExecuteNonQuery();
                        UpdateDiscipline("SELECT * FROM discipline;", 3);
                    }
                    else if (nameTable == "faculty")
                    {
                        int pos = dataGridViewTable.Columns["idfaculty"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Faculty faculty = facultiesList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM faculty WHERE idfaculty=@idfaculty", conn);// Удаляем 
                        command.Parameters.AddWithValue("idfaculty", faculty.Id);
                        command.ExecuteNonQuery();
                        UpdateFaculty("SELECT idfaculty, namefaculty,faculty.iddepartments," +
            " namedepartments FROM faculty LEFT JOIN departments USING(iddepartments);", 4);
                    }
                    else if (nameTable == "grouptable")
                    {
                        int pos = dataGridViewTable.Columns["idgroup"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Models.GroupTable group = groupTableList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM grouptable WHERE idgroup=@idgroup", conn);// Удаляем 
                        command.Parameters.AddWithValue("idgroup", group.Id);
                        command.ExecuteNonQuery();
                        UpdateGroupTable("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                    "idfaculty, namefaculty, iddepartments, namedepartments,idcurriculum,namecurriculum,qualification" +
                    " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN curriculum USING(idcurriculum);", 12);
                    }
                    else if (nameTable == "teacher")
                    {
                        int pos = dataGridViewTable.Columns["idteacher"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Teacher teacher = teacherList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM teacher WHERE idteacher=@idteacher", conn);// Удаляем 
                        command.Parameters.AddWithValue("idteacher", teacher.Id);
                        command.ExecuteNonQuery();
                        UpdateTeacher("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    " FROM teacher LEFT JOIN departments  USING(iddepartments);", 8);
                    }
                    else if (nameTable == "groups")
                    {
                        int pos = dataGridViewTable.Columns["id"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Groups groups = groupsList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM groups WHERE id=@id", conn);// Удаляем 
                        command.Parameters.AddWithValue("id", groups.Id);
                        command.ExecuteNonQuery();
                        UpdateGroups("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    " FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments);", 8);
                    }
                    else if (nameTable == "audiencefund")
                    {
                        int pos = dataGridViewTable.Columns["idaudiencefund"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        AudienceFund audienceFund = audienceFundList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM audiencefund WHERE idaudiencefund=@idaudiencefund", conn);// Удаляем 
                        command.Parameters.AddWithValue("idaudiencefund", audienceFund.Id);
                        command.ExecuteNonQuery();
                        UpdateAudienceFund("SELECT idaudiencefund," +
                    "iddepartments,namedepartments," +
                    "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                    " FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments);", 9);
                    }
                    else if (nameTable == "curriculum")
                    {
                        int pos = dataGridViewTable.Columns["idcurriculum"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Curriculum curriculum = curriculumList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM curriculum WHERE idcurriculum=@idcurriculum", conn);// Удаляем 
                        command.Parameters.AddWithValue("idcurriculum", curriculum.Id);
                        command.ExecuteNonQuery();
                        UpdateCurriculum("SELECT * FROM curriculum;", 3);

                    }
                    else if (nameTable == "curriculumdiscipline")
                    {
                        int pos = dataGridViewTable.Columns["idcurriculumdiscipline"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        CurriculumDiscipline curriculumDiscipline = curriculumDisciplinesList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM curriculumdiscipline WHERE idcurriculumdiscipline=@idcurriculumdiscipline", conn);// Удаляем 
                        command.Parameters.AddWithValue("idcurriculumdiscipline", curriculumDiscipline.Id);
                        command.ExecuteNonQuery();
                        UpdateCurriculumDiscipline("SELECT idcurriculumdiscipline,course,semester,hours," +
                    "idcurriculum,namecurriculum,qualification," +
                    "iddiscipline,namediscipline,typelesson" +
                    " FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline);", 10);
                    }
                    else if (nameTable == "headdepartment")
                    {
                        int pos = dataGridViewTable.Columns["idheaddepartment"].Index;// Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        HeadDepartment headDepartment = headDepartmentList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM headdepartment WHERE idheaddepartment=@idheaddepartment", conn);// Удаляем 
                        command.Parameters.AddWithValue("idheaddepartment", headDepartment.Id);
                        command.ExecuteNonQuery();
                        UpdateHeadDepartment("SELECT idheaddepartment," +
            "headdepartment.iddepartments,namedepartments," +
            "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
            "FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher);", 9);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (conn?.State == ConnectionState.Open)
            {
                insertPanel.Visible = true;
                insertPanel.BringToFront();
                panel2.Controls.Clear();
                try
                {

                    if (nameTable == "audience")
                    {
                        panel2.Controls.Add(new AudienceControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "timetable")
                    {

                    }
                    else if (nameTable == "departments")
                    {
                        panel2.Controls.Add(new DepartmentsControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "discipline")
                    {
                        panel2.Controls.Add(new DisciplineControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "faculty")
                    {
                        panel2.Controls.Add(new FacultyControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "grouptable")
                    {
                        panel2.Controls.Add(new GroupControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "teacher")
                    {
                        panel2.Controls.Add(new TeacherControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "groups")
                    {
                        panel2.Controls.Add(new GroupsControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "audiencefund")
                    {
                        panel2.Controls.Add(new AudienceFundControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "curriculum")
                    {
                        panel2.Controls.Add(new CurriculumControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "curriculumdiscipline")
                    {
                        panel2.Controls.Add(new CurriculumDisciplineControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }
                    else if (nameTable == "headdepartment")
                    {
                        panel2.Controls.Add(new HeadDepartmentControl(conn, this));
                        insertPanel.Width = 400;
                        insertPanel.Height = 400;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonPanelClose_Click(object sender, EventArgs e)
        {
            insertPanel.Visible = false;
            panel2.Controls.Clear();
        }
        private void dataGridViewTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (conn?.State == ConnectionState.Open)
            {
                if (nameTable == "audience")
                {
                    int pos = dataGridViewTable.Columns["typeaudience"].Index;
                    if (e.ColumnIndex == pos)
                    {
                        SelectOneControl selectOneControl = new SelectOneControl(conn, this, dataGridViewTable.Rows[e.RowIndex].Cells[pos], "typeaudience")
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectOneControl);
                        selectOneControl.BringToFront();
                    }
                }
                else if (nameTable == "timetable")
                {

                }
                else if (nameTable == "departments")
                {
                    int idaudience = dataGridViewTable.Columns["idaudience"].Index;

                    if (e.ColumnIndex == idaudience)
                    {
                        SelectControl selectControl = new SelectControl("SELECT * FROM audience;", 6, "idaudience", "audience",
                        dataGridViewTable.Rows[e.RowIndex].Cells[idaudience], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                }
                else if (nameTable == "discipline")
                {
                    int pos = dataGridViewTable.Columns["typelesson"].Index;
                    if (e.ColumnIndex == pos)
                    {
                        SelectOneControl selectOneControl = new SelectOneControl(conn, this, dataGridViewTable.Rows[e.RowIndex].Cells[pos], "typelesson")
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectOneControl);
                        selectOneControl.BringToFront();
                    }
                }
                else if (nameTable == "faculty")
                {
                    int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;

                    if (e.ColumnIndex == iddepartments)
                    {
                        SelectControl selectControl = new SelectControl("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6, "iddepartments", "departments",
                        dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                }
                else if (nameTable == "grouptable")
                {

                    int formeducation = dataGridViewTable.Columns["formeducation"].Index;
                    int idfaculty = dataGridViewTable.Columns["idfaculty"].Index;
                    int idcurriculum = dataGridViewTable.Columns["idcurriculum"].Index;

                    if (e.ColumnIndex == formeducation)
                    {
                        SelectOneControl selectOneControl = new SelectOneControl(conn, this, dataGridViewTable.Rows[e.RowIndex].Cells[formeducation], "formeducation")
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectOneControl);
                        selectOneControl.BringToFront();
                    }
                    else if (e.ColumnIndex == idfaculty)
                    {
                        SelectControl selectControl = new SelectControl("SELECT * FROM faculty;", 3, "idfaculty", "faculty",
                        dataGridViewTable.Rows[e.RowIndex].Cells[idfaculty], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                    else if (e.ColumnIndex == idcurriculum)
                    {
                        SelectControl selectControl = new SelectControl("SELECT * FROM curriculum;", 3, "idcurriculum", "curriculum",
                        dataGridViewTable.Rows[e.RowIndex].Cells[idcurriculum], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }

                }
                else if (nameTable == "teacher")
                {
                    int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;

                    if (e.ColumnIndex == iddepartments)
                    {
                        SelectControl selectControl = new SelectControl("SELECT " +
                    "departments.iddepartments,namedepartments," +
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6, "iddepartments", "departments",
                        dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                }
                else if (nameTable == "groups")
                {
                    int idgroup = dataGridViewTable.Columns["idgroup"].Index;

                    if (e.ColumnIndex == idgroup)
                    {
                        SelectControl selectControl = new SelectControl("SELECT * FROM grouptable;", 6, "idgroup", "grouptable",
                        dataGridViewTable.Rows[e.RowIndex].Cells[idgroup], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                }
                else if (nameTable == "audiencefund")
                {
                    int idaudience = dataGridViewTable.Columns["idaudience"].Index;
                    int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;
                    if (e.ColumnIndex == idaudience)
                    {
                        SelectControl selectControl = new SelectControl($"SELECT idaudience, nameaudience, address, typeaudience, capacity, traveltime FROM audience WHERE NOT EXISTS (SELECT * FROM audiencefund WHERE audience.idaudience = audiencefund.idaudience AND iddepartments ={dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments].Value});", 6, "idaudience", "audience",
                        dataGridViewTable.Rows[e.RowIndex].Cells[idaudience], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                }
                else if (nameTable == "curriculum")
                {
                    int qualification = dataGridViewTable.Columns["qualification"].Index;
                    if (e.ColumnIndex == qualification)
                    {
                        SelectOneControl selectOneControl = new SelectOneControl(conn, this, dataGridViewTable.Rows[e.RowIndex].Cells[qualification], "qualification")
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectOneControl);
                        selectOneControl.BringToFront();
                    }
                }
                else if (nameTable == "curriculumdiscipline")
                {
                    int iddiscipline = dataGridViewTable.Columns["iddiscipline"].Index;

                    if (e.ColumnIndex == iddiscipline)
                    {
                        SelectControl selectControl = new SelectControl("SELECT iddiscipline,namediscipline,typelesson FROM discipline;", 3, "iddiscipline", "discipline",
                        dataGridViewTable.Rows[e.RowIndex].Cells[iddiscipline], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }

                }
                else if (nameTable == "headdepartment")
                {
                    int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;
                    int idteacher = dataGridViewTable.Columns["idteacher"].Index;
                    /*    if (e.ColumnIndex == iddepartments)
                        {
                            SelectControl selectControl = new SelectControl(SqlStatic.departmentsSql, "iddepartments", "departments",
                            dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments], conn)
                            {
                                Name = "SelectControl",
                                Location = new Point(100, 100),
                            };
                            Controls.Add(selectControl);
                            selectControl.BringToFront();
                        }*/
                    if (e.ColumnIndex == idteacher)
                    {
                        SelectControl selectControl = new SelectControl("SELECT " +
                        "idteacher,lastname,nameteacher,patronymic,position,academicdegree,iddepartments" +
                        $" FROM teacher LEFT JOIN departments USING (iddepartments) WHERE iddepartments ='{dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments].Value}';",
                       5, "idteacher", "teacher",
                       dataGridViewTable.Rows[e.RowIndex].Cells[idteacher], conn)
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectControl);
                        selectControl.BringToFront();
                    }
                }

            }
        }



        private void dataGridViewTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (backup) { }
            else if (nameTable == "audience")
            {
                try
                {
                    Audience audience = Audience.GetAudience(GetValueDataGrid(e.RowIndex), Audience.OrderTitle); //Получаем изменения

                   // if (!SqlAssistant.CheckInfo($"SELECT idaudience FROM audience WHERE nameaudience ='{audience.Name}';", conn)) // Если не нашли
                   // {
                        int idFindNew = AudienceListUpdate.FindIndex(id => id.Id == audience.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            AudienceListUpdate[idFindNew].Name = audience.Name;
                            AudienceListUpdate[idFindNew].Address = audience.Address;
                            AudienceListUpdate[idFindNew].Type = audience.Type;
                            AudienceListUpdate[idFindNew].Capacity = audience.Capacity;
                            AudienceListUpdate[idFindNew].TravelTime = audience.TravelTime;
                            int idFindOld = audiencesList.FindIndex(id => id.Id == AudienceListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (AudienceListUpdate[idFindNew] == audiencesList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                AudienceListUpdate.RemoveAt(idFindNew);
                                //RowEditColor(e.RowIndex);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            AudienceListUpdate.Add(audience);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                   /* }
                    else
                    {
                        throw new Exception("Такая аудитория уже есть");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idaudience"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Audience audience = audiencesList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = audience.GetAudienceValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "timetable")
            {

            }
            else if (nameTable == "departments")
            {

                try
                {

                    Departments departments = Departments.GetDepartment(GetValueDataGrid(e.RowIndex), Departments.OrderTitle); //Получаем изменения
                   // if (!SqlAssistant.CheckInfo($"SELECT idaudience FROM departments WHERE namedepartments ='{departments.Name}';", conn)) // Если не нашли
                   // {
                        int idFindNew = DepartmentsListUpdate.FindIndex(id => id.Id == departments.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            DepartmentsListUpdate[idFindNew].Name = departments.Name;
                            DepartmentsListUpdate[idFindNew].Audience.Id = departments.Audience.Id;

                            int idFindOld = departmentsList.FindIndex(id => id.Id == DepartmentsListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (DepartmentsListUpdate[idFindNew] == departmentsList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                DepartmentsListUpdate.RemoveAt(idFindNew);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            DepartmentsListUpdate.Add(departments);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                        int idaudience = dataGridViewTable.Columns["idaudience"].Index;

                        if (e.ColumnIndex == idaudience)
                        {
                            string cmdText = "SELECT " +
                            "idaudience,nameaudience,address,typeaudience" +
                            $" FROM audience WHERE idaudience='{dataGridViewTable.Rows[e.RowIndex].Cells[idaudience].Value}';";
                            List<Audience> audiences = new List<Audience>();
                            List<string> title = new List<string>();
                            (audiences, title) = SqlAssistant.SelectAudience(cmdText, 4, conn);
                            if (audiences.Count > 0)
                            {
                                object[] obj = audiences[0].ConvertToObject(title);
                                backup = true;
                                for (int i = idaudience; i < idaudience + obj.Length; i++)
                                {
                                    dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - idaudience];

                                }
                                RowEditColor(e.RowIndex, idaudience, idaudience + obj.Length);
                                backup = false;
                            }
                        }
                  /*  }
                    else
                    {
                        throw new Exception("Такая кафедра уже есть");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["iddepartments"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Departments departments = departmentsList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = departments.GetDepartmentValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "discipline")
            {
                //MessageBox.Show(nameTable);
                // MessageBox.Show(nameTable);
                try
                {
                    Discipline discipline = Discipline.GetDiscipline(GetValueDataGrid(e.RowIndex), Discipline.OrderTitle); //Получаем изменения
                   // if (!SqlAssistant.CheckInfo($"SELECT iddiscipline FROM discipline WHERE namediscipline ='{discipline.Name}' AND typelesson ='{discipline.TypeLesson}'::typelesson;", conn)) // Если не нашли
                   // {
                        int idFindNew = DisciplineListUpdate.FindIndex(id => id.Id == discipline.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            DisciplineListUpdate[idFindNew].Name = discipline.Name;
                            DisciplineListUpdate[idFindNew].TypeLesson = discipline.TypeLesson;

                            int idFindOld = disciplinesList.FindIndex(id => id.Id == DisciplineListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (DisciplineListUpdate[idFindNew] == disciplinesList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                DisciplineListUpdate.RemoveAt(idFindNew);
                                //RowEditColor(e.RowIndex);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            DisciplineListUpdate.Add(discipline);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                  /*  }
                    else
                    {
                        throw new Exception("Такая дисциплина уже есть");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["iddiscipline"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Discipline discipline = disciplinesList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = discipline.GetDisciplineValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "faculty")
            {
                try
                {

                    Faculty faculty = Faculty.GetFaculty(GetValueDataGrid(e.RowIndex), Faculty.OrderTitle); //Получаем изменения
                    //if (!SqlAssistant.CheckInfo($"SELECT idfaculty FROM faculty WHERE namefaculty ='{faculty.Name}';", conn))
                   // {
                        int idFindNew = FacultyListUpdate.FindIndex(id => id.Id == faculty.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            FacultyListUpdate[idFindNew].Name = faculty.Name;
                            FacultyListUpdate[idFindNew].Departments.Id = faculty.Departments.Id;

                            int idFindOld = facultiesList.FindIndex(id => id.Id == FacultyListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (FacultyListUpdate[idFindNew] == facultiesList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                FacultyListUpdate.RemoveAt(idFindNew);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            FacultyListUpdate.Add(faculty);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                        int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;

                        if (e.ColumnIndex == iddepartments)
                        {
                            string cmdText = "SELECT " +
                            "iddepartments,namedepartments" +
                            $" FROM departments WHERE iddepartments='{dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments].Value}';";
                            List<Departments> departments = new List<Departments>();
                            List<string> title = new List<string>();
                            (departments, title) = SqlAssistant.SelectDepartments(cmdText, 2, conn);
                            if (departments.Count > 0)
                            {
                                object[] obj = departments[0].ConvertToObject(title);
                                backup = true;
                                for (int i = iddepartments; i < iddepartments + obj.Length; i++)
                                {
                                    dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - iddepartments];

                                }
                                RowEditColor(e.RowIndex, iddepartments, iddepartments + obj.Length);
                                backup = false;
                            }
                        }
                  /*  }
                    else
                    {
                        throw new Exception("Такой факультет уже есть");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idfaculty"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Faculty faculty = facultiesList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = faculty.GetFacultyValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "grouptable")
            {
                try
                {
                    GroupTable groupTable = GroupTable.GetGroupTable(GetValueDataGrid(e.RowIndex), GroupTable.OrderTitle); //Получаем изменения
                                                                                                                           // if (!SqlAssistant.CheckInfo($"SELECT idgroup FROM groupTable WHERE namegroup ='{groupTable.Name}';", conn))
                                                                                                                           // {
                    int idFindNew = GroupTableListUpdate.FindIndex(id => id.Id == groupTable.Id); // Если нашли в списке для обновленмй
                    if (idFindNew > -1)
                    {// То обновляем данные 
                        GroupTableListUpdate[idFindNew].Name = groupTable.Name;
                        GroupTableListUpdate[idFindNew].Faculty.Id = groupTable.Faculty.Id;
                        GroupTableListUpdate[idFindNew].Formeducation = groupTable.Formeducation;
                        GroupTableListUpdate[idFindNew].RecruitmentYear = groupTable.RecruitmentYear;
                        GroupTableListUpdate[idFindNew].Amount = groupTable.Amount;
                        GroupTableListUpdate[idFindNew].Curriculum.Id = groupTable.Curriculum.Id;
                        int idFindOld = groupTableList.FindIndex(id => id.Id == GroupTableListUpdate[idFindNew].Id);// Преверяем внесенные данные
                        if (GroupTableListUpdate[idFindNew] == groupTableList[idFindOld])// Если данные вернулись к первоначальным 
                        { //То удаляем из списка для обновлений
                            GroupTableListUpdate.RemoveAt(idFindNew);
                            //RowEditColor(e.RowIndex);
                            RowEditBackupColor(e.RowIndex);
                        }
                    }
                    else// Если не нашли
                    {// То добавляем данные 
                        GroupTableListUpdate.Add(groupTable);
                        dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                    }

                    int idfaculty = dataGridViewTable.Columns["idfaculty"].Index;
                    int idcurriculum = dataGridViewTable.Columns["idcurriculum"].Index;

                    if (e.ColumnIndex == idfaculty)
                    {
                        string cmdText = "SELECT " +
                        "idfaculty,namefaculty,iddepartments,namedepartments" +
                        $" FROM faculty LEFT JOIN departments USING(iddepartments) WHERE idfaculty='{dataGridViewTable.Rows[e.RowIndex].Cells[idfaculty].Value}';";
                        List<Faculty> faculties = new List<Faculty>();
                        List<string> title = new List<string>();
                        (faculties, title) = SqlAssistant.SelectFaculty(cmdText, 4, conn);
                        if (faculties.Count > 0)
                        {
                            object[] obj = faculties[0].ConvertToObject(title);
                            backup = true;
                            for (int i = idfaculty; i < idfaculty + obj.Length; i++)
                            {
                                dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - idfaculty];

                            }
                            RowEditColor(e.RowIndex, idfaculty, idfaculty + obj.Length);
                            backup = false;
                        }
                    }
                    else if (e.ColumnIndex == idcurriculum)
                    {
                        string cmdText = "SELECT " +
                        "idcurriculum,namecurriculum,qualification" +
                        $" FROM curriculum WHERE idcurriculum='{dataGridViewTable.Rows[e.RowIndex].Cells[idcurriculum].Value}';";
                        List<Curriculum> curriculum = new List<Curriculum>();
                        List<string> title = new List<string>();
                        (curriculum, title) = SqlAssistant.SelectCurriculum(cmdText, 3, conn);
                        if (curriculum.Count > 0)
                        {
                            object[] obj = curriculum[0].ConvertToObject(title);
                            backup = true;
                            for (int i = idcurriculum; i < idcurriculum + obj.Length; i++)
                            {
                                dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - idcurriculum];

                            }
                            RowEditColor(e.RowIndex, idcurriculum, idcurriculum + obj.Length);
                            backup = false;
                        }
                    }
                    /* }
                     else
                     {
                         throw new Exception("Такая группа уже есть");
                     }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idgroup"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    GroupTable groupTable = groupTableList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = groupTable.GetGroupTableValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "teacher")
            {
                try
                {

                    Teacher teacher = Teacher.GetTeacher(GetValueDataGrid(e.RowIndex), Teacher.OrderTitle); //Получаем изменения
                    int idFindNew = TeacherListUpdate.FindIndex(id => id.Id == teacher.Id); // Если нашли в списке для обновленмй
                    if (idFindNew > -1)
                    {// То обновляем данные 
                        TeacherListUpdate[idFindNew].Departments.Id = teacher.Departments.Id;
                        TeacherListUpdate[idFindNew].LastName = teacher.LastName;
                        TeacherListUpdate[idFindNew].Name = teacher.Name;
                        TeacherListUpdate[idFindNew].Patronymic = teacher.Patronymic;
                        TeacherListUpdate[idFindNew].Position = teacher.Position;
                        TeacherListUpdate[idFindNew].AcademicDegree = teacher.AcademicDegree;

                        int idFindOld = teacherList.FindIndex(id => id.Id == TeacherListUpdate[idFindNew].Id);// Преверяем внесенные данные
                        if (TeacherListUpdate[idFindNew] == teacherList[idFindOld])// Если данные вернулись к первоначальным 
                        { //То удаляем из списка для обновлений
                            TeacherListUpdate.RemoveAt(idFindNew);
                            RowEditBackupColor(e.RowIndex);
                        }
                    }
                    else// Если не нашли
                    {// То добавляем данные 
                        TeacherListUpdate.Add(teacher);
                        dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                    }

                    int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;

                    if (e.ColumnIndex == iddepartments)
                    {
                        string cmdText = "SELECT " +
                        "iddepartments,namedepartments" +
                        $" FROM departments WHERE iddepartments='{dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments].Value}';";
                        List<Departments> departments = new List<Departments>();
                        List<string> title = new List<string>();
                        (departments, title) = SqlAssistant.SelectDepartments(cmdText, 2, conn);
                        if (departments.Count > 0)
                        {
                            object[] obj = departments[0].ConvertToObject(title);
                            backup = true;
                            for (int i = iddepartments; i < iddepartments + obj.Length; i++)
                            {
                                dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - iddepartments];

                            }
                            RowEditColor(e.RowIndex, iddepartments, iddepartments + obj.Length);
                            backup = false;
                        }
                    }
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idteacher"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Teacher teacher = teacherList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = teacher.GetTeacherValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "groups")
            {
                try
                {

                    Groups groups = Groups.GetGroup(GetValueDataGrid(e.RowIndex), Groups.OrderTitle); //Получаем изменения
                   // if (!SqlAssistant.CheckInfo($"SELECT id FROM groups WHERE idgroups ='{groups.IdGroups}' AND idgroup ='{groups.Group.Id}';", conn)) // Если не нашли
                   // {
                        int idFindNew = GroupsListUpdate.FindIndex(id => id.Id == groups.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            GroupsListUpdate[idFindNew].Group.Id = groups.Group.Id;

                            int idFindOld = groupsList.FindIndex(id => id.Id == GroupsListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (GroupsListUpdate[idFindNew] == groupsList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                GroupsListUpdate.RemoveAt(idFindNew);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            GroupsListUpdate.Add(groups);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                        int idgroup = dataGridViewTable.Columns["idgroup"].Index;

                        if (e.ColumnIndex == idgroup)
                        {
                            string cmdText = "SELECT " +
                            "idgroup,namegroup,idfaculty,namefaculty,iddepartments,namedepartments" +
                            $" FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments)  WHERE idgroup='{dataGridViewTable.Rows[e.RowIndex].Cells[idgroup].Value}';";
                            List<GroupTable> groupTable = new List<GroupTable>();
                            List<string> title = new List<string>();
                            (groupTable, title) = SqlAssistant.SelectGroup(cmdText, 6, conn);
                            if (groupTable.Count > 0)
                            {
                                object[] obj = groupTable[0].ConvertToObject(title);
                                backup = true;
                                for (int i = idgroup; i < idgroup + obj.Length; i++)
                                {
                                    dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - idgroup];

                                }
                                RowEditColor(e.RowIndex, idgroup, idgroup + obj.Length);
                                backup = false;
                            }
                        }
                  /*  }
                    else
                    {
                        throw new Exception("Такой поток уже есть");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["id"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Groups groups = groupsList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = groups.GetGroupsValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "audiencefund")
            {
                try
                {

                    AudienceFund audienceFund = AudienceFund.GetAudienceFund(GetValueDataGrid(e.RowIndex), AudienceFund.OrderTitle); //Получаем изменения
                 //   if (!SqlAssistant.CheckInfo($"SELECT idaudiencefund FROM audienceFund WHERE iddepartments ='{audienceFund.Departments.Id}' AND idaudience ='{audienceFund.Audience.Id}';", conn)) // Если не нашли
                 //   {
                        int idFindNew = AudienceFundListUpdate.FindIndex(id => id.Id == audienceFund.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            AudienceFundListUpdate[idFindNew].Audience.Id = audienceFund.Audience.Id;

                            int idFindOld = audienceFundList.FindIndex(id => id.Id == AudienceFundListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (AudienceFundListUpdate[idFindNew] == audienceFundList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                AudienceFundListUpdate.RemoveAt(idFindNew);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            AudienceFundListUpdate.Add(audienceFund);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                        int idaudience = dataGridViewTable.Columns["idaudience"].Index;

                        if (e.ColumnIndex == idaudience)
                        {
                            string cmdText = "SELECT " +
                            "idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                            $" FROM audience WHERE idaudience='{dataGridViewTable.Rows[e.RowIndex].Cells[idaudience].Value}';";
                            List<Audience> audiences = new List<Audience>();
                            List<string> title = new List<string>();
                            (audiences, title) = SqlAssistant.SelectAudience(cmdText, 6, conn);
                            if (audiences.Count > 0)
                            {
                                object[] obj = audiences[0].ConvertToObject(title);
                                backup = true;
                                for (int i = idaudience; i < idaudience + obj.Length; i++)
                                {
                                    dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - idaudience];

                                }
                                RowEditColor(e.RowIndex, idaudience, idaudience + obj.Length);
                                backup = false;
                            }
                        }
                   /* }
                    else
                    {
                        throw new Exception("Такая аудитория уже есть");

                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idaudiencefund"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    AudienceFund audienceFund = audienceFundList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = audienceFund.GetAudienceFundValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "curriculum")
            {
                try
                {
                    Curriculum curriculum = Curriculum.GetCurriculum(GetValueDataGrid(e.RowIndex), Curriculum.OrderTitle); //Получаем изменения
                  //  if (!SqlAssistant.CheckInfo($"SELECT idcurriculum FROM curriculum WHERE namecurriculum ='{curriculum.Name}' AND qualification='{curriculum.Qualification}';", conn)) // Если не нашли
                  //  {
                        int idFindNew = CurriculumListUpdate.FindIndex(id => id.Id == curriculum.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            CurriculumListUpdate[idFindNew].Name = curriculum.Name;
                            CurriculumListUpdate[idFindNew].Qualification = curriculum.Qualification;

                            int idFindOld = curriculumList.FindIndex(id => id.Id == CurriculumListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (CurriculumListUpdate[idFindNew] == curriculumList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                CurriculumListUpdate.RemoveAt(idFindNew);
                                //RowEditColor(e.RowIndex);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            CurriculumListUpdate.Add(curriculum);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }
                  /*  }
                    else
                    {
                        MessageBox.Show("Такой учебный план уже есть");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idcurriculum"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Curriculum curriculum = curriculumList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = curriculum.GetCurriculumValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "curriculumdiscipline")
            {
                try
                {

                    CurriculumDiscipline curriculumDiscipline = CurriculumDiscipline.GetCurriculumDiscipline(GetValueDataGrid(e.RowIndex), CurriculumDiscipline.OrderTitle); //Получаем изменения
                   // if (!SqlAssistant.CheckInfo($"SELECT idcurriculumdiscipline FROM curriculumdiscipline WHERE idcurriculum ='{curriculumDiscipline.Curriculum.Id}' AND iddiscipline ='{curriculumDiscipline.Discipline.Id}'AND course ='{curriculumDiscipline.Course}'AND semester ='{curriculumDiscipline.Semester}';", conn)) // Если не нашли
                   // {
                        int idFindNew = CurriculumDisciplineListUpdate.FindIndex(id => id.Id == curriculumDiscipline.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                            CurriculumDisciplineListUpdate[idFindNew].Curriculum.Id = curriculumDiscipline.Curriculum.Id;
                            CurriculumDisciplineListUpdate[idFindNew].Discipline.Id = curriculumDiscipline.Discipline.Id;
                            CurriculumDisciplineListUpdate[idFindNew].Course = curriculumDiscipline.Course;
                            CurriculumDisciplineListUpdate[idFindNew].Semester = curriculumDiscipline.Semester;
                            CurriculumDisciplineListUpdate[idFindNew].Hours = curriculumDiscipline.Hours;

                            int idFindOld = curriculumDisciplinesList.FindIndex(id => id.Id == CurriculumDisciplineListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (CurriculumDisciplineListUpdate[idFindNew] == curriculumDisciplinesList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                CurriculumDisciplineListUpdate.RemoveAt(idFindNew);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            CurriculumDisciplineListUpdate.Add(curriculumDiscipline);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }

                        int iddiscipline = dataGridViewTable.Columns["iddiscipline"].Index;

                        if (e.ColumnIndex == iddiscipline)
                        {
                            string cmdText = "SELECT " +
                            "iddiscipline,namediscipline,typelesson" +
                            $" FROM discipline WHERE iddiscipline='{dataGridViewTable.Rows[e.RowIndex].Cells[iddiscipline].Value}';";
                            List<Discipline> disciplines = new List<Discipline>();
                            List<string> title = new List<string>();
                            (disciplines, title) = SqlAssistant.SelectDiscipline(cmdText, 3, conn);
                            if (disciplines.Count > 0)
                            {
                                object[] obj = disciplines[0].ConvertToObject(title);
                                backup = true;
                                for (int i = iddiscipline; i < iddiscipline + obj.Length; i++)
                                {
                                    dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - iddiscipline];

                                }
                                RowEditColor(e.RowIndex, iddiscipline, iddiscipline + obj.Length);
                                backup = false;
                            }
                        }
                   /* }
                    else
                    {
                        throw new Exception("Такая дисциплина уже есть в учебном плане");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idcurriculumdiscipline"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    CurriculumDiscipline curriculumDiscipline = curriculumDisciplinesList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = curriculumDiscipline.GetCurriculumDisciplineValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }
            else if (nameTable == "headdepartment")
            {
                try
                {

                    HeadDepartment headDepartment = HeadDepartment.GetHeadDepartment(GetValueDataGrid(e.RowIndex), HeadDepartment.OrderTitle); //Получаем изменения
                  //  if (!SqlAssistant.CheckInfo($"SELECT idheadDepartment FROM headdepartment WHERE iddepartments ='{headDepartment.Department.Id}' AND idteacher ='{headDepartment.Teacher.Id}';", conn)) // Если не нашли
                 //   {
                        int idFindNew = HeadDepartmentListUpdate.FindIndex(id => id.Id == headDepartment.Id); // Если нашли в списке для обновленмй
                        if (idFindNew > -1)
                        {// То обновляем данные 
                         //HeadDepartmentListUpdate[idFindNew].Department.Id = headDepartment.Department.Id;
                            HeadDepartmentListUpdate[idFindNew].Teacher.Id = headDepartment.Teacher.Id;

                            int idFindOld = headDepartmentList.FindIndex(id => id.Id == HeadDepartmentListUpdate[idFindNew].Id);// Преверяем внесенные данные
                            if (HeadDepartmentListUpdate[idFindNew] == headDepartmentList[idFindOld])// Если данные вернулись к первоначальным 
                            { //То удаляем из списка для обновлений
                                HeadDepartmentListUpdate.RemoveAt(idFindNew);
                                RowEditBackupColor(e.RowIndex);
                            }
                        }
                        else// Если не нашли
                        {// То добавляем данные 
                            HeadDepartmentListUpdate.Add(headDepartment);
                            dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.InfoText;
                        }

                        int iddepartments = dataGridViewTable.Columns["iddepartments"].Index;
                        int idteacher = dataGridViewTable.Columns["idteacher"].Index;

                        /* if (e.ColumnIndex == iddepartments)
                         {
                             string cmdText = "SELECT " +
                             "iddepartments,namedepartments" +
                             $" FROM departments WHERE iddepartments='{dataGridViewTable.Rows[e.RowIndex].Cells[iddepartments].Value}';";
                             List<Departments> departments = new List<Departments>();
                             List<string> title = new List<string>();
                             (departments, title) = SqlAssistant.SelectDepartments(cmdText, 2, conn);
                             if (departments.Count > 0)
                             {
                                 object[] obj = departments[0].ConvertToObject(title);
                                 backup = true;
                                 for (int i = iddepartments; i < iddepartments + obj.Length; i++)
                                 {
                                     dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - iddepartments];

                                 }
                                 RowEditColor(e.RowIndex, iddepartments, iddepartments + obj.Length);
                                 backup = false;
                             }
                         }*/
                        if (e.ColumnIndex == idteacher)
                        {
                            string cmdText = "SELECT " +
                            "idteacher,lastname,nameteacher,patronymic,position,academicdegree" +
                            $" FROM teacher WHERE idteacher='{dataGridViewTable.Rows[e.RowIndex].Cells[idteacher].Value}';";
                            List<Teacher> teacher = new List<Teacher>();
                            List<string> title = new List<string>();
                            (teacher, title) = SqlAssistant.SelectTeacher(cmdText, 6, conn);
                            if (teacher.Count > 0)
                            {
                                object[] obj = teacher[0].ConvertToObject(title);
                                backup = true;
                                for (int i = idteacher; i < idteacher + obj.Length; i++)
                                {
                                    dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = obj[i - idteacher];

                                }
                                RowEditColor(e.RowIndex, idteacher, idteacher + obj.Length);
                                backup = false;
                            }

                        }
                 /*   }
                    else
                    {
                        throw new Exception("Зав кафедры уже есть такой");
                    }*/
                }
                catch (Exception ex)// Если произошла ошибка в введенных данных либо другая причина
                { // То восстанавливаем данные 
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idheaddepartment"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    HeadDepartment headDepartment = headDepartmentList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = headDepartment.GetHeadDepartmentValue(dataGridViewTable.Columns[i].Name);
                    }
                    RowEditBackupColor(e.RowIndex);
                    backup = false;
                }
            }

        }

        private void RowEditColor(int rowIndex, int columnRow, int columnRowEnd)
        {
            for (int i = columnRow; i < columnRowEnd; i++)
            {
                dataGridViewTable.Rows[rowIndex].Cells[i].Style.BackColor = SystemColors.ControlDark;

            }
        }
        private void RowEditBackupColor(int rowIndex)
        {

            for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
            {
                dataGridViewTable.Rows[rowIndex].Cells[i].Style.BackColor = SystemColors.ControlDark;

            }

        }


    }
}
