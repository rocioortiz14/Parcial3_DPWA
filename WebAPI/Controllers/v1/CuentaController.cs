using Application.Feautres.Cuentas.Commands.CreateCuentaCommand;
using Application.Feautres.Cuentas.Commands.DeleteCuentaCommand;
using Application.Feautres.Cuentas.Commands.UpdateCuentaCommand;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CuentasController : BaseApiController
    {

        //GET: api/<controller>
        [HttpGet()]
       

        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCuentaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCuentaCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCuentaCommand { Id = id }));
        }
    }
}