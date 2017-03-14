Option Strict On
Option Explicit On
Option Infer On

Imports System.Web.Mvc
Imports ASPMVCListBoxForOptGroupVB
Public Class HomeController
    Inherits Controller

    ' GET: /Home
    Function Index() As ActionResult
        Dim model As New CountriesStatesViewModel
        Dim items As New Dictionary(Of String, IEnumerable(Of SelectListItem))
        model.CountriesAndStates = New Dictionary(Of String, IEnumerable(Of SelectListItem))

        items.Add("US", New List(Of SelectListItem)() From { _
            New SelectListItem() With {.Text = "Arizona", .Value = "001", .Selected = False},
            New SelectListItem() With {.Text = "Montana", .Value = "002", .Selected = False}
        })

        items.Add("AU", New List(Of SelectListItem)() From { _
            New SelectListItem() With {.Text = "Queensland", .Value = "003", .Selected = False},
            New SelectListItem() With {.Text = "Victoria", .Value = "004", .Selected = False}
        })

        items.Add("BR", New List(Of SelectListItem)() From { _
            New SelectListItem() With {.Text = "Bahia", .Value = "005", .Selected = False},
            New SelectListItem() With {.Text = "Minas Gerais", .Value = "006", .Selected = False}
        })

        model.CountriesAndStates = items

        Return View(model)
    End Function

    <HttpPost>
    Function SaveEntry(SelectedStates As IEnumerable(Of String)) As ActionResult
        If SelectedStates IsNot Nothing Then
            If SelectedStates.Count() > 0 Then
                TempData("list") = SelectedStates.ToList()
                Return RedirectToAction("SelectionSuccess")
            End If
        End If

        Return RedirectToAction("Index")
    End Function

    Function SelectionSuccess() As ActionResult
        ViewData("SelectedStates") = DirectCast(TempData("list"), List(Of String))
        Return View()

    End Function
End Class