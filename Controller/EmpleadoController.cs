using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using rinku.Domain;

namespace apiRC.Controllers
{ 
    [Route("[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
        {
            private readonly IMediator mediator;
            public EmpleadoController(IMediator mediator)
            {
                this.mediator= mediator;
            }
            [HttpGet]
                public async Task<IActionResult> GetAll(){
                return Ok(await mediator.Send(new ConsultaEmpleados()));
            }
            [HttpPost]
             public async Task<IActionResult> Create(CrearEmpleados command)
            {
                return Ok(await mediator.Send(command));
            }
        
            [HttpDelete("{Num_empleado}")]
            public async Task<IActionResult> Delete(int Num_empleado)
            {
                return Ok(await mediator.Send(new BorrarEmpleados { num_empleados = Num_empleado }));
            }
            [HttpPut("{Num_empleados}")]
            public async Task<IActionResult> Update(int Num_empleados, ActualizarEmpleado empleado)
            {
            if (Num_empleados != empleado.num_empleados)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(empleado));
        }
    }
}
