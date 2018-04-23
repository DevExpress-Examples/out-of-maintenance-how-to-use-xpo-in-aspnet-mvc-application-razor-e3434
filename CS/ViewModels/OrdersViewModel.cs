using System.Linq;
using System.Collections.Generic;

public class OrdersViewModel {
    public IList<OrderViewModel> Source { get; set; }
    public IList<CustomerViewModel> CustomersLookUpData { get; set; }
}
