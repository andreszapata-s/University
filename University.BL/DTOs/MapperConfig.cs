using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(x =>
            {
                x.CreateMap<Course, CourseDTO>(); //POST -PUT
                x.CreateMap<CourseDTO, Course>(); //GET
                x.CreateMap<Student, StudentDTO>();
                x.CreateMap<StudentDTO, Student>();
            });
        }
    }
}
