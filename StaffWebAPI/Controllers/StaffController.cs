using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using staff_library.staffrepository;
using staff_library.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace staff_data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        public staffdatainfo obj;
        public StaffController()
        {
            obj = new staffdatainfo();
        }

        // GET: api/<StaffController>
        [HttpGet]
        public List<staffmodel> Get()
        {
            return obj.selectsp();
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public List<staffmodel> Get(int id)
        {
            return obj.selectid(id);
        }

        // POST api/<StaffController>
        [HttpPost]
        public void Post([FromBody] staffmodel value)
        {
            obj.Insertsp(value);
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] staffmodel value)
        {
            value.ID = id;
            obj.updatesp(value);
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            obj.deletesp(id);
        }
    }
}
