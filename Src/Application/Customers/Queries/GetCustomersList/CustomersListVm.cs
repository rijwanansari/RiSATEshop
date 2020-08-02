using System.Collections.Generic;

namespace RiSAT.Eshop.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public IList<CustomerLookupDto> Customers { get; set; }
    }
}
