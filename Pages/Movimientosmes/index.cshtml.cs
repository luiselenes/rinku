using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using rinku.Domain;
using rinku.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace rinku.Pages.Movimientosmes
{
    public class IndexModel : PageModel 
    {
        public List<Models.Movimiento_mes> movimiento_Mes {get; set;}
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator mediator;

        public IndexModel(ILogger<IndexModel> logger, IMediator mediatr)
        {
            _logger = logger;
            mediator=mediatr;
        }
        public async Task OnGet()
        {
            var modelo = await mediator.Send( new ConsultaMovimientosMes());
            movimiento_Mes=modelo;
        }
    }
}