@Imports DevExpress.Web.Mvc.UI
@Imports DevExpress.Web.Mvc

@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "myGridView"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPart"}
            settings.Width = 450
            settings.KeyFieldName = "id"

            settings.Columns.Add("id")
            settings.Columns.Add("name")
    
            settings.Settings.ShowFilterRow = True
            settings.Settings.ShowFilterRowMenu = True
            settings.PreRender = _
                Sub(sender, e)
                        Dim grid As ASPxGridView = CType(sender, ASPxGridView)
                        For Each col As GridViewDataColumn In grid.Columns
                            col.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                        Next col
                End Sub

    End Sub).Bind(Model).GetHtml()