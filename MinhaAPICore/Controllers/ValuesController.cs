using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAPICore.Controllers
{
    //[ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]

    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (product.Id == 0)
                return BadRequest();
            // add no banco

            //return Ok(product);// retornará status 200
            return CreatedAtAction(nameof(Post), product);
        }

        // PUT api/values/5   
        [HttpPut("{id}")]
        public void Put([FromRoute]int id, [FromBody] Product value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    [ApiController]
    public abstract class MainController : ControllerBase 
    {
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(value: new
                {
                    success = true,
                    data = result
                });
            }
            return BadRequest(error: new
            {
                success = false,
                errors = ObterErros()
            });
        }

        public bool OperacaoValida()
        {
            // minhas validacoes
            return true;
        }
        protected string ObterErros()
        {
            return "";
        }
    }

    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
