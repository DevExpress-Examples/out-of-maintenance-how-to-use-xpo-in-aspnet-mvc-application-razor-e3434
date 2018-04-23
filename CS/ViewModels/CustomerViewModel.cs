public class CustomerViewModel : BaseViewModel<Customer> {
    public string Name { get; set; }

    public override void GetData(Customer model) {
        model.Name = Name;
    }
}
