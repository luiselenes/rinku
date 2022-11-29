using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using rinku.Domain;

namespace rinku.Pages.Empleados
{
    public class BorrarModel : PageModel
    {
        public int borrarnum_empleados {get; set;}
         private readonly ILogger<BorrarModel> _logger;
        private readonly IMediator mediator;

        public BorrarModel(ILogger<BorrarModel> logger,
            IMediator mediat)
            {
                _logger = logger;
                mediator = mediat;
            }
             public async Task<IActionResult> OnGet(int num_empleados)
            {
                var empleados = await mediator.Send(new ConsultaxnumeroEmpleado(num_empleados));
                borrarnum_empleados= empleados.num_empleados;
                return Page();
            }

            public async Task<IActionResult> OnPost(BorrarEmpleados cmd){

            if(!ModelState.IsValid){
                borrarnum_empleados = cmd.num_empleados;
                return Page();
            }
  
            var res = await mediator.Send(cmd);
            return RedirectToPage("./Index");

      

              }
              
    }
}
