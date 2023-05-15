using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Controller
{
    internal class SqlStaticJ
    {
        public static (string,int) audienceSql = ("SELECT * FROM audience;",6);
       
        public static (string, int) departmentsSql = ("SELECT " +
                    "departments.iddepartments,namedepartments," +                  
                    "idaudience,nameaudience,address,typeaudience " +
                    "FROM departments LEFT JOIN audience USING(idaudience)", 6);
        
        public static (string, int) disciplineSql = ("SELECT * FROM discipline;", 3);
       
        public static (string, int) facultySql = ("SELECT idfaculty, namefaculty,faculty.iddepartments," +
            " namedepartments FROM faculty LEFT JOIN departments USING(iddepartments);", 4);
        
        public static (string, int) grouptableSql = ("SELECT idgroup, namegroup, formeducation, recruitmentyear, amount, " +
                    "idfaculty, namefaculty, iddepartments, namedepartments" +
                    " FROM grouptable LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments USING(iddepartments);", 9);
        
        public static (string, int) teacherSql = ("SELECT " +
                    "teacher.idteacher,nameteacher,lastname,patronymic,position,academicdegree," +
                    "iddepartments,namedepartments " +
                    " FROM teacher LEFT JOIN departments  USING(iddepartments);", 8);
        
        public static (string, int) groupsSql = ("SELECT id,idgroups," +
                    "idgroup,namegroup," +
                    "idfaculty,namefaculty," +
                    "iddepartments,namedepartments" +
                    " FROM groups LEFT JOIN grouptable USING(idgroup) LEFT JOIN faculty USING(idfaculty) LEFT JOIN departments  USING(iddepartments);", 8);
        
        public static (string, int) audiencefundSql = ("SELECT idaudiencefund," +
                    "iddepartments,namedepartments," +
                    "audiencefund.idaudience,nameaudience,address,typeaudience,capacity,traveltime" +
                    " FROM audiencefund LEFT JOIN audience USING(idaudience) LEFT JOIN departments USING(iddepartments);", 9);
        
        public static (string, int) curriculumSql = ("SELECT * FROM curriculum;", 3);
        
        public static (string, int) curriculumdisciplineSql = ("SELECT idcurriculumdiscipline,course,semester,hours," +
                    "idcurriculum,namecurriculum,qualification," +
                    "iddiscipline,namediscipline,typelesson" +
                    " FROM curriculumdiscipline LEFT JOIN curriculum USING(idcurriculum) LEFT JOIN discipline USING(iddiscipline);", 10);
        public static (string, int) headdepartmentSql = ("SELECT idheaddepartment," +
            "headdepartment.iddepartments,namedepartments," +
            "headdepartment.idteacher,lastname,nameteacher,patronymic,position,academicdegree " +
            "FROM headdepartment LEFT JOIN  departments USING(iddepartments) LEFT JOIN teacher USING(idteacher);", 9);
       // public static (string, int) audienceSql = ("SELECT * FROM audience;", 6);
       // public static (string, int) audienceSql = ("SELECT * FROM audience;", 6);

    }
}
