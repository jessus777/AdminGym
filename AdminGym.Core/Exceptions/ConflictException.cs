﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminGym.Domain.Exceptions;
public class ConflictException
    : Exception
{
    public ConflictException(string message)
            : base(message)
    {
    }

    public ConflictException(string entityName, object key)
        : base($"Se ha producido un conflicto con la entidad \"{entityName}\" con clave ({key}).")
    {
    }
}
