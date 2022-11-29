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
    public class ActualizarEmpleado : IRequest<bool>
    {
        public int num_empleados { set; get; }
        public string nombre { set; get; }
        public string appaterno { set; get; }
        public string apmaterno { set; get; }
        public string rol { set; get; }
        public bool activo { get; set; }
    }

  public class ActualizarEmpleadoHandler : IRequestHandler<ActualizarEmpleado, bool>
    {
        private readonly rinkuContext context;

        public ActualizarEmpleadoHandler(rinkuContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(ActualizarEmpleado request, CancellationToken cancellationToken)
        {

            var empleado = new Empleados();
            var dtempleado = context.empleados.Where(emp => emp.num_empleados == request.num_empleados).FirstOrDefault();


                dtempleado.nombre = request.nombre;
                dtempleado.appaterno = request.appaterno;
                dtempleado.apmaterno = request.apmaterno;
                dtempleado.rol = request.rol;
                dtempleado.activo = request.activo;

            await context.SaveChangesAsync();
            return true;

        }   
    }
}


