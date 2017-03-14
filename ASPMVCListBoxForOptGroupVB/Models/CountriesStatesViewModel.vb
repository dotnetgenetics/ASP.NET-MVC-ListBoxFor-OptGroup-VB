Imports System.Web
Imports System.Web.Mvc

Public Class CountriesStatesViewModel
    Public Property SelectedStates() As IEnumerable(Of String)
    Public Property CountriesAndStates() As Dictionary(Of String, IEnumerable(Of SelectListItem))
End Class
