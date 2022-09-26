﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Hypermedia.Filters;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;

        // Declaration of the service used
        private readonly IPersonBusiness _personBusiness;

        // Injection of an instance of IPersonService
        // when creating an instance of PersonController
        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _personBusiness = personBusiness;
        }


        [HttpGet("")]
        public IActionResult GetAll()
        {

            return Ok(_personBusiness.FindAll());
        }


        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))] //hateoas
        public IActionResult GetById(long id)
        {
            var personVO = _personBusiness.FindById(id);
            if (personVO == null) 
                return NotFound();

            return Ok(personVO);
        }

        [HttpPost("")]
        [TypeFilter(typeof(HyperMediaFilter))] //hateoas
        public IActionResult Post([FromBody] PersonVO personVO)
        {
            if (personVO == null) 
                return BadRequest();
            return Ok(_personBusiness.Create(personVO));
        }

        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))] //hateoas
        public IActionResult Put([FromBody] PersonVO personVO) 
        {
            if (personVO == null)
                return BadRequest();

            return Ok(_personBusiness.Update(personVO));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
