using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rinku.Models
{
    public class Movimiento_mes
    {
        [Key]
        public int id_mv { set; get; }
        public int num_empleados { set; get; }
        public string mes { get; set; }
        public int catidad_entregas { get; set; }
        public double horas_trabajadas { get; set; }
        public double pago_entregas { get; set; }
        public double pago_bono { get; set; }
        public double vale { get; set; }
        public double ISR { get; set; }
        public double sueldo_total { get; set; }

    }
}