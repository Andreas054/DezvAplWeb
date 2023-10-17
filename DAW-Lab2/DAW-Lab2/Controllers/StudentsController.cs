using DAW_Lab2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Cache;

namespace DAW_Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Maria", Age = 21 },
            new Student { Id = 2, Name = "Rares", Age = 22 },
            new Student { Id = 3, Name = "Andrei", Age = 23 },
            new Student { Id = 4, Name = "George", Age = 26 },
            new Student { Id = 5, Name = "Matei", Age = 29 }
        };

        // endpoint
        // GET
        [HttpGet]
        public List<Student> Get()
        {
            return students;
        }

        // GET all ordered
        [HttpGet("getAllOrdered")]
        public List<Student> getAllOrdered()
        {
            return students.OrderBy(s => s.Name).ToList();
        }

        // POST
        [HttpPost]
        public List<Student> Add(Student student)
        {
            students.Add(student);
            return students;
        }

        // DELETE
        [HttpDelete]
        public List<Student> Delete(Student student)
        {
            var studentIndex = students.FindIndex(x => x.Id == student.Id);
            if (studentIndex != -1)
            {
                students.RemoveAt(studentIndex);
            }
            return students;
        }

        // DELETE by id
        [HttpDelete("id")]
        public List<Student> DeleteById(int id)
        {
            var studentIndex = students.FindIndex(x => x.Id == id);
            if (studentIndex != -1)
            {
                students.RemoveAt(studentIndex);
            }
            return students;
        }
    }
}
