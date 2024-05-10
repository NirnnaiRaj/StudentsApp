using StudentBuisness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBuisness.Interface
{
    public interface IStudentBusiness
    {
        Task<List<Student>> StudentList();
    }
}
