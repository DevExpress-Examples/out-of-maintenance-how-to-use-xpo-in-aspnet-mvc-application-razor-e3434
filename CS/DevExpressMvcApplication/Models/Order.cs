using DevExpress.Xpo;

public class Order :XPObject {
    public Order(Session session) : base(session) { }

    private string fName;
    public string Name {
        get { return fName; }
        set { SetPropertyValue("Name", ref fName, value); }
    }

    private Customer fCustomer;
    [Association("Customer-Orders"), Aggregated]
    public Customer Customer {
        get { return fCustomer; }
        set { SetPropertyValue("Customer", ref fCustomer, value); }
    }
}