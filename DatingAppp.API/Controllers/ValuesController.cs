using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingAppp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingAppp.API.Controllers
{

    //httpȘ//localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        } 
        [HttpGet("{id}")]
        public async Task <IActionResult> GetValues (int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }
        //POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
