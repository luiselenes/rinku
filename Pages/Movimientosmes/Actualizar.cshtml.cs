using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MediatR;
using rinku.Domain;

using Microsoft.Extensions.Configuration;


namespace rinku.Pages.Movimientosmes
{
    public class ActualizarModel : PageModel
    {           
        public DatosAEditar Detalles {get; set;}
        private readonly ILogger<ActualizarModel> _logger;
        private readonly IMediator mediator;
        private readonly IConfiguration configuracion;
        
    

        public ActualizarModel(ILogger<ActualizarModel> logger,
         IMediator mediatr,
         IConfiguration config)
        {
            _logger = logger;
            mediator = mediatr;
            configuracion = config;
        }


        public async Task<IActionResult>OnGet(int id_mv){
            var mvmes = await mediator.Send(new ConsultaMovimientoxid(id_mv));
            Detalles =  new DatosAEditar(){
                id_mv= mvmes.id_mv,
                num_empleados= mvmes.num_empleados,
                mes= mvmes.mes,
                catidad_entregas= mvmes.catidad_entregas,
                
            };
            return Page();
        }

        public async Task <IActionResult> Onpost(ActualizarMovimientomes cmd){
            if(!ModelState.IsValid){
                Detalles =  new DatosAEditar(){
                    num_empleados= cmd.num_empleados,
                    mes= cmd.mes,
                    catidad_entregas= cmd.catidad_entregas,
                };
                return Page();
            }
          
                var res = await mediator.Send(cmd);
                return RedirectToPage("./Index");
        }

    }

     public class DatosAEditar 
    {
        public int id_mv { set; get; }
        public int num_empleados { set; get; }
        public string mes { get; set; }
        public int catidad_entregas { get; set; }
        public double horas_trabajadas { get; set; }
        public double pago_entregas { get; set; }
        public double pago_bono { get; set; }
        public double vale { get; set; }
        public double ISR { get; set; }
        public double sueldo_total { get; set; }

    }
}