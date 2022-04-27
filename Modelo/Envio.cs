using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Envio
    {
        public string CodigoEnvio { get; set; }
        public string Remitente { get; set; }
        public string Descripcion { get; set; }
        public string DireccionEntrega { get; set; }
        public DateTime FechaEnvio { get; set; }
        public decimal Tarifa { get; set; } = 100;
        public decimal Impuesto { get; set; } = 15;
        public decimal SubTotal { get; set; } = decimal.Zero;
        public decimal Total { get; set; } = 115;

    }
}
