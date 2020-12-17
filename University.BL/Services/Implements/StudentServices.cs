using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class StudentServices : GenericService<Student>, IStudentServices
    {
        public StudentServices(IGenericRepository<Student> genericRepository) : base(genericRepository)
        {
        }
    }
}
