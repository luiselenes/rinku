using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using rinku.Domain;
using rinku.Models;

namespace rinku.Pages.Movimientosmes
{
    public class CrearModel : PageModel
    {

        private readonly ILogger<CrearModel> _logger;
        private readonly IMediator mediator;

        public string num_empleados { set; get; }
        public string mes { set; get; }
        public string catidad_entregas { set; get; }


           public CrearModel(ILogger<CrearModel> logger, IMediator mediatr){

               _logger = logger;
                mediator = mediatr;
           }

            public async Task<IActionResult> OnPost(CrearMovimientoMes cmd ){
                
                var res = await  mediator.Send(cmd);

            return RedirectToPage("./Index");
               

        }
    }
}