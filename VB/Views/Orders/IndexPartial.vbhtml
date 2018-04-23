@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "viewOrders"
            settings.CallbackRouteValues = New With {.Controller = "Orders", .Action = "IndexPartial"}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Orders", .Action = "EditOrder"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Orders", .Action = "DeleteOrder"}
            settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Orders", .Action = "EditOrder"}
            settings.KeyFieldName = "ID"
            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowEditButton = True
            settings.CommandColumn.ShowDeleteButton = True
            settings.CommandColumn.ShowNewButton = True
            settings.Columns.Add("Name")
            settings.Columns.Add(Sub(column)
                                         column.Name = "colCustomerRef"
                                         column.FieldName = "Customer"
                                         column.Caption = "Customer Name"
                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                         Dim properties As ComboBoxProperties = CType(column.PropertiesEdit, ComboBoxProperties)
                                         properties.DataSource = Model.CustomersLookUpData
                                         properties.ValueField = "ID"
                                         properties.TextField = "Name"
                                         properties.ValueType = GetType(Integer)
                                 End Sub)
            settings.SettingsEditing.Mode = GridViewEditingMode.EditForm
    End Sub).Bind(Model.Source).GetHtml()