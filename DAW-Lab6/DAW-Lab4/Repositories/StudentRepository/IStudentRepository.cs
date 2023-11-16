using DAW_Lab4.Models;
using DAW_Lab4.Repositories.GenericRepository;

namespace DAW_Lab4.Repositories.StudentRepository
{
    public interface IStudentRepository: IGenericRepository<Student>
    {
        List<Student> OrderByAge(int age);
    }
}
