using System.Collections.Generic;
using System.Web.Mvc;
using PlacementDashboard.Models;

namespace PlacementDashboard
{
    public class PlacementController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student { StudentId = 1, StudentName = "Jeet Joshi", Branch = "CE", CGPA = 8.5, Email = "jeet@gmail.com", Company = "TCS", Status = "Placed" },
            new Student { StudentId = 2, StudentName = "Preet Vora", Branch = "CE", CGPA = 8.2, Email = "preet@gmail.com", Company = "Infosys", Status = "Placed" },
            new Student { StudentId = 3, StudentName = "Tapan Raval", Branch = "CE", CGPA = 7.8, Email = "tapan@gmail.com", Company = "Pending", Status = "Pending" },
            new Student { StudentId = 4, StudentName = "Harsh Zolapara", Branch = "CE", CGPA = 9.1, Email = "harsh@gmail.com", Company = "Wipro", Status = "Placed" }
        };

        public ActionResult Index(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return View(students.FindAll(s =>
                    s.StudentName.ToLower().Contains(search.ToLower()) ||
                    s.Company.ToLower().Contains(search.ToLower()) ||
                    s.Branch.ToLower().Contains(search.ToLower())));
            }

            return View(students);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            student.StudentId = students.Count > 0 ?
                students[students.Count - 1].StudentId + 1 : 1;

            students.Add(student);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Student student = students.Find(s => s.StudentId == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}