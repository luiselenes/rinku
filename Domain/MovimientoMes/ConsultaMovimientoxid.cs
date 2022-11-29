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
    public class ConsultaMovimientoxid : IRequest<Movimiento_mes>
    {
         public int id_mv { get; set; }

            public ConsultaMovimientoxid(int Id_mv){
            id_mv=Id_mv;
        }
        
    }
     public class ConsultaMovimientoxidHandler : IRequestHandler<ConsultaMovimientoxid, Movimiento_mes>
    {
        private readonly rinkuContext context;
        public ConsultaMovimientoxidHandler(rinkuContext context){
            this.context=context;
        }
        public async Task<Movimiento_mes> Handle(ConsultaMovimientoxid request, CancellationToken cancellationToken)
        {
            var resultado = await context.movimientos_mes.Where(mv => mv.id_mv == request.id_mv).FirstOrDefaultAsync();
            return new Movimiento_mes(){
                id_mv = resultado.id_mv,
                num_empleados = resultado.num_empleados,
                mes = resultado.mes,
                catidad_entregas = resultado.catidad_entregas,
                horas_trabajadas = resultado.horas_trabajadas,
                pago_entregas = resultado.pago_entregas,
                pago_bono = resultado.pago_bono,
                vale = resultado.vale,
                ISR = resultado.ISR,
                sueldo_total = resultado.sueldo_total
            };


        }
    }
}







