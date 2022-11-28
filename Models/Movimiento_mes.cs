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
        public int id_empleado { set; get; }
        public int num_mes { get; set; }
        public float horas_trabajadas { get; set; }
        public float pago_entregas { get; set; }
        public float pago_bono { get; set; }
        public float vale { get; set; }
        public float retencion { get; set; }
        public int catidad_entregas { get; set; }
        public float sueldo_total { get; set; }

    }
}
