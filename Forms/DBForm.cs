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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
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
        private List<Departments> departments;
        private List<Discipline> discipline;
        private List<AudienceFund> audienceFund;
        private List<Teacher> teacher;
        private List<Faculty> faculties;
        private List<Models.Group> group;
        private List<Groups> groups;
        private List<Models.Timetable> timetables;

        public DBForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

        }


        private Tuple<object[], List<string>> GetValue(NpgsqlDataReader reader, int count)
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

        private Tuple<List<object[]>, List<string>> SelectAll(string cmdText, int count)
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

        public List<string> SelectOne(string cmdText)
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

        public void ClearDataGrid()
        {
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
        }

        public void UpdateAudience(string cmdText) // Функция для обновления таблицы Аудиторий
        {
            ClearDataGrid(); // очистка таблицы

            List<object[]> obj = new List<object[]>(); // массив значений
            List<string> title = new List<string>(); // масив заголовков 
            (obj, title) = SelectAll(cmdText, Audience.Title.Count); // Функция для получения ВСЕХ значений

            audiencesList = new List<Audience>(Audience.GetAudiences(obj, title)); // Функция получения из объектов класс Audience
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

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]); // Добавляем данные в таблицу
            }
        }

        private void UpdateDepartments(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Departments.Title.Count);


            departments = new List<Departments>(Departments.GetDepartments(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Departments.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateDiscipline(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Discipline.Title.Count);


            discipline = new List<Discipline>(Discipline.GetDisciplines(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Discipline.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateAudienceFund(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, AudienceFund.Title.Count - 2);


            audienceFund = new List<AudienceFund>(AudienceFund.GetAudiencesFund(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, AudienceFund.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateTeacher(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Teacher.Title.Count);


            teacher = new List<Teacher>(Teacher.GetTeachers(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Teacher.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateFaculty(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Faculty.Title.Count);


            faculties = new List<Faculty>(Faculty.GetFaculties(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Faculty.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateGroup(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Models.Group.Title.Count);


            group = new List<Models.Group>(Models.Group.GetGroups(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Models.Group.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateGroups(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Groups.Title.Count);


            groups = new List<Groups>(Groups.GetGroups(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Groups.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void UpdateTimeTable(string cmdText)
        {
            ClearDataGrid();

            List<object[]> obj = new List<object[]>();
            List<string> title = new List<string>();
            (obj, title) = SelectAll(cmdText, Models.Timetable.Title.Count);


            timetables = new List<Models.Timetable>(Models.Timetable.GetTimetables(obj, title));

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Models.Timetable.Title[item]);
            }

            for (int i = 0; i < obj.Count; i++)
            {
                dataGridViewTable.Rows.Add(obj[i]);
            }
        }

        private void audienceButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateAudience("SELECT * FROM audience;");
                nameTable = "audience";
            }

        }

        private void timetableButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateTimeTable("SELECT grouptable.namegroup,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience;");
                nameTable = "timetable";
            }
        }

        private void departmentsButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateDepartments("SELECT * FROM departments;");
                nameTable = "departments";
            }
        }

        private void disciplineButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateDiscipline("SELECT * FROM discipline;");
                nameTable = "discipline";
            }
        }

        private void facultyButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateFaculty("SELECT * FROM faculty NATURAL JOIN departments;");
                nameTable = "faculty";
            }
        }

        private void groupTableButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateGroup("SELECT * FROM grouptable NATURAL JOIN faculty NATURAL JOIN departments;");
                nameTable = "grouptable";
            }
        }

        private void teacherButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateTeacher("SELECT* FROM teacher NATURAL JOIN departments;");
                nameTable = "teacher";
            }
        }

        private void groupsButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateGroups("SELECT * FROM groups NATURAL JOIN grouptable grouptable NATURAL JOIN faculty NATURAL JOIN departments;");
                nameTable = "groups";
            }
        }

        private void audienceFundButton_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                UpdateAudienceFund("SELECT * FROM audiencefund NATURAL JOIN departments  NATURAL JOIN audience;");
                nameTable = "audiencefund";
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                if (nameTable == "audience")
                {
                    UpdateAudience($"SELECT * FROM audience WHERE nameaudience ~* '^{SearchTextBox.Text}.*';");
                }
            }
        }

        private List<Audience> AudienceListUpdate = new List<Audience>();

        private void dataGridViewTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (nameTable == "audience")
            {

                try
                {
                    Audience audience = Audience.GetAudience(GetValueDataGrid(e.RowIndex), Audience.OrderTitle);

                    int idFindNew = AudienceListUpdate.FindIndex(id => id.Id == audience.Id);
                    if (idFindNew > -1)
                    {
                        AudienceListUpdate[idFindNew].Name = audience.Name;
                        AudienceListUpdate[idFindNew].Address = audience.Address;
                        AudienceListUpdate[idFindNew].Type = audience.Type;
                        AudienceListUpdate[idFindNew].Capacity = audience.Capacity;
                        AudienceListUpdate[idFindNew].TravelTime = audience.TravelTime;

                        int idFindOld = audiencesList.FindIndex(id => id.Id == AudienceListUpdate[idFindNew].Id);

                        if (AudienceListUpdate[idFindNew].Id == audiencesList[idFindOld].Id)
                        {
                            AudienceListUpdate.RemoveAt(idFindNew);
                        }
                    }
                    else
                    {
                        AudienceListUpdate.Add(audience);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    int pos = Audience.OrderTitle.FindIndex(f => f.Contains("idaudience"));
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);
                    Audience audience = audiencesList.Find(f => f.Id == index);

                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = audience.GetAudienceValue(dataGridViewTable.Columns[i].Name);
                    }

                }
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                ClearDataGrid();
                if (AudienceListUpdate.Count > 0)
                {
                    for (int i = 0; i < AudienceListUpdate.Count; i++)
                    {
                        NpgsqlCommand command = new NpgsqlCommand("update audience set nameaudience=@nameaudience,address =@address, typeaudience =@typeaudience::typeaudience,capacity=@capacity,travelTime=@travelTime WHERE idaudience=@idaudience;", conn);
                        command.Parameters.AddWithValue("nameaudience", AudienceListUpdate[i].Name);
                        command.Parameters.AddWithValue("address", AudienceListUpdate[i].Address);
                        command.Parameters.AddWithValue("typeaudience", AudienceListUpdate[i].Type);
                        command.Parameters.AddWithValue("capacity", AudienceListUpdate[i].Capacity);
                        command.Parameters.AddWithValue("travelTime", AudienceListUpdate[i].travelTime);
                        command.Parameters.AddWithValue("idaudience", AudienceListUpdate[i].Id);
                        command.ExecuteNonQuery();
                    }
                    AudienceListUpdate.Clear();
                    UpdateAudience("SELECT * FROM audience;");
                }
            }
        }
        private object[] GetValueDataGrid(int row)
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
                        int pos = Audience.OrderTitle.FindIndex(f => f.Contains("idaudience")); // Ищем позицию id
                        int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
                        Audience audience = audiencesList.Find(f => f.Id == index); // Ищем класс аудитории по index
                        NpgsqlCommand command = new NpgsqlCommand("DELETE FROM  audience WHERE idaudience=@idaudience", conn);// Удаляем 
                        command.Parameters.AddWithValue("idaudience", audience.Id);
                        command.ExecuteNonQuery();
                        UpdateAudience("SELECT * FROM audience;");// Обновляем таблицу.
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public bool CheckInfo(string cmdTxt, NpgsqlConnection conn)
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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (conn?.State == ConnectionState.Open)
            {
                insertPanel.Visible = true;
                try
                {

                    if (nameTable == "audience")
                    {
                        insertPanel.Controls.Add(new AudienceControl(conn, this));
                        insertPanel.Width = 360;
                        insertPanel.Height = 360;
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
            insertPanel.Controls.Clear();
        }
    }
}
