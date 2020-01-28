using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.Business.Models
{
    public class User
    {
        //clase modelo q se enviara al client

        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public Boolean Google { get; set; }
        public Boolean Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        
        
        




    }
}
