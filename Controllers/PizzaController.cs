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

        [HttpGet("{id}")]
        public IActionResult GetById(int id){

            if(id > 0){
                Pizza pizza;
                pizza = BD.GetPizzaById(id);
                
                if(pizza == null) {
                    return NotFound("Pizza no encontrada");
                }

                return Ok(pizza);
            } 

            return BadRequest("Id incorrecto");

            
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            
            if(pizza.Nombre == "" || pizza.Importe <= 0 || pizza.Descripcion == ""){
                return BadRequest("Inserte todos los datos!"); 
            }

            int resp;
            resp = BD.CreatePizza(pizza);
            if(resp == 1) {
                return Ok("Pizza creada");
            }

            return BadRequest();
        }

        

        [HttpPut("{id}")]
        public IActionResult Update(int Id, Pizza pizza) {
            
            if(pizza.Nombre == "" || pizza.Importe <= 0 || pizza.Descripcion == ""){
                return BadRequest("Inserte todos los datos!"); 
            }  else if(Id < 1) {
                return BadRequest("Id incorrecto"); 
            }

            int resp;
            resp = BD.UpdatePizza(Id, pizza);
            if(resp == 1) {
                return Ok("Pizza actualizada");
            }

            return NotFound();


        }
        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {   
                
            if(id > 0){
                
                int resp;
                resp = BD.DeletePizza(id);
                
                if(resp == 1) {
                    return Ok("Pizza elimanada");
                }

                return NotFound("Pizza no encontrada");
            } 

            return BadRequest("Id incorrecto");
        } 
    }
}
