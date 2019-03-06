using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReiLeilaoCore.Core.Application;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET api/user
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpPost]
        [Route("login")]
        public IActionResult PostLogin([FromBody] User User)
        {
            var objectResult = new GeneralController().DoProcessRequest(User, "CONSULTAR");
            return new ObjectResult(objectResult);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult PostCreate([FromBody] User User)
        {
            var objectResult = new GeneralController().DoProcessRequest(User, "SALVAR");
            return new ObjectResult(objectResult);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] User User)
        {
            //User User = new User();
            //User.Id = id;
            //User.Password = password;
            var objectResult = new GeneralController().DoProcessRequest(User, "ALTERAR");
            return new ObjectResult(objectResult);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            User User = new User();
            User.Id = id;
            var objectResult = new GeneralController().DoProcessRequest(User, "EXCLUIR");
            return new ObjectResult(objectResult);
        }
    }
}
