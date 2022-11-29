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
    public class BorrarMovimientomes : IRequest<bool>
    {
        public int id_mv { set; get; }
    }

  public class BorrarMovimientomesHandler : IRequestHandler<BorrarMovimientomes, bool>
    {
        private readonly rinkuContext context;


        public BorrarMovimientomesHandler(rinkuContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(BorrarMovimientomes request, CancellationToken cancellationToken)
        {
            var res = await context.movimientos_mes.Where(mv => mv.id_mv == request.id_mv).FirstOrDefaultAsync();
            if(res== null)return false;
                context.movimientos_mes.Remove(res);
                await context.SaveChangesAsync();
                return true;
        }   
    }
}


