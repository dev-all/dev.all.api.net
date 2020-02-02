using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Api.ViewModels
{
    public class UserModels
    {
        //public int Id { get; set; }
        public string NombreApellido { get; set; }
        public Boolean Google { get; set; }
        public Boolean Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
