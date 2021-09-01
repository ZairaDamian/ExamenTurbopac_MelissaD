using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Empleado
    {

        public int IdEmpleado { get; set; }

        [Required(ErrorMessage = "Ingrese el Nombre del empleado")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingrese Apellido Paterno del empleado")]
        public string ApellidoPaterno { get; set; }


        [Required(ErrorMessage = "Ingrese el Apellido Materno del empleado")]
        public string ApellidoMaterno { get; set; }


        [Required(ErrorMessage = "Seleccione el género del empleado")]
        public string Genero { get; set; }

        public bool Estatus { get; set; }
        public List<object> Empleados { get; set; }
    }
}
