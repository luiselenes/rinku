using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using rinku.Models;

namespace rinku.Domain
{
    public class CrearEmpleados : IRequest<bool>
    {

        public int num_empleados { set; get; }
        public string nombre { set; get; }
        public string appaterno { set; get; }
        public string apmaterno { set; get; }
        public DateTime fecha_nacimineto { set; get; }
        public string rol { set; get; }
        public bool activo { get; set; }
    }

  public class CrearEmpleadosHandler : IRequestHandler<CrearEmpleados, bool>
    {
        private readonly rinkuContext context;


        public CrearEmpleadosHandler(rinkuContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(CrearEmpleados request, CancellationToken cancellationToken)
        {
            var empleado = new Empleados();
            var dtempleado = context.empleado.Where(emp => emp.num_empleados == request.num_empleados).FirstOrDefault();
            if (dtempleado != null){
                return false;
            }else{
                empleado.num_empleados = request.num_empleados;
                empleado.nombre = request.nombre;
                empleado.appaterno = request.appaterno;
                empleado.apmaterno = request.apmaterno;
                empleado.fecha_nacimiento = request.fecha_nacimineto;
                empleado.rol = request.rol;
                empleado.activo = request.activo;
            }
            context.empleado.Add(empleado);

            await context.SaveChangesAsync();
            return true;

        }   
    }
}


