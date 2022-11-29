using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using rinku.Domain;

namespace apiRC.Controllers
{ 
    [Route("[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
        {
            private readonly IMediator mediator;
            public MovimientoController(IMediator mediator)
            {
                this.mediator= mediator;
            }
            [HttpGet]
                public async Task<IActionResult> GetAll(){
                return Ok(await mediator.Send(new ConsultaMovimientosMes()));
            }
            [HttpPost]
             public async Task<IActionResult> Create(CrearMovimientoMes command)
            {
                return Ok(await mediator.Send(command));
            }
        
            [HttpDelete("{Id_mv}")]
            public async Task<IActionResult> Delete(int Id_mv)
            {
                return Ok(await mediator.Send(new BorrarMovimientomes { id_mv = Id_mv }));
            }
            [HttpPut("{Id_mv}")]
            public async Task<IActionResult> Update(int Id_mv, ActualizarMovimientomes movimientomes)
            {
            if (Id_mv != movimientomes.id_mv)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(movimientomes));
        }
    }
}
