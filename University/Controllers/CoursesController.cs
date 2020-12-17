using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using University.BL.Data;
using University.BL.DTOs;
using University.BL.Models;
using University.BL.Repositories.Implements;
using University.BL.Services.Implements;

namespace University.Controllers
{
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseServices courseService = new CourseServices(new CourseRepository(UniversityContext.Create()));


        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            IEnumerable<Course> courses = await courseService.GetAll();
            IEnumerable<CourseDTO> coursesDTO = courses.Select(x => mapper.Map<CourseDTO>(x));
            return Ok(coursesDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Course course = await courseService.GetById(id);

            if (course == null)
                return NotFound();


            CourseDTO courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Course course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);

                return Ok(course);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (courseDTO.CourseId != id)
                return BadRequest();

            Course course = await courseService.GetById(id);

            if (course == null)
                return NotFound();

            try
            {
                Course _course = mapper.Map<Course>(courseDTO);
                _course = await courseService.Update(_course);
                return Ok(_course);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok();
        }
            
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            Course course = await courseService.GetById(id);

            if (course == null)
                return NotFound();

            await courseService.Delete(id);
            CourseDTO courseDTO = mapper.Map<CourseDTO>(course);
            
            return Ok();
        }

    }
}