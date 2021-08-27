<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128567198/15.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3434)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [BaseXpoController.cs](./CS/Controllers/BaseXpoController.cs) (VB: [BaseXpoController.vb](./VB/Controllers/BaseXpoController.vb))
* [CustomersController.cs](./CS/Controllers/CustomersController.cs) (VB: [CustomersController.vb](./VB/Controllers/CustomersController.vb))
* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [OrdersController.cs](./CS/Controllers/OrdersController.cs) (VB: [OrdersController.vb](./VB/Controllers/OrdersController.vb))
* [XpoHelper.cs](./CS/Helpers/XpoHelper.cs) (VB: [XpoHelper.vb](./VB/Helpers/XpoHelper.vb))
* [Customer.cs](./CS/Models/Customer.cs) (VB: [CustomerViewModel.vb](./VB/ViewModels/CustomerViewModel.vb))
* [Order.cs](./CS/Models/Order.cs) (VB: [OrdersViewModel.vb](./VB/ViewModels/OrdersViewModel.vb))
* [BaseViewModel.cs](./CS/ViewModels/BaseViewModel.cs) (VB: [BaseViewModel.vb](./VB/ViewModels/BaseViewModel.vb))
* [CustomerViewModel.cs](./CS/ViewModels/CustomerViewModel.cs) (VB: [CustomerViewModel.vb](./VB/ViewModels/CustomerViewModel.vb))
* [OrdersViewModel.cs](./CS/ViewModels/OrdersViewModel.cs) (VB: [OrdersViewModel.vb](./VB/ViewModels/OrdersViewModel.vb))
* [OrderViewModel.cs](./CS/ViewModels/OrderViewModel.cs) (VB: [OrderViewModel.vb](./VB/ViewModels/OrderViewModel.vb))
* [Index.cshtml](./CS/Views/Customers/Index.cshtml)
* [IndexPartial.cshtml](./CS/Views/Customers/IndexPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
* [Index.cshtml](./CS/Views/Orders/Index.cshtml)
* [IndexPartial.cshtml](./CS/Views/Orders/IndexPartial.cshtml)
* **[_Layout.cshtml](./CS/Views/Shared/_Layout.cshtml)**
<!-- default file list end -->
# How to use XPO in ASP.NET MVC application (Razor)


<p>This example demonstrates how to create a simple ASP.NET MVC application using XPO as Data Access Layer. The solution used in this example is explained in paragraph #2 of the <a href="https://www.devexpress.com/Support/Center/p/K18525">How to use XPO in an ASP.NET MVC application</a> Knowledge Base article.<br><br>The approach to connect XPO to the database used in this example is described in detail in the following Knowledge Base article: <a href="https://www.devexpress.com/Support/Center/p/K18061">How to use XPO in an ASP.NET (Web) application</a>.<br><br>To separate the business logic from the object persistence layer, Views are bound to special classes inherited from the BaseViewModel<T> class declared in the example. These classes describe the View's model and implement the automatic synchronization of values changed by the user with underlying business objects. The synchronization is implemented in the overridden abstract GetData method. This is the place where you can convert data from the View's structure to the structure of your business objects mapped to corresponding tables in the database. In this method, you can access the <a href="https://documentation.devexpress.com/#CoreLibraries/CustomDocument2022">XPO Session</a> object and use its methods (such as <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXpoSession_GetObjectByKey~ClassType~topic">GetObjectByKey</a>, <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXpoSession_FindObject~ClassType~topic">FindObject</a>, delete or create persistent objects, if necessary). For example:</p>


```cs
using System.Collections.Generic;

public class OrderViewModel :BaseViewModel<Order> {
    public string Name { get; set; }
    public int Customer { get; set; }

    public override void GetData(Order model) {
        model.Name = Name;
        model.Customer = model.Session.GetObjectByKey<Customer>(Customer);
    }
}
```


<p>To load persistent objects from the database and transform them into View's models, we suggest using the <a href="https://documentation.devexpress.com/#CoreLibraries/CustomDocument4060">LINQ to XPO</a> feature. It will allow you to filter, sort, group data on the server side and easily convert loaded objects into an appropriate structure. For example:</p>


```cs
OrdersViewModel GetOrders() {
	return new OrdersViewModel() {
		Source = (from o in XpoSession.Query<Order>().ToList()
					select new OrderViewModel() {
						ID = o.Oid, Name = o.Name, Customer = o.Customer.Oid
					}).ToList(),
		CustomersLookUpData = (from c in XpoSession.Query<Customer>().ToList()
								select new CustomerViewModel() {
									ID = c.Oid, Name = c.Name
								}).ToList()
		};
}
```


<p>Note that LINQ to XPO is not the only approach you can use here. Refer to the following article to learn more about different approaches to query data using the XPO Session: <a href="https://documentation.devexpress.com/#CoreLibraries/CustomDocument2034">Querying a Data Store</a>.<br><br>For your convenience, we suggest that you inherit your controllers from the BaseXpoController<T> class declared in this example. This controller encapsulates the object persistence logic and allows you to save changes by calling its Save and Delete methods.</p>
<p><strong>See also: <br></strong><a href="https://www.devexpress.com/Support/Center/p/A2944">XPO Best Practices</a><br><a href="https://documentation.devexpress.com/#CoreLibraries/CustomDocument2263">XPO Getting Started</a><br><a href="http://stackoverflow.com/questions/11064316/what-is-viewmodel-in-mvc">What is ViewModel in MVC?</a></p>

<br/>


