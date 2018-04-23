@Code
    Html.DevExpress().GridView( _
        Sub(s)
                s.Name = "viewOrders"
                s.CallbackRouteValues = New With {.Controller = "Orders", .Action = "IndexPartial"}
                s.Columns.Add("Name")
                s.Columns.Add( _
                    Sub(settings)
                            settings.Name = "colCustomerRef"
                            settings.FieldName = "Customer"
                            settings.Caption = "Customer Name"
                            settings.ColumnType = MVCxGridViewColumnType.ComboBox
                            Dim properties As ComboBoxProperties = CType(settings.PropertiesEdit, ComboBoxProperties)
                            properties.DataSource = Model.CustomersLookUpData
                            properties.ValueField = "ID"
                            properties.TextField = "Name"
                            properties.ValueType = GetType(Integer)
                    End Sub)
                s.CommandColumn.Visible = True
                s.CommandColumn.EditButton.Visible = True
                s.CommandColumn.CancelButton.Visible = True
                s.CommandColumn.DeleteButton.Visible = True
                s.CommandColumn.NewButton.Visible = True
                s.KeyFieldName = "ID"
                s.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Orders", .Action = "EditOrder"}
                s.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Orders", .Action = "DeleteOrder"}
                s.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Orders", .Action = "EditOrder"}
                s.SettingsEditing.Mode = GridViewEditingMode.EditForm
        End Sub).Bind(Model.Source).GetHtml()
End Code
