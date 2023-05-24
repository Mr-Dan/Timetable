using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Timetable.Controller;
using Timetable.Controls;
using Timetable.Models;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Timetable.Forms
{
    public partial class TimetableSet : Form
    {


        private List<string> classtime;
        private NpgsqlConnection conn;
        private DBForm form;
        private int rowEdit = 0;
        private int columnEdit = 0;

        private GroupTable groupTable = new GroupTable();
        private Audience audience = new Audience();
        private List<Models.Timetable> timetablesList = new List<Models.Timetable>();
        private List<Models.Timetable> timetablesListUpdate = new List<Models.Timetable>();

        SelectControl selectControl;
        SelectOneControl selectOneControl;

        // запрос на проверку дня времени и аудитории 
        // зарос на выбору групп  и преподов с дисциплины
        // запрос на выборку аудиторий
        // в алгоритм добавить переодичность как в этот список можно добавить два [,] 
        //


        public GroupTable GroupTable
        {
            get
            {
                return groupTable;
            }
            set
            {
                if (value.Name != null)
                {
                    txtGroup.Text = value.Name.ToString();
                    UpdateTimeTable($"SELECT idtimetable,idgroups,grouptable.namegroup,teacher.idteacher,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.idaudience,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience WHERE grouptable.namegroup = '{txtGroup.Text}';", 16);
                    //UpdateTimeTable($"SELECT idtimetable,idgroups,grouptable.namegroup,teacher.idteacher,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.idaudience,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience ;", 16);

                    //nameTable = "timetable";
                }
                groupTable = value;

            }
        }


        public TimetableSet(NpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            radioBtnManual.Checked = true;
        }

        private string test;
        public string Test
        {
            get { return test; }
            set
            {
                test = value;
                MessageBox.Show(value);
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {

            // GenAlgoritm genAlgoritm = new GenAlgoritm();
            //genAlgoritm.Main();
            if (txtGroup.Text.Trim() != "")
            {
                if (txtSemester.Text.Trim() != "")
                {
                    TimeTableControl timeTableControl = new TimeTableControl(conn, this, txtGroup.Text, txtSemester.Text)
                    {
                        Name = "timeTableControl",
                        Location = new Point(100, 100),
                    };
                    Controls.Add(timeTableControl);
                    timeTableControl.BringToFront();
                }
                else
                {
                    MessageBox.Show("Выберете семестр");
                }
            }
            else
            {
                MessageBox.Show("Выберете группу");
            }

            //Controls["panelTitle"].Controls["txtGroup"].Text = "ff";
            //  GenAlgoritm genAlgoritm = new GenAlgoritm();
            // genAlgoritm.Main();
            /*  TimeTableControl timeTableControl = new TimeTableControl(conn,this) { 
               Name = "timeTableControl",
               Location = new Point(100, 100),
              };
               Controls.Add(timeTableControl);
               timeTableControl.BringToFront();*/

            //(SELECT DISTINCT idaudience FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN audiencefund USING(iddepartments)) LEFT JOIN audience USING(idaudience);


            // Select * FROM audience WHERE idaudience = any (SELECT DISTINCT  audiencefund.idaudience FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN audiencefund USING(iddepartments) WHERE )


            /*  
              
            // получаем список потоков по названию группы
            SELECT DISTINCT idgroups,namegroup  FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-191';
             
            // получаем список факультетов по списку потоков по названию группы
             SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192');

            // получаем список аудиторий по список факультетов по списку потоков по названию группы
            Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =
            ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments)
            WHERE  idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192')));
            
            // получаем список занятых аудиторий
            Select idaudience, weekday, classtime, nameaudience, typeaudience, capacity, periodicity FROM timetable LEFT JOIN
            (
            Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =
            ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments)
            WHERE  idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192')))          
            ) as AUD USING(idaudience) WHERE idaudience IS NOT NULL; 
            
             // получаем список  не занятых аудиторий
             

           Select idaudience, nameaudience, typeaudience, capacity,weekday, classtime, periodicity FROM audience 
             LEFT JOIN (
             Select idaudience, weekday, classtime, periodicity FROM timetable LEFT JOIN
            (
            Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =
            ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments)
            WHERE  idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192')))          
            ) as AUD USING(idaudience) WHERE idaudience IS NOT NULL                     
            )AS TEST USING (idaudience)
            WHERE idaudience =
            ANY(
            SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments)
            WHERE  idfaculty = 
            ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  
            WHERE idgroups = 
            ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) 
            WHERE namegroup = 'МОСб-192')));
            
 
            SELECT * FROM timetable WHERE idgroups = ANY(SELECT  idgroups  FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192');


            Select idaudience, nameaudience, typeaudience, capacity,traveltime,address 
            FROM audience 
            LEFT JOIN (SELECT idaudience FROM timetable WHERE weekday = 'пн' AND classtime ='8:30')
             AS TER USING(idaudience)
            WHERE idaudience = 
            ANY(SELECT DISTINCT audiencefund.idaudience 
            FROM audiencefund  
            LEFT JOIN departments USING(iddepartments) 
            LEFT JOIN faculty USING(iddepartments) 
            WHERE  idfaculty = 
            ANY (SELECT DISTINCT  idfaculty 
            FROM groups 
            LEFT JOIN grouptable USING(idgroup)  
            WHERE idgroups = 
            ANY(SELECT idgroups FROM timetable 
            LEFT JOIN groups USING(idgroups) 
            LEFT JOIN grouptable USING(idgroup) 
            WHERE namegroup = 'МОСб-192'    
            ))) AND weekday IS NULL;

            LEFT JOIN (SELECT idaudience FROM timetable WHERE weekday = 'пн' AND classtime ='8:30')
             AS TER USING(idaudience);

             *  ЧЕРЕЗ РАСПИСАНИЕ
               // получаем список потоков
               SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-191';

              // получаем спиков факультетов
               SELECT DISTINCT  idfaculty FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192');

              // получаем список аудиторий для кафедр
              Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =
               ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments)
               WHERE idfaculty = ANY(SELECT DISTINCT  idfaculty FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МКНб-192')));

              // получаем список занятых аудиторий по спимску аудиторий для кафедр
              Select idaudience, weekday, classtime, nameaudience, typeaudience, capacity, periodicity FROM timetable LEFT JOIN
              (Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =
               ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments)
               WHERE idfaculty = ANY(SELECT DISTINCT  idfaculty FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МКНб-192')))) as AUD USING(idaudience) WHERE idaudience IS NOT NULL; 

              // получаем список занятых аудиторий
              Select idaudience,weekday,classtime, nameaudience, typeaudience, capacity,periodicity FROM timetable LEFT JOIN
               (Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =
               any (SELECT DISTINCT  audiencefund.idaudience FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments) LEFT JOIN audiencefund USING(iddepartments)
               )) AS aud  USING(idaudience) WHERE idaudience IS NOT NULL;

              
           SELECT SUM(amount) FROM grouptable WHERE grouptable.idgroup =  ANY(
             SELECT DISTINCT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)  WHERE namegroup = 'МОСб-192');
             
         SELECT SUM(amount) FROM groups  LEFT JOIN grouptable USING(idgroup)  WHERE idgroups =
         ANY(SELECT DISTINCT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)  WHERE namegroup = 'МОСб-192');
             
            SELECT idtimetable,iddiscipline,idgroups,idteacher,periodicity, typelesson,amount FROM timetable LEFT JOIN discipline USING(iddiscipline)
            LEFT JOIN(
            SELECT idgroups,SUM(amount) as amount FROM groups  LEFT JOIN grouptable USING(idgroup)  WHERE idgroups =
            ANY(SELECT DISTINCT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)  WHERE namegroup = 'МОСб-192')           
            GROUP BY idgroups ) AS test USING(idgroups)
            WHERE idgroups = ANY(SELECT  idgroups  FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = 'МОСб-192') AND idaudience IS NULL;   

             */
        }



        public void UpdateTimeTable(string cmdText, int countTitle)
        {
            ClearDataGrid();

            List<string> title = new List<string>();
            (timetablesList, title) = SqlAssistant.SelectTimeTable(cmdText, countTitle, conn);

            foreach (var item in title)
            {
                dataGridViewTable.Columns.Add(item, Models.Timetable.Title[item]);

                if (item.IndexOf("id") > -1)
                {
                    // dataGridViewTable.Columns[item].Visible = false;
                }
            }

            for (int i = 0; i < timetablesList.Count; i++)
            {
                dataGridViewTable.Rows.Add(timetablesList[i].ConvertToObject(title));
            }

            /*   dataGridViewTable.Columns.Add("clear", "очистить");

               for (int i = 0; i < timetablesList.Count; i++)
               {
                   DataGridViewButtonColumn dataGridViewButtonColumn = new DataGridViewButtonColumn();
                   dataGridViewTable.Rows.Add(dataGridViewButtonColumn);
               }*/
        }
        public void ClearDataGrid()
        {
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            timetablesList.Clear();
            timetablesListUpdate.Clear();
        }

        private void txtGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectControl = new SelectControl("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                 "idfaculty, namefaculty, iddepartments, namedepartments" +
                 " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments);",
      9,
      "idgroup",
     "grouptable", this, conn)
            {
                Name = "SelectControl",
                Location = new Point(100, 100),
            };
            Controls.Add(selectControl);
            selectControl.BringToFront();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (txtGroup.Text.Trim() != "")
            {
                FitnessFunctions.GroupWindowPenalty = ConvertCustom.ConvertToInt(txtGroupWindow.Text);
                FitnessFunctions.TeacherWindowPenalty = ConvertCustom.ConvertToInt(txtTeacherWindow.Text);
                FitnessFunctions.OneLessonPenalty = ConvertCustom.ConvertToInt(txtOneLesson.Text);
                FitnessFunctions.MoreFourLessonPenalty = ConvertCustom.ConvertToInt(txtMoreFourLesson.Text);

                Gen.MaxIterations = ConvertCustom.ConvertToInt(txtIterations.Text);
                Gen.PopulationCount = ConvertCustom.ConvertToInt(txtPopulation.Text);

                GenAlgoritm genAlgoritm = new GenAlgoritm();

                List<object[]> obj = new List<object[]>();
                List<string> title = new List<string>();
                // получаем список всех аудиторий 
                (obj, title) = SqlAssistant.SelectAll($" Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments) WHERE idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}'))) AND typeaudience !='не учебная';", 4, conn);
                //(obj, title) = SqlAssistant.SelectAll($" Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience =ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments) WHERE idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)))) AND typeaudience !='не учебная';", 4, conn);

                List<AudienceDayHour> audienceList = ConvertToAudienceDayHour(obj, title);
                if (audienceList.Count == 0)
                {
                    MessageBox.Show("Нет аудиторий");
                }

                List<string> idgroups = SqlAssistant.SelectOne($"SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}';", conn);
                //List<string> idgroups = SqlAssistant.SelectOne($"SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup);", conn);


                (obj, title) = SqlAssistant.SelectAll($"Select idaudience, weekday, classtime, nameaudience, typeaudience, capacity, periodicity,idtimetable,iddiscipline,idgroups,idteacher FROM timetable LEFT JOIN (Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience = ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments) WHERE  idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}'))) ) as AUD USING(idaudience) WHERE idaudience is NOT NULL; ", 11, conn);
                // (obj, title) = SqlAssistant.SelectAll($"Select idaudience, weekday, classtime, nameaudience, typeaudience, capacity, periodicity,idtimetable,iddiscipline,idgroups,idteacher FROM timetable LEFT JOIN (Select idaudience, nameaudience, typeaudience, capacity FROM audience WHERE idaudience = ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund  LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments) WHERE  idfaculty = ANY (SELECT DISTINCT  idfaculty FROM groups LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)))) ) as AUD USING(idaudience) WHERE idaudience is NOT NULL; ", 11, conn);

                List<GroupGen> GroupGenBusy = ConvertToGroup(obj, title, idgroups);
                //audienceList.AddRange(audienceDaysHourbusy);


                (obj, title) = SqlAssistant.SelectAll($" SELECT idtimetable,iddiscipline,idgroups,idteacher,nameteacher,lastname,patronymic,periodicity, typelesson,amount FROM timetable LEFT JOIN discipline USING(iddiscipline) LEFT JOIN teacher USING(idteacher) LEFT JOIN( SELECT idgroups,SUM(amount) as amount FROM groups  LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT DISTINCT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)  WHERE namegroup = '{txtGroup.Text}') GROUP BY idgroups ) AS test USING(idgroups) WHERE idgroups = ANY(SELECT  idgroups  FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}') AND idaudience IS NULL;", 10, conn);
                //(obj, title) = SqlAssistant.SelectAll($" SELECT idtimetable,iddiscipline,idgroups,idteacher,nameteacher,lastname,patronymic,periodicity, typelesson,amount FROM timetable LEFT JOIN discipline USING(iddiscipline) LEFT JOIN teacher USING(idteacher) LEFT JOIN( SELECT idgroups,SUM(amount) as amount FROM groups  LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT DISTINCT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup) ) GROUP BY idgroups ) AS test USING(idgroups) WHERE idgroups = ANY(SELECT  idgroups  FROM groups LEFT JOIN grouptable USING(idgroup)) AND idaudience IS NULL;", 10, conn);

                List<GroupGen> groups = ConvertToGroup(obj, title, idgroups);
                if (groups.Count == 0)
                {
                    MessageBox.Show("Нет дисциплин");
                }
                else
                {

                    /*   (obj, title) = SqlAssistant.SelectAll("SELECT idgroups,idgroup FROM groups LEFT JOIN grouptable USING (idgroup);", 2, conn);

                       for (int i = 0; i < groups.Count; i++)
                       {
                           for (int j = 0; j < obj.Count; j++)
                           {
                               object[] arr = obj[j];

                               if (groups[i].id == ConvertCustom.ConvertToInt(arr[0].ToString()))
                               {
                                   groups[i].IdList.Add(ConvertCustom.ConvertToInt(arr[1].ToString()));
                               }
                              for (int k = 0; k < title.Count; k++)
                               {

                               }
                           }
                       }*/

                    Plan plan = genAlgoritm.Main(groups, audienceList, GroupGenBusy);
                    if (plan != null)
                    {
                        TimeTableSet(plan);
                        string error = "";
                        for (int i = 0; i < plan.FitnessValue.Error.Count; i++)
                        {
                            error += plan.FitnessValue.Error[i] + "\n";
                        }
                        MessageBox.Show("Сумма ошибок=" + plan.FitnessValue.Value + "\n" + error);
                    }

                }

            }
            else
            {
                MessageBox.Show("Выберете группу");
            }
        }
        private void TimeTableSet(Plan plan)
        {
            for (int day = 0; day < Plan.DaysPerWeek; day++)
            {
                for (int hour = 0; hour < Plan.HoursPerDay; hour++)
                {
                    foreach (var pair in plan.HourPlans[day, hour].lessоns)
                    {
                        int id = dataGridViewTable.Columns["idtimetable"].Index;

                        for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
                        {
                            if (dataGridViewTable.Rows[i].Cells[id].Value.ToString() == pair.Group.Idtimetable.ToString())
                            {
                                int weekday = dataGridViewTable.Columns["weekday"].Index;
                                int classtime = dataGridViewTable.Columns["classtime"].Index;
                                int nameaudience = dataGridViewTable.Columns["nameaudience"].Index;
                                int idaudience = dataGridViewTable.Columns["idaudience"].Index;

                                dataGridViewTable.Rows[i].Cells[weekday].Value = GetWeekday(day);
                                dataGridViewTable.Rows[i].Cells[classtime].Value = GetClasstime(hour);
                                dataGridViewTable.Rows[i].Cells[nameaudience].Value = pair.Group.Audience.Name;
                                dataGridViewTable.Rows[i].Cells[idaudience].Value = pair.Group.Audience.Id;

                                int index = timetablesList.FindIndex(id => id.Id == pair.Group.Idtimetable);
                                if (index > -1)
                                {
                                    timetablesList[index].WeekDay = GetWeekday(day);
                                    timetablesList[index].ClassTime = GetClasstime(hour);
                                    timetablesList[index].Audience.Name = pair.Group.Audience.Name;
                                    timetablesList[index].Audience.Id = pair.Group.Audience.Id;
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
            {
                SetListUpdate(i);
            }
        }

        private List<AudienceDayHour> ConvertToAudienceDayHour(List<object[]> obj, List<string> title)
        {
            List<AudienceDayHour> audienceList = new List<AudienceDayHour>();
            for (int i = 0; i < obj.Count; i++)
            {
                object[] arr = obj[i];
                AudienceDayHour audience = new AudienceDayHour();
                for (int j = 0; j < title.Count; j++)
                {
                    if (title[j] == "idaudience")
                    {
                        audience.Id = ConvertCustom.ConvertToInt(arr[j].ToString());
                    }
                    else if (title[j] == "nameaudience")
                    {
                        audience.Name = arr[j].ToString();
                    }
                    else if (title[j] == "typeaudience")
                    {
                        audience.TypeAudiens = arr[j].ToString();

                    }
                    else if (title[j] == "capacity")
                    {
                        audience.CapacityAudiens = ConvertCustom.ConvertToInt(arr[j].ToString());

                    }
                    else if (title[j] == "weekday")
                    {
                        audience.day = GetWeekday(arr[j].ToString());
                    }
                    else if (title[j] == "classtime")
                    {
                        audience.hour = GetClasstime(arr[j].ToString());
                    }

                }
                audienceList.Add(audience);
            }
            return audienceList;
        }

        private List<GroupGen> ConvertToGroup(List<object[]> obj, List<string> title, List<string> idgroups)
        {
            List<GroupGen> groupGenList = new List<GroupGen>();
            for (int i = 0; i < obj.Count; i++)
            {
                object[] arr = obj[i];
                GroupGen groupGen = new GroupGen();
                groupGen.Audience = new AudienceDayHour();
                for (int j = 0; j < title.Count; j++)
                {
                    if (title[j] == "idgroups")
                    {
                        if (idgroups.FindIndex(x => x == arr[j].ToString()) > -1)
                        {
                            groupGen.Id = -1;
                        }
                        else
                        {
                            groupGen.Id = ConvertCustom.ConvertToInt(arr[j].ToString());
                        }

                    }
                    else if (title[j] == "idteacher")
                    {
                        groupGen.Teacher = ConvertCustom.ConvertToInt(arr[j].ToString());
                    }
                    else if (title[j] == "nameteacher")
                    {
                        groupGen.NameTeacher += arr[j].ToString();
                    }
                    else if (title[j] == "lastname")
                    {
                        groupGen.NameTeacher += arr[j].ToString();
                    }
                    else if (title[j] == "patronymic")
                    {
                        groupGen.NameTeacher += arr[j].ToString();
                    }
                    else if (title[j] == "iddiscipline")
                    {
                        groupGen.Discipline = ConvertCustom.ConvertToInt(arr[j].ToString());

                    }
                    else if (title[j] == "periodicity")
                    {
                        groupGen.Periodicity = GetIdPeriodicity(arr[j].ToString());

                    }
                    else if (title[j] == "typelesson")
                    {
                        groupGen.Type = arr[j].ToString();

                    }
                    else if (title[j] == "amount")
                    {
                        groupGen.Amount = ConvertCustom.ConvertToInt(arr[j].ToString());
                    }
                    else if (title[j] == "idtimetable")
                    {
                        groupGen.Idtimetable = ConvertCustom.ConvertToInt(arr[j].ToString());
                    }


                    if (title[j] == "idaudience")
                    {
                        groupGen.Audience.Id = ConvertCustom.ConvertToInt(arr[j].ToString());
                    }
                    else if (title[j] == "nameaudience")
                    {
                        groupGen.Audience.Name = arr[j].ToString();
                    }
                    else if (title[j] == "typeaudience")
                    {
                        groupGen.Audience.TypeAudiens = arr[j].ToString();

                    }
                    else if (title[j] == "capacity")
                    {
                        groupGen.Audience.CapacityAudiens = ConvertCustom.ConvertToInt(arr[j].ToString());

                    }
                    else if (title[j] == "weekday")
                    {
                        groupGen.Audience.day = GetWeekday(arr[j].ToString());
                    }
                    else if (title[j] == "classtime")
                    {
                        groupGen.Audience.hour = GetClasstime(arr[j].ToString());
                    }
                    else if (title[j] == "periodicity")
                    {
                        groupGen.Audience.periodicity = GetIdPeriodicity(arr[j].ToString());

                    }


                }
                groupGenList.Add(groupGen);
            }
            return groupGenList;
        }

        private int GetWeekday(string weeekday)
        {
            if (weeekday == "пн")
            {
                return 0;
            }
            else if (weeekday == "вт")
            {
                return 1;
            }
            else if (weeekday == "ср")
            {
                return 2;
            }
            else if (weeekday == "чт")
            {
                return 3;
            }
            else if (weeekday == "пт")
            {
                return 4;
            }
            else if (weeekday == "сб")
            {
                return 5;
            }
            return -1;
        }
        private string GetWeekday(int weeekday)
        {
            if (weeekday == 0)
            {
                return "пн";
            }
            else if (weeekday == 1)
            {
                return "вт";
            }
            else if (weeekday == 2)
            {
                return "ср";
            }
            else if (weeekday == 3)
            {
                return "чт";
            }
            else if (weeekday == 4)
            {
                return "пт";
            }
            else if (weeekday == 5)
            {
                return "сб";
            }
            return null;
        }
        private int GetClasstime(string classtime)
        {
            if (classtime == "8:30")
            {
                return 0;
            }
            else if (classtime == "10:10")
            {
                return 1;
            }
            else if (classtime == "12:00")
            {
                return 2;
            }
            else if (classtime == "13:40")
            {
                return 3;
            }
            else if (classtime == "15:20")
            {
                return 4;
            }
            else if (classtime == "17:00")
            {
                return 5;
            }
            else if (classtime == "18:40")
            {
                return 6;
            }
            return -1;
        }
        private string GetClasstime(int classtime)
        {
            if (classtime == 0)
            {
                return "8:30";
            }
            else if (classtime == 1)
            {
                return "10:10";
            }
            else if (classtime == 2)
            {
                return "12:00";
            }
            else if (classtime == 3)
            {
                return "13:40";
            }
            else if (classtime == 4)
            {
                return "15:20";
            }
            else if (classtime == 5)
            {
                return "17:00";
            }
            else if (classtime == 6)
            {
                return "18:40";
            }
            return null;
        }

        private int GetIdPeriodicity(string periodicity)
        {
            if (periodicity == "каждую неделю")
            {
                return 1;
            }
            else if (periodicity == "числитель")
            {
                return 2;
            }
            else if (periodicity == "знаменатель")
            {
                return 3;
            }
            return 0;
        }

        private void dataGridViewTable_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int pos = dataGridViewTable.Columns["idtimetable"].Index;// Ищем позицию id
            int index = Convert.ToInt32(e.Row.Cells[pos].Value); // Получаем index 
            Models.Timetable? timetable = timetablesList.Find(f => f.Id == index); // Ищем класс аудитории по index
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM  timetable WHERE idtimetable=@idtimetable", conn);// Удаляем 
            command.Parameters.AddWithValue("idtimetable", timetable.Id);
            command.ExecuteNonQuery();
            UpdateTimeTable($"SELECT idtimetable,idgroups,grouptable.namegroup,teacher.idteacher,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience WHERE grouptable.namegroup = '{txtGroup.Text}';", 15);// Обновляем таблицу.
        }

        bool backup = false;
        private void dataGridViewTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*  if (backup) { }
              else
              {

                  // try
                  // {
                  int nameaudience = dataGridViewTable.Columns["nameaudience"].Index;
                  int weekday = dataGridViewTable.Columns["weekday"].Index;
                  int classtime = dataGridViewTable.Columns["classtime"].Index;
                  int idgroups = dataGridViewTable.Columns["idgroups"].Index;
                  int idteacher = dataGridViewTable.Columns["idteacher"].Index;
                  int periodicity = dataGridViewTable.Columns["periodicity"].Index;
                  if (e.ColumnIndex == nameaudience)
                  {
                      if (dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value == null || dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value.ToString().Trim() == "")
                      {
                          int id = dataGridViewTable.Columns["idaudience"].Index;
                          backup = true;
                          dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value = "";
                          backup = false;
                      }
                      else if (ConvertCustom.ConvertToInt(dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value.ToString()) != 0)
                      {
                          string cmdText = "SELECT " +
                          "idaudience,nameaudience" +
                          $" FROM audience WHERE idaudience='{dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value}';";
                          List<Audience> audiences = new List<Audience>();
                          List<string> title = new List<string>();
                          (audiences, title) = SqlAssistant.SelectAudience(cmdText, 2, conn);
                          if (audiences.Count > 0)
                          {
                              object[] obj = audiences[0].ConvertToObject(title);
                              backup = true;
                              for (int i = 0; i < title.Count; i++)
                              {
                                  try
                                  {
                                      int index = dataGridViewTable.Columns[title[i]].Index;
                                      dataGridViewTable.Rows[e.RowIndex].Cells[index].Value = obj[i];
                                  }
                                  catch
                                  {

                                  }
                              }
                              backup = false;
                          }
                      }
                  }

                  try
                  {
                      if (generator == false)
                      {
                          if (dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value != null)
                          {

                              if (FourLessonGroups(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString()))
                              {
                                  if (FourLessonTeacher(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[idteacher].Value.ToString()))
                                  {
                                      if (dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value != null && NotBusyGroups(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[periodicity].Value.ToString()))
                                      {
                                          if (NotBusyTeacher(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[idteacher].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[periodicity].Value.ToString()))
                                          {
                                              SetListUpdate(e.RowIndex);
                                          }
                                          else
                                          {
                                              throw new Exception("В это время уже есть пара у этого преподователя");

                                          }

                                      }
                                      else
                                      {
                                          throw new Exception("В это время уже есть пара у этой группы");
                                      }
                                  }
                                  else
                                  {
                                      throw new Exception("Пар уже больше 4 у преподователя ");
                                  }
                              }
                              else
                              {
                                  throw new Exception("Пар уже больше 4  у группы");
                              }
                          }
                          else
                          {
                              SetListUpdate(e.RowIndex);
                          }
                      }
                      else
                      {
                          SetListUpdate(e.RowIndex);
                      }
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);

                      backup = true;
                      MessageBox.Show(ex.Message);
                      int pos = dataGridViewTable.Columns["idtimetable"].Index;// Ищем позицию id
                      int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                      Models.Timetable timetable = timetablesList.Find(f => f.Id == index);// Ищем данные по index
                      for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                      {   // Восстанавливаем данные 
                          dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = timetable.GetTimetableValue(dataGridViewTable.Columns[i].Name);
                      }
                      backup = false;
                  }

                  // }
                  //else
                  //{
                  // MessageBox.Show("Пар уже больше 4");
                  //}

              }
            */

            if (backup) { }
            else if (radioBtnManual.Checked)
            {
                try
                {
                    int weekday = dataGridViewTable.Columns["weekday"].Index;
                    int classtime = dataGridViewTable.Columns["classtime"].Index;
                    int nameaudience = dataGridViewTable.Columns["nameaudience"].Index;
                    int idaudience = dataGridViewTable.Columns["idaudience"].Index;
                    int idteacher = dataGridViewTable.Columns["idteacher"].Index;
                    int periodicity = dataGridViewTable.Columns["periodicity"].Index;
                    int idgroups = dataGridViewTable.Columns["idgroups"].Index;
                    if (e.ColumnIndex == weekday)
                    {
                        backup = true;

                        if (FourLessonGroups(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString()))
                        {
                            if (FourLessonTeacher(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[idteacher].Value.ToString()))
                            {
                                dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value = "";
                                dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value = "";
                                dataGridViewTable.Rows[e.RowIndex].Cells[idaudience].Value = "";
                                SetListUpdate(e.RowIndex);

                            }
                            else
                            {
                                // MessageBox.Show("Пар уже больше 4 у преподователя");
                                throw new Exception("Пар уже больше 4 у преподователя");
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Пар уже больше 4  у группы");
                            throw new Exception("Пар уже больше 4  у группы");
                        }
                        backup = false;
                    }
                    else if (e.ColumnIndex == classtime)
                    {
                        backup = true;
                        if (NotBusyGroups(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[periodicity].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[idgroups].Value.ToString()))
                        {

                            if (NotBusyTeacher(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[idteacher].Value.ToString(), dataGridViewTable.Rows[e.RowIndex].Cells[periodicity].Value.ToString()))
                            {
                                dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value = "";
                                dataGridViewTable.Rows[e.RowIndex].Cells[idaudience].Value = "";
                                SetListUpdate(e.RowIndex);
                            }
                            else
                            {
                                throw new Exception("В это время уже есть пара у этого преподователя");

                            }

                        }
                        else
                        {
                            // MessageBox.Show("Группа уже занята");
                            throw new Exception("В это время уже есть пара у этой группы");
                        }
                        backup = false;
                    }
                    else if (e.ColumnIndex == nameaudience)
                    {
                        backup = true;

                        if (ConvertCustom.ConvertToInt(dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value.ToString()) != 0)
                        {
                            string cmdText = "SELECT " +
                            "idaudience,nameaudience" +
                            $" FROM audience WHERE idaudience='{dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value}';";
                            List<Audience> audiences = new List<Audience>();
                            List<string> title = new List<string>();
                            (audiences, title) = SqlAssistant.SelectAudience(cmdText, 2, conn);
                            if (audiences.Count > 0)
                            {
                                object[] obj = audiences[0].ConvertToObject(title);

                                for (int i = 0; i < title.Count; i++)
                                {
                                    try
                                    {
                                        int index = dataGridViewTable.Columns[title[i]].Index;
                                        dataGridViewTable.Rows[e.RowIndex].Cells[index].Value = obj[i];
                                    }
                                    catch
                                    {

                                    }
                                }

                            }
                        }

                        SetListUpdate(e.RowIndex);
                        backup = false;
                    }
                }
                catch (Exception ex)
                {
                    backup = true;
                    MessageBox.Show(ex.Message);
                    int pos = dataGridViewTable.Columns["idtimetable"].Index;// Ищем позицию id
                    int index = Convert.ToInt32(dataGridViewTable.Rows[e.RowIndex].Cells[pos].Value);//Ищем index
                    Models.Timetable timetable = timetablesList.Find(f => f.Id == index);// Ищем данные по index
                    for (int i = 0; i < dataGridViewTable.ColumnCount; i++)
                    {   // Восстанавливаем данные 
                        dataGridViewTable.Rows[e.RowIndex].Cells[i].Value = timetable.GetTimetableValue(dataGridViewTable.Columns[i].Name);
                    }
                    backup = false;
                }
            }

        }

        private void SetListUpdate(int rowIndex)
        {
            Models.Timetable timetable = Models.Timetable.GetTimetable(GetValueDataGrid(rowIndex), Models.Timetable.OrderTitle); //Получаем изменения
                                                                                                                                 //   if (FourLesson(dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString())) {
            int idFindNew = timetablesListUpdate.FindIndex(id => id.Id == timetable.Id); // Если нашли в списке для обновленмй
            if (idFindNew > -1)
            {// То обновляем данные 
                timetablesListUpdate[idFindNew].Id = timetable.Id;
                timetablesListUpdate[idFindNew].WeekDay = timetable.WeekDay;
                timetablesListUpdate[idFindNew].ClassTime = timetable.ClassTime;
                timetablesListUpdate[idFindNew].Audience.Id = timetable.Audience.Id;
                if (timetable.Audience.Name != null)
                    timetablesListUpdate[idFindNew].Audience.Name = timetable.Audience.Name;
                timetablesListUpdate[idFindNew].Periodicity = timetable.Periodicity;
                int idFindOld = timetablesList.FindIndex(id => id.Id == timetablesListUpdate[idFindNew].Id);// Преверяем внесенные данные
                if (timetablesListUpdate[idFindNew] == timetablesList[idFindOld])// Если данные вернулись к первоначальным 
                { //То удаляем из списка для обновлений
                    timetablesListUpdate.RemoveAt(idFindNew);
                }
            }
            else// Если не нашли
            {// То добавляем данные 
                timetablesListUpdate.Add(timetable);
                // dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Gray;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (timetablesListUpdate.Count > 0)
                {
                    for (int i = 0; i < timetablesListUpdate.Count; i++)
                    {
                        NpgsqlCommand command = new NpgsqlCommand("UPDATE timetable SET weekday =@weekday::weekday,classTime=@classTime::classTime,idaudience=@idaudience,periodicity=@periodicity::periodicity WHERE idtimetable = @idtimetable", conn);
                        command.Parameters.AddWithValue("weekday", timetablesListUpdate[i].WeekDay.Trim() == "" ? DBNull.Value : timetablesListUpdate[i].WeekDay);
                        command.Parameters.AddWithValue("classTime", timetablesListUpdate[i].ClassTime.Trim() == "" ? DBNull.Value : timetablesListUpdate[i].ClassTime);
                        command.Parameters.AddWithValue("idaudience", timetablesListUpdate[i].Audience.Id == 0 ? DBNull.Value : timetablesListUpdate[i].Audience.Id);
                        command.Parameters.AddWithValue("periodicity", timetablesListUpdate[i].Periodicity);
                        command.Parameters.AddWithValue("idtimetable", timetablesListUpdate[i].Id);
                        command.ExecuteNonQuery();
                    }

                    UpdateTimeTable($"SELECT idtimetable,idgroups,grouptable.namegroup,teacher.idteacher,teacher.lastName, teacher.nameteacher , teacher.patronymic, teacher.position, teacher.academicdegree,discipline.namediscipline,discipline.typeLesson,weekday,classTime,audience.idaudience,audience.nameaudience,periodicity FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience WHERE grouptable.namegroup = '{txtGroup.Text}';", 16);

                }
                else
                {
                    MessageBox.Show("Нечего обновлять");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (radioBtnManual.Checked)
            {
                if (e.RowIndex > -1)
                {
                    int weekday = dataGridViewTable.Columns["weekday"].Index;
                    int classtime = dataGridViewTable.Columns["classtime"].Index;
                    int periodicity = dataGridViewTable.Columns["periodicity"].Index;
                    int nameaudience = dataGridViewTable.Columns["nameaudience"].Index;
                    int idaudience = dataGridViewTable.Columns["idaudience"].Index;
                    int idgroups = dataGridViewTable.Columns["idgroups"].Index;
                    int typelesson = dataGridViewTable.Columns["typelesson"].Index;
                    int idteacher = dataGridViewTable.Columns["idteacher"].Index;
                    if (e.ColumnIndex == weekday)
                    {
                        /* backup = true;
                         dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value = "";
                         dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value = "";
                         dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value = "";
                         dataGridViewTable.Rows[e.RowIndex].Cells[idaudience].Value = "";
                         SetListUpdate(e.RowIndex);
                         backup = false;*/

                        selectOneControl = new SelectOneControl(conn, "weekday", this, dataGridViewTable.Rows[e.RowIndex].Cells[weekday])
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectOneControl);
                        selectOneControl.BringToFront();

                    }
                    else if (e.ColumnIndex == classtime)
                    {

                        /*  backup = true;
                          dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value = "";
                          dataGridViewTable.Rows[e.RowIndex].Cells[nameaudience].Value = "";
                          dataGridViewTable.Rows[e.RowIndex].Cells[idaudience].Value = "";
                          SetListUpdate(e.RowIndex);
                          backup = false;*/

                        selectOneControl = new SelectOneControl(conn, "classtime", this, dataGridViewTable.Rows[e.RowIndex].Cells[classtime])
                        {
                            Name = "SelectControl",
                            Location = new Point(100, 100),
                        };
                        Controls.Add(selectOneControl);
                        selectOneControl.BringToFront();

                    }
                    else if (e.ColumnIndex == nameaudience)
                    {
                        if (dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value == null || dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Выберите день недели");

                        }
                        else
                        {
                            if (dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value == null || dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Выберите время");

                            }
                            else
                            {
                                string type = "";
                                if (dataGridViewTable.Rows[e.RowIndex].Cells[typelesson].Value.ToString() == "лаб")
                                {
                                    type = "typeaudience = 'лабораторная'";
                                }
                                else
                                {
                                    type = "typeaudience != 'лабораторная'";
                                }
                                selectControl = new SelectControl($" Select idaudience, nameaudience, typeaudience, capacity,traveltime,address FROM audience LEFT JOIN (SELECT idaudience,weekday FROM timetable WHERE weekday = '{dataGridViewTable.Rows[e.RowIndex].Cells[weekday].Value}' AND classtime ='{dataGridViewTable.Rows[e.RowIndex].Cells[classtime].Value}' AND periodicity ='{dataGridViewTable.Rows[e.RowIndex].Cells[periodicity].Value}')AS TER USING(idaudience) WHERE idaudience =  ANY(SELECT DISTINCT audiencefund.idaudience FROM audiencefund LEFT JOIN departments USING(iddepartments) LEFT JOIN faculty USING(iddepartments) WHERE  idfaculty =  ANY (SELECT DISTINCT  idfaculty FROM groups  LEFT JOIN grouptable USING(idgroup)  WHERE idgroups =  ANY(SELECT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)  WHERE namegroup = '{txtGroup.Text}' ))) AND weekday IS NULL AND capacity >(SELECT SUM(amount) FROM groups  LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = ANY(SELECT DISTINCT idgroups FROM timetable LEFT JOIN groups USING(idgroups) LEFT JOIN grouptable USING(idgroup)  WHERE idgroups = '{ConvertCustom.ConvertToInt(dataGridViewTable.Rows[e.RowIndex].Cells[idgroups].Value.ToString())}' AND {type}::typeaudience) );", 6, "idaudience", "audience",
                         dataGridViewTable.Rows[e.RowIndex].Cells[e.ColumnIndex], conn)
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
            }
        }

        public void ControlDelete(string name)
        {
            try
            {
                Controls[name].Dispose();
                Controls.Remove(Controls[name]);

            }
            catch (Exception ex)
            {


            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            GenSettings.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GenSettings.Visible = false;
        }

        private void txtIntCheck_TextChanged(object sender, EventArgs e)
        {
            if (!ConvertCustom.TryConvertToInt(((TextBox)sender).Text))
            {
                MessageBox.Show("Только числа");
                ((TextBox)sender).Text = "0";
            }
        }

        private bool FourLessonGroups(string weekday)
        {
            // List<string> weekly = SqlAssistant.SelectOne($"SELECT * FROM timetable where idgroups= ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}') and weekday='{weekday}' and periodicity='каждую неделю'", conn);
            // List<string> denominator = SqlAssistant.SelectOne($"SELECT * FROM timetable where idgroups= ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}') and weekday='{weekday}' and periodicity='знаменатель'", conn);
            //List<string> Numerator = SqlAssistant.SelectOne($"SELECT * FROM timetable where idgroups= ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}') and weekday='{weekday}' and periodicity='числитель'", conn);
            int columnWeekday = dataGridViewTable.Columns["weekday"].Index;
            int periodicity = dataGridViewTable.Columns["periodicity"].Index;
            int weekly = 0;
            int denominator = 0;
            int numerator = 0;
            for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
            {
                if (dataGridViewTable.Rows[i].Cells[columnWeekday].Value.ToString() == weekday)
                {
                    if (dataGridViewTable.Rows[i].Cells[periodicity].Value.ToString() == "каждую неделю")
                    {
                        weekly++;
                    }
                    else if (dataGridViewTable.Rows[i].Cells[periodicity].Value.ToString() == "знаменатель")
                    {
                        denominator++;
                    }
                    else if (dataGridViewTable.Rows[i].Cells[periodicity].Value.ToString() == "числитель")
                    {
                        numerator++;
                    }
                }
            }

            if (weekly + denominator > 4 || weekly + numerator > 4)
            {
                return false;
            }
            return true;
        }

        private bool FourLessonTeacher(string weekday, string idTeacher)
        {
            List<string> weeklyList = SqlAssistant.SelectOne($"SELECT * FROM timetable where idTeacher= {idTeacher} and weekday='{weekday}' and periodicity='каждую неделю' AND NOT idgroups = ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}')", conn);
            List<string> denominatorList = SqlAssistant.SelectOne($"SELECT * FROM timetable where idTeacher= {idTeacher} and weekday='{weekday}' and periodicity='знаменатель' AND NOT idgroups = ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}')", conn);
            List<string> numeratorList = SqlAssistant.SelectOne($"SELECT * FROM timetable where idTeacher= {idTeacher} and weekday='{weekday}' and periodicity='числитель' AND NOT idgroups = ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}')", conn);

            int weekly = 0;
            int denominator = 0;
            int numerator = 0;
            int columnWeekday = dataGridViewTable.Columns["weekday"].Index;
            int columnidTeacher = dataGridViewTable.Columns["idteacher"].Index;
            int periodicity = dataGridViewTable.Columns["periodicity"].Index;
            for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
            {
                if (dataGridViewTable.Rows[i].Cells[columnWeekday].Value.ToString() == weekday)
                {
                    if (dataGridViewTable.Rows[i].Cells[columnidTeacher].Value.ToString() == idTeacher)
                    {
                        if (dataGridViewTable.Rows[i].Cells[periodicity].Value.ToString() == "каждую неделю")
                        {
                            weekly++;
                        }
                        else if (dataGridViewTable.Rows[i].Cells[periodicity].Value.ToString() == "знаменатель")
                        {
                            denominator++;
                        }
                        else if (dataGridViewTable.Rows[i].Cells[periodicity].Value.ToString() == "числитель")
                        {
                            numerator++;
                        }
                    }
                }
            }
            if (weeklyList.Count + weekly + denominatorList.Count + denominator > 4 || weeklyList.Count + weekly + numeratorList.Count + numerator > 4)
            {
                return false;
            }
            return true;
        }

        private bool NotBusyGroups(string weekday, string classtime, string periodicity, string idgroup)
        {

            //  List<string> busyList = SqlAssistant.SelectOne($"SELECT periodicity FROM timetable WHERE idgroups = ANY (SELECT idgroups FROM groups LEFT JOIN grouptable USING(idgroup) WHERE namegroup = '{txtGroup.Text}') AND weekday ='{weekday}' AND classtime ='{classtime}';", conn);
            List<string> busyList = SqlAssistant.SelectOne($"SELECT periodicity FROM timetable WHERE idgroups = ANY ( SELECT idgroups FROM groups LEFT JOIN (SELECT idgroup FROM groups LEFT JOIN grouptable USING(idgroup) WHERE idgroups = '{idgroup}') AS gro USING(idgroup)) AND weekday ='{weekday}' AND classtime ='{classtime}';", conn);

            bool busy = true;
            if (busyList.Count > 1) busy = false;

            if (busyList.FindIndex(x => x == "каждую неделю") > -1)
            {
                busy = false;
            }
            else if (busyList.FindIndex(x => x == periodicity) > -1)
            {
                busy = false;
            }

            int columnWeekday = dataGridViewTable.Columns["weekday"].Index;
            int columnPeriodicity = dataGridViewTable.Columns["periodicity"].Index;
            int columnClasstime = dataGridViewTable.Columns["classtime"].Index;
            for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
            {
                if (dataGridViewTable.Rows[i].Cells[columnWeekday].Value.ToString() == weekday)
                {
                    if (dataGridViewTable.Rows[i].Cells[columnClasstime].Value.ToString() == classtime)
                    {
                        if (dataGridViewTable.Rows[i].Cells[columnPeriodicity].Value.ToString() == "каждую неделю")
                        {
                            busy = false;
                        }
                        else if (dataGridViewTable.Rows[i].Cells[columnPeriodicity].Value.ToString() == periodicity)
                        {
                            busy = false;
                        }
                    }
                }
            }
            return busy;
        }

        private bool NotBusyTeacher(string weekday, string classtime, string idTeacher, string periodicity)
        {
            List<string> busyList = SqlAssistant.SelectOne($"SELECT * FROM timetable WHERE idTeacher= {idTeacher} AND weekday ='{weekday}' AND classtime ='{classtime}';", conn);
            bool busy = true;
            if (busyList.Count > 1) busy = false;

            if (busyList.FindIndex(x => x == "каждую неделю") > -1)
            {
                busy = false;
            }
            else if (busyList.FindIndex(x => x == periodicity) > -1)
            {
                busy = false;
            }

            int columnWeekday = dataGridViewTable.Columns["weekday"].Index;
            int columnPeriodicity = dataGridViewTable.Columns["periodicity"].Index;
            int columnClasstime = dataGridViewTable.Columns["classtime"].Index;
            int columnidTeacher = dataGridViewTable.Columns["idTeacher"].Index;
            for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
            {
                if (dataGridViewTable.Rows[i].Cells[columnWeekday].Value.ToString() == weekday)
                {
                    if (dataGridViewTable.Rows[i].Cells[columnClasstime].Value.ToString() == classtime)
                    {
                        if (dataGridViewTable.Rows[i].Cells[columnidTeacher].Value.ToString() == idTeacher)
                        {
                            if (dataGridViewTable.Rows[i].Cells[columnPeriodicity].Value.ToString() == "каждую неделю")
                            {
                                busy = false;
                            }
                            else if (dataGridViewTable.Rows[i].Cells[columnPeriodicity].Value.ToString() == periodicity)
                            {
                                busy = false;
                            }
                        }
                    }
                }
            }

            return busy;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = Directory.GetCurrentDirectory();

            var doc = DocX.Create(fileName);
            //Create Table with 2 rows and 4 columns.  
            Table t = doc.AddTable(100, 6);
            t.Alignment = Alignment.center;


            List<string> weekDay = SqlAssistant.SelectOne($"SELECT DISTINCT weekday FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience WHERE grouptable.namegroup = '{txtGroup.Text}';", conn);
            List<string> classTime = SqlAssistant.SelectOne($"SELECT DISTINCT classTime FROM timetable NATURAL JOIN groups NATURAL JOIN grouptable LEFT JOIN teacher on timetable.idteacher = teacher.idteacher LEFT JOIN discipline on timetable.iddiscipline = discipline.iddiscipline LEFT JOIN audience on timetable.idaudience = audience.idaudience WHERE grouptable.namegroup = '{txtGroup.Text}';", conn);

            weekDay.Sort((a, b) => GetWeekday(a).CompareTo(GetWeekday(b)));
            classTime.Sort((a, b) => GetWeekday(a).CompareTo(GetWeekday(b)));

            t.Rows[0].Cells[0].Paragraphs.First().Append("AA");
            t.Rows[0].Cells[0].Paragraphs.First().Append("AA");

            for (int i = 0; i < 6; i++)
            {

            }

            doc.InsertTable(t);
            doc.Save();

        }

        private void dataGridViewTable_Sorted(object sender, EventArgs e)
        {
            // MessageBox.Show(e.ToString());
        }

        private void dataGridViewTable_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // MessageBox.Show(e.RowIndex1.ToString());
        }

        private void radioBtnManual_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnManual.Checked)
            {
                btnSettings.Visible = false;
                btnGen.Visible = false;
                dataGridViewTable.ReadOnly = false;
            }
        }

        private void radioBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnAuto.Checked)
            {
                btnSettings.Visible = true;
                btnGen.Visible = true;
                dataGridViewTable.ReadOnly = true;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            int weekday = dataGridViewTable.Columns["weekday"].Index;
            int classtime = dataGridViewTable.Columns["classtime"].Index;
            int nameaudience = dataGridViewTable.Columns["nameaudience"].Index;
            int idaudience = dataGridViewTable.Columns["idaudience"].Index;
            for (int i = 0; i < dataGridViewTable.Rows.Count; i++)
            {
                dataGridViewTable.Rows[i].Cells[weekday].Value = null;
                dataGridViewTable.Rows[i].Cells[classtime].Value = null;
                dataGridViewTable.Rows[i].Cells[nameaudience].Value = null;
                dataGridViewTable.Rows[i].Cells[idaudience].Value = null;
                SetListUpdate(i);
            }
        }
    }
}
