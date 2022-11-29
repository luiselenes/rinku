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
    public class CrearMovimientoMes : IRequest<bool>
    {
        public int num_empleados { set; get; }
        public string mes { set; get; }
        public int catidad_entregas { get; set; }
    }
  public class CrearMovimientoMesHandler : IRequestHandler<CrearMovimientoMes,bool>
    {
        private readonly rinkuContext context;
        public CrearMovimientoMesHandler(rinkuContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(CrearMovimientoMes request, CancellationToken cancellationToken)
        {
            var sueldobase = 30.0;
            var horas = 8;
            var dias = 24;
            var horasmes = horas * dias;
            var mvmes = new Movimiento_mes();
            var dtmv = context.movimientos_mes.Where(mv => mv.num_empleados == request.num_empleados && mv.mes == request.mes).FirstOrDefault();
            if (dtmv != null){
                return false;
            }
            else
            {

                mvmes.num_empleados = request.num_empleados;
                mvmes.mes = request.mes;
                mvmes.catidad_entregas = request.catidad_entregas;
                var dtemp = context.empleados.Where(emp => emp.num_empleados == request.num_empleados).FirstOrDefault();
                
                var calculosueldobase = sueldobase * horasmes;
                var calculoentras = 5.0 * request.catidad_entregas;
                var bono = 0.0;
                if(dtemp.rol == "chofer"){
                    bono = 10.0 * horasmes; 
                }
                else if(dtemp.rol == "cargador"){
                    bono = 5.0 * horasmes; 

                }
                var sueldobasetotal = calculosueldobase +  calculoentras + bono ;
                var calculovales = calculosueldobase * .4;
                var calculoisr = 0.0;
                if(sueldobasetotal < 10000){
                    calculoisr = sueldobasetotal * 0.9;
                }else{
                    calculoisr = sueldobasetotal * 0.12;
                }
                var sueldoisr = sueldobasetotal - calculoisr;

                mvmes.horas_trabajadas = horasmes;
                mvmes.pago_entregas = calculoentras;
                mvmes.pago_bono = bono;
                mvmes.ISR = calculoisr;
                mvmes.vale = calculovales;
                mvmes.sueldo_total = sueldoisr;
                
            }

            context.movimientos_mes.Add(mvmes);
            await context.SaveChangesAsync();
            return true;
        }   
    }
}


