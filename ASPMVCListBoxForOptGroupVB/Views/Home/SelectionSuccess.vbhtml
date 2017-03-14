
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>SelectionSuccess</title>
</head>
<body>
    <div> 
        @If ViewData("SelectedStates") IsNot Nothing Then
             @<h2>Selected States</h2>
             @<ul>
                  @For Each item As String In DirectCast(ViewData("SelectedStates"), List(Of String))
                     @<li>@item</li>
                  Next
             </ul>
        End If
    </div>
</body>
</html>
