using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : ControllerBase
    {
        private readonly IFindeksService _findeksService;

        public FindeksController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _findeksService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyfindeksid/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _findeksService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyuserid/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var result = _findeksService.GetFindeksByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getfindeksbynational/{id}")]
        public IActionResult GetByUserId(string id)
        {
            var result = _findeksService.GetFindeksByNationalId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        

        [HttpPost("add")]
        public IActionResult Add(Findeks findeks)
        {
            var result = _findeksService.Add(findeks);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
