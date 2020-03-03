using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult>GetValues()
        {
            //Get all our Values from our database table Values.
            var values = await _context.Values.ToListAsync();

            //Ok(): Creates an Microsoft.AspNetCore.Mvc.OkObjectResult object that 
            // produces an Microsoft.AspNetCore.Http.StatusCodes.Status200OK response.
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            //FirstOrDefault(): Returns the first element of a sequence that satisfies a specified condition 
            //  or a default value if no such element is found. First() would throw an except. rather than a
            //  a default value.
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
