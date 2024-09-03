using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdminGym.Domain.Exceptions;
public class NotFoundException
    : Exception
{
    public NotFoundException(string entityName, object key)
        : base($"Entidad \"{entityName}\" con clave ({key}) no encontrada.")
    {
    }
}
