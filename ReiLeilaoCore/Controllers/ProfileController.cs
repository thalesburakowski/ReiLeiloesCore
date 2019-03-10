using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReiLeilaoCore.Domain;

namespace ReiLeilaoCore.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Profile Profile = new Profile();
            Profile.Id = id;
            var objectResult = new GeneralController().DoProcessRequest(Profile, "CONSULTAR");
            return new ObjectResult(objectResult);
        }

        [HttpPost]
        public IActionResult Post(Profile Profile)
        {
            var objectResult = new GeneralController().DoProcessRequest(Profile, "SALVAR");
            return new ObjectResult(objectResult);
        }

        [HttpPut]
        public IActionResult Put(Profile Profile)
        {
            var objectResult = new GeneralController().DoProcessRequest(Profile, "ALTERAR");
            return new ObjectResult(objectResult);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            Profile Profile = new Profile();
            Profile.Id = id;
            var objectResult = new GeneralController().DoProcessRequest(Profile, "EXCLUIR");
            return new ObjectResult(objectResult);
        }
    }
}