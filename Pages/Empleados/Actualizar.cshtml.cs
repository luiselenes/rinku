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


namespace rinku.Pages.Empleados
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


        public async Task<IActionResult>OnGet(int num_empleados){
            var empleado = await mediator.Send(new ConsultaxnumeroEmpleado(num_empleados));
            Detalles =  new DatosAEditar(){
                num_empleados =empleado.num_empleados,
                nombre  = empleado.nombre,
                appaterno= empleado.appaterno,
                apmaterno= empleado.apmaterno,
                rol = empleado.rol,
                activo = empleado.activo,
            };
            return Page();
        }

        public async Task <IActionResult> Onpost(ActualizarEmpleado cmd){
            if(!ModelState.IsValid){
                Detalles =  new DatosAEditar(){
                    num_empleados =cmd.num_empleados,
                    nombre  = cmd.nombre,
                    appaterno= cmd.appaterno,
                    apmaterno= cmd.apmaterno,
                    rol = cmd.rol,
                    activo = cmd.activo,
                };
                return Page();
            }
          
                var res = await mediator.Send(cmd);
                return RedirectToPage("./Index");
        }

    }

     public class DatosAEditar 
    {
        public int num_empleados { set; get; }
        public string nombre { set; get; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public string rol { get; set; } 
        public bool activo { get; set; }

    }
}