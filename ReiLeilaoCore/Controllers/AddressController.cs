using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReiLeilaoCore.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReiLeilaoCore.Controllers
{
    [Produces("application/json")]
    [Route("api/address")]
    [ApiController]
  
    public class AddressController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET 
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Address Address = new Address();
            Address.ProfileId = id;
            var objectResult = new GeneralController().DoProcessRequest(Address, "CONSULTAR");
            return new ObjectResult(objectResult);
        }

        // POST 
        [HttpPost]
        public IActionResult Post([FromBody] Address Address)
        {
            var objectResult = new GeneralController().DoProcessRequest(Address, "SALVAR");
            return new ObjectResult(objectResult);
        }

        // PUT 
        [HttpPut]
        public IActionResult Put([FromBody] Address Address)
        {
            var objectResult = new GeneralController().DoProcessRequest(Address, "ALTERAR");
            return new ObjectResult(objectResult);
        }

        // DELETE 
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Address Address = new Address();
            Address.Id = id;
            var objectResult = new GeneralController().DoProcessRequest(Address, "EXCLUIR");
            return new ObjectResult(objectResult);
        }
    }
}
