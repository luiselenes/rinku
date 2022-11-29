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
    public class ConsultaMovimientosMes : IRequest<List<Movimiento_mes>>
    {

    }
     public class ConsultaMovimientosMesHandler : IRequestHandler<ConsultaMovimientosMes, List<Movimiento_mes>>
    {
        private readonly rinkuContext context;
        public ConsultaMovimientosMesHandler(rinkuContext context){
            this.context=context;
        }
        public async Task<List<Movimiento_mes>> Handle(ConsultaMovimientosMes request, CancellationToken cancellationToken)
        {
           
            var mvmeslist = await context.movimientos_mes.ToListAsync();
            if(mvmeslist==null)
            return null;
            return mvmeslist.ToList();
        }
    }
}
