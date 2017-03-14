Option Strict On
Option Explicit On
Option Infer On

Imports System.Runtime.CompilerServices
Imports System.Web.Mvc
Imports System.Linq.Expressions
Imports System.Web.Routing

Public Module HtmlExtensions

    <Extension()>
    Public Function ListBoxFor(Of TModel, TProperty)(htmlHelper As HtmlHelper(Of TModel), expression As Expression(Of Func(Of TModel, TProperty)), _
                            selectList As Dictionary(Of String, IEnumerable(Of SelectListItem)), Optional htmlAttributes As Object = Nothing) As IHtmlString

        Dim selectTag = New TagBuilder("select")
        selectTag.Attributes.Add("name", ExpressionHelper.GetExpressionText(expression))

        If htmlAttributes IsNot Nothing Then
            Dim routeValues As New RouteValueDictionary(htmlAttributes)
            If Not routeValues.ContainsKey(("size").ToLower()) Then
                selectTag.Attributes.Add("size", selectList.Sum(Function(x) x.Value.Count()).ToString())
            End If

            For Each item In routeValues
                selectTag.Attributes.Add(item.Key, item.Value.ToString())
            Next
        Else
            selectTag.Attributes.Add("size", selectList.Sum(Function(x) x.Value.Count()).ToString())
        End If

        Dim optgroups = New StringBuilder()

        For Each kvp In selectList
            Dim optgroup = New TagBuilder("optgroup")
            optgroup.Attributes.Add("label", kvp.Key)

            Dim options = New StringBuilder()

            For Each item In kvp.Value
                Dim optionTag = New TagBuilder("option")

                optionTag.Attributes.Add("value", item.Value)
                optionTag.SetInnerText(item.Text)

                If item.Selected Then
                    optionTag.Attributes.Add("selected", "selected")
                End If

                options.Append(optionTag.ToString(TagRenderMode.Normal))
            Next

            optgroup.InnerHtml = options.ToString()

            optgroups.Append(optgroup.ToString(TagRenderMode.Normal))
        Next

        selectTag.InnerHtml = optgroups.ToString()

        Return MvcHtmlString.Create(selectTag.ToString(TagRenderMode.Normal))

    End Function
End Module
