@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

@ModelType ASPMVCListBoxForOptGroupVB.CountriesStatesViewModel
@Imports ASPMVCListBoxForOptGroup.Helpers

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
</head>
<body>
    <div>
        @Using Html.BeginForm("SaveEntry", "Home", FormMethod.Post)
            @Html.ListBoxFor(Function(t) t.SelectedStates, Model.CountriesAndStates, New With {.Multiple = "Multiple", .Size = Model.CountriesAndStates.Sum(Function(x) x.Value.Count())})
            @<br />
            @<input name="Save" type="submit" value="Save" />
        End Using
    </div>
</body>
</html>
