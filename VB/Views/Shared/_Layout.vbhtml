<!DOCTYPE html>
<html>
<head>
    <title>E3434Mvc4</title>

    @Html.DevExpress().GetScripts(
        New Script With {.ExtensionSuite = ExtensionSuite.Editors},
        New Script With {.ExtensionSuite = ExtensionSuite.GridView},
        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}
)
    
    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}
)
</head>
  
<body>
    <table>
        <tr>
            <td>
                @Html.DevExpress().NavBar( _
                    Sub(s)
                            s.Name = "NavigationBar"
                            s.Groups.Add("View").Items.AddRange(New NavBarItem() {
                                New MVCxNavBarItem("View Customers", "nbiViewCustomers", String.Empty, "Customers"),
                                New MVCxNavBarItem("View Orders", "nbiViewOrders", String.Empty, "Orders")
                            })
                    End Sub).GetHtml()
            </td>
            <td>
                @RenderBody()
            </td>
        </tr>
    </table>
</body>
</html>