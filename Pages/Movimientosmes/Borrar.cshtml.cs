using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using rinku.Domain;

namespace rinku.Pages.Movimientosmes
{
    public class BorrarModel : PageModel
    {
        public int borraridmv {get; set;}
         private readonly ILogger<BorrarModel> _logger;
        private readonly IMediator mediator;

        public BorrarModel(ILogger<BorrarModel> logger,
            IMediator mediat)
            {
                _logger = logger;
                mediator = mediat;
            }
             public async Task<IActionResult> OnGet(int id_mv)
            {
                var mvmes = await mediator.Send(new ConsultaMovimientoxid(id_mv));
                borraridmv = mvmes.id_mv;
                return Page();
            }

            public async Task<IActionResult> OnPost(BorrarMovimientomes cmd){

            if(!ModelState.IsValid){
                borraridmv = cmd.id_mv;
                return Page();
            }
  
            var res = await mediator.Send(cmd);
            return RedirectToPage("./Index");

      

              }
              
    }
}
