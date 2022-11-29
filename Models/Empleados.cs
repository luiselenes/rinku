﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rinku.Models
{
    public class Empleados
    {
        [Key]
        public int num_empleados { set; get; }
        public string nombre { set; get; }
        public string appaterno { get; set; }
        public string apmaterno { get; set; }
        public string rol { get; set; } 
        public bool activo { get; set; }

    }
}
