using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentBuisness.Business;
using StudentBuisness.Interface;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        public readonly IStudentBusiness studentBuisness;

        public StudentController(IStudentBusiness studentBuisness)
        {
            this.studentBuisness = studentBuisness;
        }
        public async Task<IActionResult> Index()
        {
            var studentList = await studentBuisness.StudentList();
            return View(studentList);
        }
        //public ActionResult Edit(int id)
        //{
        //    //// Retrieve the student with the specified id from the repository
        //    //// For demonstration purposes, let's assume you have a method in the repository to retrieve a single student by id
        //    //var student = studentBuisness.GetStudentById(id);
        //    //if (student == null)
        //    //{
        //    //}
        //    //return View(student);
        //}

    }
}
