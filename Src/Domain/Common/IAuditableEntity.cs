using System;
using System.Collections.Generic;
using System.Text;

namespace RiSAT.Eshop.Domain.Common
{
    public interface IAuditableEntity
    {
        DateTime Created { get; set; }

        string CreatedBy { get; set; }

        DateTime? LastModified { get; set; }

        string LastModifiedBy { get; set; }
    }
}
