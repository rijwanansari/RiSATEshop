using System;
using RiSAT.Eshop.Common;

namespace RiSAT.Eshop.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
