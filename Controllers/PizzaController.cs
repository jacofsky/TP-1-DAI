using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP_1_DAI.Utils;
using TP_1_DAI.Models;

namespace TP_1_DAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        private static List<Pizza> _Pizzas = new List<Pizza>();
        // private static BD bd = new BD();
        

        [HttpGet]
        public IActionResult GetAll(){

            IActionResult respuesta;
            List<Pizza> listaDePizzas;

            listaDePizzas = BD.GetAllPizzas();
            respuesta = Ok(listaDePizzas);
            return respuesta;

        }

        /* [HttpGet("{id}")]
        public IActionResult GetAll(int id){

        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {

        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, Pizza pizza) {
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

        } */





    }
}
