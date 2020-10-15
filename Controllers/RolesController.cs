using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private IRolService _rolService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RolesController(IRolService rolService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _rolService = rolService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("agregar")]
        public IActionResult Agregar([FromBody] RolModel model)
        {
            // map model to entity
            var rol = _mapper.Map<Rol>(model);
            try
            {
                // create
                _rolService.Create(rol);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _rolService.GetAll();
            var model = _mapper.Map<IList<RolModel>>(roles);
            return Ok(model);
        }
    }
}
