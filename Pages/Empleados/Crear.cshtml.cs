using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using rinku.Domain;
using rinku.Models;

namespace rinku.Pages.Empleados
{
    public class CrearModel : PageModel
    {

        private readonly ILogger<CrearModel> _logger;
        private readonly IMediator mediator;

        public string nombre { set; get; }
        public string appaterno { set; get; }
        public string apmaterno { set; get; }
        public float rol { set; get; }


           public CrearModel(ILogger<CrearModel> logger, IMediator mediatr){

               _logger = logger;
                mediator = mediatr;
           }

            public async Task<IActionResult> OnPost(CrearEmpleados cmd ){
                
                var res = await  mediator.Send(cmd);

            return RedirectToPage("./Index");
               

        }
    }
}