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
    public class ConsultaxnumeroEmpleado : IRequest<Empleados>
    {
         public int num_empleados { get; set; }

            public ConsultaxnumeroEmpleado(int Num_empleados){
            num_empleados=Num_empleados;
        }
        
    }
     public class ConsultaxnumeroEmpleadoHandler : IRequestHandler<ConsultaxnumeroEmpleado, Empleados>
    {
        private readonly rinkuContext context;
        public ConsultaxnumeroEmpleadoHandler(rinkuContext context){
            this.context=context;
        }
        public async Task<Empleados> Handle(ConsultaxnumeroEmpleado request, CancellationToken cancellationToken)
        {
            var resultado = await context.empleados.Where(emp => emp.num_empleados == request.num_empleados).FirstOrDefaultAsync();
            return new Empleados(){
                num_empleados = resultado.num_empleados,
                nombre = resultado.nombre,
                appaterno = resultado.appaterno,
                apmaterno = resultado.apmaterno,
                rol = resultado.rol,
                activo = resultado.activo
            };


        }
    }
}







