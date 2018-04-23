<!DOCTYPE HTML>
<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Chart},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report}
    )
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    @Html.DevExpress().GetScripts(
        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
        New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor},
        New Script With {.ExtensionSuite = ExtensionSuite.GridView},
        New Script With {.ExtensionSuite = ExtensionSuite.Editors},
        New Script With {.ExtensionSuite = ExtensionSuite.Chart},
        New Script With {.ExtensionSuite = ExtensionSuite.Report}
    )
</head>
<body>
    <table>
        <tr>
            <td>
                @Code
                    Html.DevExpress().NavBar( _
                        Sub(s)
                                s.Name = "NavigationBar"
                                Dim g As MVCxNavBarGroup = s.Groups.Add("View")
                                g.Items.Add(New MVCxNavBarItem("View Customers", "nbiViewCustomers", String.Empty, "Customers"))
                                g.Items.Add(New MVCxNavBarItem("View Orders", "nbiViewOrders", String.Empty, "Orders"))
                        End Sub).Render()
                End Code
            </td>
            <td>
                @RenderBody()
            </td>
        </tr>
    </table>
</body>
</html>
