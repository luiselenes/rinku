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
    public class BorrarEmpleados : IRequest<bool>
    {
        public int num_empleados { set; get; }
    }

  public class BorrarEmpleadosHandler : IRequestHandler<BorrarEmpleados, bool>
    {
        private readonly rinkuContext context;


        public BorrarEmpleadosHandler(rinkuContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(BorrarEmpleados request, CancellationToken cancellationToken)
        {
            var res = await context.empleados.Where(emp => emp.num_empleados == request.num_empleados).FirstOrDefaultAsync();
            if(res== null)return false;
                context.empleados.Remove(res);
                await context.SaveChangesAsync();
                return true;
        }   
    }
}


