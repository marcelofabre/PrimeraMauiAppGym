using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeraMauiApp.Models
{
    public class Ejercicio
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string portadaUrl { get; set; }
        public string descripcion { get; set; }
        public string numerodeseries { get; set; }

        public override string ToString()
        {
            return $"{nombre} - {portadaUrl} - {numerodeseries}-{descripcion}";
        }
    }
}
