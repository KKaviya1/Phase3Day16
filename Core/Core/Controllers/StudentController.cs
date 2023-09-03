using Microsoft.AspNetCore.Mvc;
using Core.Models;

namespace Core.Controllers
{
    public class StudentController : Controller
    {
        List<Student> listStudents = new List<Student>()
        {
            new Student() {Id=1, Name="Viya",Class="Three",Fee=3000.50},
            new Student() {Id=2, Name="Ramya",Class="TWo",Fee=200.50},
            new Student() {Id=3, Name="Prakash",Class="Four",Fee=4000.50},
            new Student() {Id=4, Name="Wahid",Class="Three",Fee=3500.50},
        };
        public IActionResult Index()
        {
            return View(listStudents);
        }
    }
}
