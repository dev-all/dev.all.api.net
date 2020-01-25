using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Api.DataAccess.Contracts.Entities
{
  public  class UserEntity
    {
        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public Boolean Google { get; set; }
        public Boolean Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
