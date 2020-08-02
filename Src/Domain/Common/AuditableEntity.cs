using System;

namespace RiSAT.Eshop.Domain.Common
{
    public abstract class AuditableEntity : IAuditableEntity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
