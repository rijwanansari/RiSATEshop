using System;
using System.Collections.Generic;
using System.Text;

namespace RiSAT.Eshop.Domain.Common
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
