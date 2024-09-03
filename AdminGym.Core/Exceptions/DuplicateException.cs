using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Exceptions;
public class DuplicateException
    : Exception
{
    public DuplicateException(string entityName, object key)
            : base($"Entidad \"{entityName}\" con clave ({key}) ya existe.")
    {
    }
}
