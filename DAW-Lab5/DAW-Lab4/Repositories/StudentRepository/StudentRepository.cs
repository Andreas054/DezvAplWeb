using DAW_Lab4.Data;
using DAW_Lab4.Models;
using DAW_Lab4.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace DAW_Lab4.Repositories.StudentRepository
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(Lab4Context lab4context) : base(lab4context) { }

        public List<Student> OrderByAge(int age)
        {
            var studentsOrderedAsc1 = _table.OrderBy(x => x.Age);
            var studentsOrderedDesc1 = _table.OrderByDescending(x => x.Age);
            var studentsOrderedByMultiple = _table.OrderByDescending(x => x.Age).ThenBy(x => x.Id);
            var studentsOrderedByMultiple2 = _table.OrderByDescending(x => x.Age).ThenByDescending(x => x.Id);

            // line query syntax
            var studentsOrderedAsc2 = from s in _table
                                      orderby s.Age
                                      select s;

            var studentsOrderedDesc2 = from s in _table
                                       orderby s.Age descending
                                       select s;

            return studentsOrderedAsc1.ToList();
        }

        public List<Student> GetAllWithInclude()
        {
            var result = _table.Include(s => s.Models2).ThenInclude(m2 => m2.model1).ToList();
            return _table.Include(s => s.Models2).ToList();

            // Model1 model1-a
            // Model2 model2-a
            // {...model1-a, {... model2 a}}
        }

        public List<dynamic> GetAllWithJoin()
        {
            var result = _lab4Context.Models1.Join(_lab4Context.Models2, model1 => model1.Id, model2 => model2.Model1Id,
                (model1, model2) => new { model1, model2 }).Select(ob => ob.model1);

            // model1, model2
            // {...model1-a, model2-a}, {model1-b, ...model2-b}
            return null;
        }

        public Student Where(int age)
        {
            var result1 = _table.Where(x => x.Age < age).FirstAsync();
            var result1 = _table.FirstOrDefault(x => x.Age < age);

            var result3 = from s in _table
                          where s.Age < age
                          select s;

            return result1;
        }

        public void GroupBy()
        {
            var groupedStudents = _table.GroupBy(x => x.Id);

            var groupedStudents2 = from s in _table
                                   group s by s.Age;

            foreach(var studentGroupedByAge in groupedStudents2)
            {
                Console.WriteLine("Student group age: " + studentGroupedByAge/Key);

                foreach(var s in studentGroupedByAge)
                {
                    Console.WriteLine("Student name: " + s.FirstName + " " + s.LastName);
                }
            }
        }
    }
}
