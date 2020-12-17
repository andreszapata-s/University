using University.BL.Models;
using University.BL.Repositories.Implements;

namespace University.BL.Services.Implements
{
    public class CourseServices : GenericService<Course>, ICourseService
    {
        public CourseServices(ICourseRepository courseRepository) : base(courseRepository)
        {

        }
    }
}
