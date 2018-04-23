using System.Collections.Generic;

public class OrderViewModel :BaseViewModel<Order> {
    public string Name { get; set; }
    public int Customer { get; set; }

    public override void GetData(Order model) {
        model.Name = Name;
        model.Customer = model.Session.GetObjectByKey<Customer>(Customer);
    }
}
