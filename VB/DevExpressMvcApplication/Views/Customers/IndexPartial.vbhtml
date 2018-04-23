@Code
    Html.DevExpress().GridView( _
        Sub(s)
                s.Name = "viewCustomers"
                s.CallbackRouteValues = New With {.Controller = "Customers", .Action = "IndexPartial"}
                s.Columns.Add("Name")
                s.CommandColumn.Visible = True
                s.CommandColumn.EditButton.Visible = True
                s.CommandColumn.CancelButton.Visible = True
                s.CommandColumn.DeleteButton.Visible = True
                s.CommandColumn.NewButton.Visible = True
                s.KeyFieldName = "ID"
                s.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Customers", .Action = "EditCustomer"}
                s.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Customers", .Action = "DeleteCustomer"}
                s.SettingsEditing.AddNewRowRouteValues = New With { .Controller = "Customers", .Action = "EditCustomer" }
                s.SettingsEditing.Mode = GridViewEditingMode.EditForm
    End Sub).Bind(Model).GetHtml()
End Code