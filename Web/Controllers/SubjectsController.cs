using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Web.Controllers.Filters;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class SubjectsController : ControllerBase
    {
        // TODO: exception handling

        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<IActionResult> GetSubject()
        {
            var subjectList = await _subjectService.GetAll();
            if (subjectList != null && subjectList.Any())
            {
                return Ok(subjectList);
            }
            return NotFound("No subjects were found.");
        }

        // GET: api/Subjects/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetSubject([FromRoute]int id)
        {
            var subject = await _subjectService.Find(id);
            if (subject == null)
            {
                return NotFound("Subject not found.");
            }
            return Ok(subject);
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Subject subject)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            await _subjectService.Add(subject);

            return CreatedAtAction("GetSubject", new { id = subject.SubjectId }, subject);
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject([FromRoute]int id, [FromBody] Subject subject)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != subject.SubjectId)
            {
                return BadRequest();
            }

            await _subjectService.Update(subject);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectService.Delete(id);

            if (subject == null)
            {
                return NotFound("Subject not found.");
            }
            return NoContent();
        }
    }
}
