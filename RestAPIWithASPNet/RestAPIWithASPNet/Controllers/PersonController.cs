﻿using Microsoft.AspNetCore.Mvc;
using RestAPIWithASPNet.Model;
using RestAPIWithASPNet.Bussiness.Implementation;

namespace RestAPIWithASPNet.Controllers
{

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonBussiness _personService;

        public PersonController(IPersonBussiness personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Person person )
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personService.Create(person));

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Person person)
        {
            if (person == null)
                return BadRequest();

            return new ObjectResult(_personService.Update(person));

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
