using Microsoft.AspNetCore.Http;
using StudentBuisness.Interface;
using StudentBuisness.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Buisness.DataAccess;

namespace StudentBuisness.Business
{
    public class StudentBusiness:IStudentBusiness
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ISqlDataAccessHelper sqlDataAccessHelper;

        public StudentBusiness(IHttpContextAccessor httpContextAccessor, ISqlDataAccessHelper sqlDataAccessHelper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.sqlDataAccessHelper = sqlDataAccessHelper;
        }

        public async Task<List<Student>> StudentList()
        {
            List<Student> studentList = new List<Student>();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GetAllStudents";
                cmd.CommandType = CommandType.StoredProcedure;

                using (DataSet ds = await this.sqlDataAccessHelper.GetDataSet(cmd))
                {
                    if (ds != null && ds.Tables != null)
                    {
                        var taskListTable = ds.Tables[0];
                        studentList = (from DataRow dr in taskListTable.Rows
                                       select new Student
                                       {
                                           ID = Convert.ToInt32(dr["ID"]),
                                           Name = Convert.ToString(dr["Name"]),
                                           DOB = Convert.ToDateTime(dr["DOB"]),
                                           Mark = Convert.ToDecimal(dr["Mark"]),
                                       }).ToList();

                    }
                }


            }
            return studentList;
        }
    }
}
