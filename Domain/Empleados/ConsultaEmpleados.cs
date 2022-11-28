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
    public class ConsultaEmpleados : IRequest<List<Empleados>>
    {

    }
     public class ConsultaEmpleadosHandler : IRequestHandler<ConsultaEmpleados, List<Empleados>>
    {
        private readonly rinkuContext context;
        public ConsultaEmpleadosHandler(rinkuContext context){
            this.context=context;
        }
        public async Task<List<Empleados>> Handle(ConsultaEmpleados request, CancellationToken cancellationToken)
        {
           
            var usuariolist = await context.empleado.Include(emp => emp.num_empleados).ToListAsync();
            if(usuariolist==null)
            return null;
            return usuariolist.ToList();
        }
    }

}





