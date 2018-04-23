@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "viewCustomers"
            settings.CallbackRouteValues = New With {.Controller = "Customers", .Action = "IndexPartial"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Customers", .Action = "EditCustomer"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Customers", .Action = "DeleteCustomer"}
            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Customers", .Action = "EditCustomer"}
            settings.KeyFieldName = "ID"
            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowEditButton = True
            settings.CommandColumn.ShowDeleteButton = True
            settings.CommandColumn.ShowNewButton = True
            settings.Columns.Add("Name")
            settings.SettingsEditing.Mode = GridViewEditingMode.EditForm
    End Sub).Bind(Model).GetHtml()