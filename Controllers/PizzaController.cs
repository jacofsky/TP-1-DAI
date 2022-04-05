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
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        private static List<Pizza> _Pizzas = new List<Pizza>();        

        [HttpGet]
        public IActionResult GetAll(){

            IActionResult respuesta;
            List<Pizza> listaDePizzas;

            listaDePizzas = PizzaServices.GetAllPizzas();
            respuesta = Ok(listaDePizzas);
            return respuesta;

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){

            if(id > 0){
                Pizza pizza;
                pizza = PizzaServices.GetPizzaById(id);
                
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
            resp = PizzaServices.CreatePizza(pizza);
            if(resp != -1) {
                return CreatedAtAction(nameof(Create), resp);
            }

            return BadRequest();
        }

        

        [HttpPut("{Id}")]
        public IActionResult Update(int Id, Pizza pizza) {
            
            if(pizza.Nombre == "" || pizza.Importe <= 0 || pizza.Descripcion == ""){
                return BadRequest("Inserte todos los datos!"); 
            }  else if(Id < 1) {
                return BadRequest("Id incorrecto"); 
            }

            string headerToken = Request.Headers["token"];

            int resp = PizzaServices.UpdatePizza(Id, pizza, headerToken);

             
            if(resp == 1) {
                return Ok("Pizza actualizada");
            } else if(resp == 0){
                return NotFound();
            }
            
            return Unauthorized("No se encuentra autenticado");



        }
        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {   
                
            if(id > 0){
                
                int resp;
                resp = PizzaServices.DeletePizza(id);
                
                if(resp == 1) {
                    return Ok("Pizza elimanada");
                }

                return NotFound("Pizza no encontrada");
            } 

            return BadRequest("Id incorrecto");
        } 
    }
}
