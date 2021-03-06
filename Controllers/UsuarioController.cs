using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP_1_DAI.Utils;
using TP_1_DAI.Models;
using TP_1_DAI.Services;


namespace TP_1_DAI.Controllers
{
    [ApiController]
    [Route("login")]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        public IActionResult Login(Usuario usuario) {


            try
            {
                Usuario user = UsuarioServices.Login(usuario.UserName, usuario.Password);

                if (user != null)
                {
                    return Ok(user);
                }
                
                return NotFound();
                
            }
            catch (Exception)
            {
                
                throw;
                
            }

        }

    }

}