using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP_1_DAI.Utils;
using TP_1_DAI.Models;
using TP_1_DAI.Services;
using System.Reflection;

namespace TP_1_DAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        private static List<Pizza> _Pizzas = new List<Pizza>();        

        [HttpGet]
        public IActionResult GetAll(){

            try
            {
                
                IActionResult respuesta;
                List<Pizza> listaDePizzas;

                listaDePizzas = PizzaServices.GetAllPizzas();
                respuesta = Ok(listaDePizzas);
                return respuesta;
            }
            catch (Exception ex)
            {
                
                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al obtener pizzas",
                    statusCode: 500
                );
                
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){


            try
            {
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
            catch (Exception ex)
            {
                
                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al obtener una unica pizza",
                    statusCode: 500
                );
                
            }

            
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza) {
            

            try
            {
                if(pizza.Nombre == "" || pizza.Importe <= 0 || pizza.Descripcion == ""){
                    return BadRequest("Inserte todos los datos!"); 
                }

                string headerToken = Request.Headers["token"];
                int resp;
                resp = PizzaServices.CreatePizza(pizza, headerToken);

                if(resp != -1) {
                    if(resp != -2) {
                        return CreatedAtAction(nameof(Create), resp);
                    }
                    return BadRequest();
                }

                return Unauthorized("No se encuentra autenticado");
                
            }
            catch (Exception ex)
            {
                
                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al crear pizza",
                    statusCode: 500
                );
                
            }

        }

        

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza) {
            

            try
            {
                if(pizza.Nombre == "" || pizza.Importe <= 0 || pizza.Descripcion == ""){
                    return BadRequest("Inserte todos los datos!"); 
                }  else if(id < 1) {
                    return BadRequest("id incorrecto"); 
                } else if (id != pizza.Id) {
                    return BadRequest("Los ids no coinciden"); 
                } 

                string headerToken = Request.Headers["token"];

                int resp = PizzaServices.UpdatePizza(id, pizza, headerToken);

                Console.WriteLine(resp);
                if(resp == 1) {
                    return Ok("Pizza actualizada");
                } else if(resp == 0){
                    return NotFound();
                }
                
                return Unauthorized("No se encuentra autenticado");
                
            }
            catch (Exception ex)
            {
                
                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al actualizar pizza",
                    statusCode: 500
                );
                
            }


        }
        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {   


            try
            {
                string headerToken = Request.Headers["token"];

                if(id > 0){
                    
                    int resp;
                    resp = PizzaServices.DeletePizza(id, headerToken);

                    if(resp != -2) {
                        if(resp == 1) {
                            return Ok("Pizza elimanada");
                        }

                        return NotFound("Pizza no encontrada");
                    }

                    return Unauthorized("No se encuentra autenticado"); 
                    
                } 

                return BadRequest("Id incorrecto");
                
            }
            catch (Exception ex)
            {
                
                MethodBase m = MethodBase.GetCurrentMethod();

                CustomLog.LogError(ex, m.DeclaringType.Name, m.Name);

                return Problem(
                    detail: ex.Message,
                    title: "Error al eliminar pizza",
                    statusCode: 500
                );
                
            }
        } 
    }
}
