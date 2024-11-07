using Microsoft.AspNetCore.Mvc;
using SubjectApi.Models;

namespace SubjectApi.Controllers
{
    [Route("subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Subject> Post(CreateSubjectDto createSubjectDto)
        {
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                SubjectName = createSubjectDto.SubjectName,
                NumberOfHours = createSubjectDto.NumberOfHours,
                Description = createSubjectDto.Description,
                CreatedTime = DateTime.Now,
                LastUpdatedTime = DateTime.Now
            };

            if (subject != null)
            {
                using (var context = new SubjectDbContext())
                {
                    context.Subjects.Add(subject);
                    context.SaveChanges();
                    return StatusCode(201, subject);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult Get()
        {
            using (var context = new SubjectDbContext())
            {

                return Ok(context.Subjects.ToList());
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            using (var context = new SubjectDbContext())
            {
                var subject = context.Subjects.FirstOrDefault(x => x.Id == id);

                if (subject != null)
                {
                    return Ok(subject);
                }

                return NotFound(new { message = "Nem találtam egyezést az adatbázisban." });

            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(Guid id, UpdateSubjectDto updateSubjectDto)
        {
            using (var context = new SubjectDbContext())
            {
                var existingSubject = context.Subjects.FirstOrDefault(x => x.Id == id);

                if (existingSubject != null)
                {
                    existingSubject.SubjectName = updateSubjectDto.SubjectName;
                    existingSubject.NumberOfHours = updateSubjectDto.NumberOfHours;
                    existingSubject.Description = updateSubjectDto.Description;
                    existingSubject.LastUpdatedTime = DateTime.Now;
                    context.Subjects.Update(existingSubject);
                    context.SaveChanges();

                    return Ok(existingSubject);
                }

                return NotFound(new { message = "Nem találtam egyezést az adatbázisban." });

            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            using (var context = new SubjectDbContext())
            {
                var existingSubject = context.Subjects.FirstOrDefault(x => x.Id == id);

                if (existingSubject != null)
                {

                    context.Subjects.Remove(existingSubject);
                    context.SaveChanges();
                    return Ok(new { meassage = "Sikeres törlés!" });
                }

                return NotFound(new { message = "Nem találtam egyezést az adatbázisban." });

            }
        }
    }
}
