using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Timetable.Controller;
using Timetable.Forms;
using Timetable.Models;

namespace Timetable.Controls
{
    public partial class SelectControl : UserControl
    {
        private string selectSql;
        private string idSelect;
        private List<string> Selects;
        private string nameTable;
        private TextBox textBox;
        private DataGridViewCell data;
        private NpgsqlConnection conn;
        private int countTitle;

        private TimetableSet timetable;

        public SelectControl(string selectSql, int countTitle, string idSelect, string nameTable, TextBox textBox, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.selectSql = selectSql;
            this.idSelect = idSelect;
            this.textBox = textBox;
            this.nameTable = nameTable;
            this.conn = conn;
            this.countTitle = countTitle;
            if (nameTable == "audience")
            {
                UpdateAudience(selectSql, countTitle);
            }
            else if (nameTable == "teacher")
            {
                UpdateTeacher(selectSql, countTitle);
            }
            else if (nameTable == "departments")
            {
                UpdateDepartments(selectSql, countTitle);
            }
            else if (nameTable == "group")
            {
                UpdateGroup(selectSql, countTitle);
            }
            else if (nameTable == "groups")
            {
                UpdateGroups(selectSql, countTitle);
            }
            else if (nameTable == "curriculum")
            {
                UpdateCurriculum(selectSql, countTitle);
            }
            else if (nameTable == "curriculumdiscipline")
            {
                UpdateCurriculumDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "discipline")
            {
                UpdateDiscipline(selectSql, countTitle);
            }

        }


        public SelectControl(string selectSql, int countTitle, string idSelect, string nameTable, DataGridViewCell data, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.selectSql = selectSql;
            this.idSelect = idSelect;
            this.data = data;
            this.nameTable = nameTable;
            this.conn = conn;
            this.countTitle = countTitle;
            if (nameTable == "audience")
            {
                UpdateAudience(selectSql, countTitle);
            }
            if (nameTable == "teacher")
            {
                UpdateTeacher(selectSql, countTitle);
            }
            else if (nameTable == "departments")
            {
                UpdateDepartments(selectSql, countTitle);
            }
            else if (nameTable == "grouptable")
            {
                UpdateGroup(selectSql, countTitle);
            }
            else if (nameTable == "groups")
            {
                UpdateGroups(selectSql, countTitle);
            }
            else if (nameTable == "curriculum")
            {
                UpdateCurriculum(selectSql, countTitle);
            }
            else if (nameTable == "curriculumdiscipline")
            {
                UpdateCurriculumDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "discipline")
            {
                UpdateDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "faculty")
            {
                UpdateFaculty(selectSql, countTitle);
            }
        }

        public SelectControl(string selectSql, int countTitle, List<string> Selects, string nameTable, TimetableSet timetable, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.selectSql = selectSql;
            this.Selects = Selects;
            this.timetable = timetable;
            this.nameTable = nameTable;
            this.conn = conn;
            this.countTitle = countTitle;
            if (nameTable == "audience")
            {
                UpdateAudience(selectSql, countTitle);
            }
            if (nameTable == "teacher")
            {
                UpdateTeacher(selectSql, countTitle);
            }
            else if (nameTable == "departments")
            {
                UpdateDepartments(selectSql, countTitle);
            }
            else if (nameTable == "grouptable")
            {
                UpdateGroup(selectSql, countTitle);
            }
            else if (nameTable == "groups")
            {
                UpdateGroups(selectSql, countTitle);
            }
            else if (nameTable == "curriculum")
            {
                UpdateCurriculum(selectSql, countTitle);
            }
            else if (nameTable == "curriculumdiscipline")
            {
                UpdateCurriculumDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "discipline")
            {
                UpdateDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "faculty")
            {
                UpdateFaculty(selectSql, countTitle);
            }
        }

        public SelectControl(string selectSql, int countTitle, string idSelect, string nameTable, TimetableSet timetable, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.selectSql = selectSql;
            this.idSelect = idSelect;
            this.timetable = timetable;
            this.nameTable = nameTable;
            this.conn = conn;
            this.countTitle = countTitle;
            if (nameTable == "audience")
            {
                UpdateAudience(selectSql, countTitle);
            }
            if (nameTable == "teacher")
            {
                UpdateTeacher(selectSql, countTitle);
            }
            else if (nameTable == "departments")
            {
                UpdateDepartments(selectSql, countTitle);
            }
            else if (nameTable == "grouptable")
            {
                UpdateGroup(selectSql, countTitle);
            }
            else if (nameTable == "groups")
            {
                UpdateGroups(selectSql, countTitle);
            }
            else if (nameTable == "curriculum")
            {
                UpdateCurriculum(selectSql, countTitle);
            }
            else if (nameTable == "curriculumdiscipline")
            {
                UpdateCurriculumDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "discipline")
            {
                UpdateDiscipline(selectSql, countTitle);
            }
            else if (nameTable == "faculty")
            {
                UpdateFaculty(selectSql, countTitle);
            }
        }

        public void ClearDataGrid()
        {
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
        }
        public void UpdateAudience(string cmdText, int countTitle) // Функция для обновления таблицы Аудиторий
        {
            ClearDataGrid(); // очистка таблицы
            List<Audience> audiencesList = new List<Audience>();

            List<string> title = new List<string>(); // масив заголовков 
            (audiencesList, title) = SqlAssistant.SelectAudience(cmdText, countTitle, conn); // Функция для получения ВСЕХ значений

            // Данная функция нужна для правильного присвоения данных. Например можно выбрать
            // SELECT nameaudience, address FROM audience; и также  SELECT address, nameaudience FROM audience;
            // Программа в любом случае правильно считает данные для класса.
            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Audience.Title[item]); // Добавляем заголовки
                if (item.IndexOf("id") > -1)
                {
                    dataGridViewTable.Columns[dataGridViewTable.Columns.Count - 1].ReadOnly = true;// Ставим запрет на редактирования id
                }
            }

            for (int i = 0; i < audiencesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(audiencesList[i].ConvertToObject(title)); // Добавляем данные в таблицу
            }
        }
        public void UpdateTeacher(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<Teacher> teacherList = new List<Teacher>();
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

        private void UpdateDepartments(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();

            List<Departments> departmentsList = new List<Departments>();
            (departmentsList, title) = SqlAssistant.SelectDepartments(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Departments.Title[item]);
            }

            for (int i = 0; i < departmentsList.Count; i++)
            {
                dataGridViewTable.Rows.Add(departmentsList[i].ConvertToObject(title));
            }
        }

        private void UpdateGroup(string cmdText, int countTitle)
        {
            ClearDataGrid();
            List<GroupTable> groupList = new List<GroupTable>();
            List<string> title = new List<string>();
            (groupList, title) = SqlAssistant.SelectGroup(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Models.GroupTable.Title[item]);
            }

            for (int i = 0; i < groupList.Count; i++)
            {
                dataGridViewTable.Rows.Add(groupList[i].ConvertToObject(title));
            }
        }

        private void UpdateGroups(string cmdText, int countTitle)
        {
            ClearDataGrid();
            List<Groups> groupsList = new List<Groups>();

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

        public void UpdateCurriculum(string cmdText, int countTitle)
        {
            ClearDataGrid();
            List<Curriculum> curriculaList = new List<Curriculum>();

            List<string> title = new List<string>();
            (curriculaList, title) = SqlAssistant.SelectCurriculum(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Curriculum.Title[item]);
            }

            for (int i = 0; i < curriculaList.Count; i++)
            {
                dataGridViewTable.Rows.Add(curriculaList[i].ConvertToObject(title));
            }
        }

        private void UpdateDiscipline(string cmdText, int countTitle)
        {
            ClearDataGrid();
            List<Discipline> disciplinesList = new List<Discipline>();

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

        public void UpdateFaculty(string cmdText, int countTitle)
        {
            ClearDataGrid();
            List<Faculty> facultiesList = new List<Faculty>();

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

        public void UpdateCurriculumDiscipline(string cmdText, int countTitle)
        {
            ClearDataGrid();
            List<CurriculumDiscipline> curriculumDisciplinesList = new List<CurriculumDiscipline>();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            Visible = false;
            Dispose();

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
        private void dataGridViewTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (idSelect != null)
                {
                    int pos = dataGridViewTable.Columns[idSelect].Index;// Ищем позицию id
                    if (pos > -1)
                    {
                        int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value); // Получаем index 
                        if (textBox != null)
                        {
                            textBox.Text = index.ToString();
                        }
                        else if (data != null)
                        {
                            data.Value = index.ToString();
                        }
                    }
                }
                if (nameTable == "grouptable" && timetable != null)
                {
                    GroupTable groupTable = GroupTable.GetGroupTable(GetValueDataGrid(e.RowIndex), GroupTable.OrderTitle);
                    timetable.GroupTable = groupTable;

                }


                Visible = false;
                //timetable.ControlDelete(Name);
                Dispose();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nameTable == "audience")
                {
                    UpdateAudience($"SELECT * FROM audience WHERE nameaudience ~*'{txtSearch.Text.Trim()}' OR address ~*'{txtSearch.Text.Trim()}'", 6);
                }
                else if (nameTable == "timetable")
                {

                }
                else if (nameTable == "departments")
                {
                    UpdateDepartments("SELECT " +
                "departments.iddepartments,namedepartments," +
                "idaudience,nameaudience,address,typeaudience " +
                $"FROM departments LEFT JOIN audience USING(idaudience) WHERE namedepartments ~*'{txtSearch.Text.Trim()}'", 6);
                }
                else if (nameTable == "discipline")
                {
                    UpdateDiscipline($"SELECT * FROM discipline WHERE namediscipline ~*'{txtSearch.Text.Trim()}';", 3);


                }

                else if (nameTable == "faculty")
                {
                    UpdateFaculty("SELECT idfaculty, namefaculty,faculty.iddepartments," +
        $" namedepartments FROM faculty LEFT JOIN departments USING(iddepartments) WHERE namefaculty ~*'{txtSearch.Text.Trim()}';", 4);
                }
                else if (nameTable == "grouptable")
                {
                    /*  UpdateGroupTable("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                     "idfaculty, namefaculty, iddepartments, namedepartments" +
                     $" FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) WHERE namegroup ~*'{SearchTextBox.Text.Trim()}' OR namefaculty ~*'{SearchTextBox.Text.Trim()}';", 9);
                      */
                }
                else if (nameTable == "teacher")
                {

                    UpdateTeacher("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    $" FROM teacher LEFT JOIN departments  USING(iddepartments) WHERE lastname ~*'{txtSearch.Text.Trim()}' OR nameteacher ~*'{txtSearch.Text.Trim()}' OR namedepartments ~*'{txtSearch.Text.Trim()}';", 8);
                }
                else if (nameTable == "groups")
                {
                    UpdateGroups("SELECT id,idgroups," +
                "idgroup,namegroup," +
                "idfaculty,namefaculty," +
                "iddepartments,namedepartments" +
                $" FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments) WHERE namegroup ~*'{txtSearch.Text.Trim()}';", 8);
                }
                else if (nameTable == "audiencefund")
                {
                    /*
                    UpdateAudienceFund("SELECT idaudiencefund," +
                    "iddepartments,namedepartments," +
                    "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                    $" FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments) WHERE namedepartments ~*'{SearchTextBox.Text.Trim()}' OR nameaudience ~*'{SearchTextBox.Text.Trim()}';", 9);
                */
                }
                else if (nameTable == "curriculum")
                {
                    UpdateCurriculum($"SELECT * FROM curriculum WHERE namecurriculum ~*'{txtSearch.Text.Trim()}';", 3);
                }
                else if (nameTable == "curriculumdiscipline")
                {
                    /*
                    UpdateCurriculumDiscipline("SELECT idcurriculumdiscipline,course,semester,hours," +
                    "idcurriculum,namecurriculum,qualification," +
                    "iddiscipline,namediscipline,typelesson" +
                    $" FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline) WHERE namecurriculum ~*'{SearchTextBox.Text.Trim()} OR namediscipline ~*'{SearchTextBox.Text.Trim()}';", 10);
                */
                }
                else if (nameTable == "headdepartment")
                {
                    /*
                   UpdateHeadDepartment("SELECT idheaddepartment," +
                   "headdepartment.iddepartments,namedepartments," +
                   "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
                   $"FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher) WHERE namedepartments ~*'{SearchTextBox.Text.Trim()}' OR lastname ~*'{SearchTextBox.Text.Trim()}' OR nameteacher ~*'{SearchTextBox.Text.Trim()}';", 9);
                */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void dataGridViewTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
