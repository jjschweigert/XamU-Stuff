/* Update a resource dictionary value */
void ChangeColor(Color NewColor)
{
    this.Resources["key"] = NewColor;
}

/* Apart from xaml binding to the static/dynamic resources, these bindings can be set at runtime as well */
void AttachProperty()
{
    Label temp = new Label { Text="Test" };

    if(Device.OS == TargetPlatform.iOS)
    {
        temp.SetDynamicResource(Label.TextColorProperty, "DictionaryKey");
    }
}

/* Create a style in codebehind */
Style GenerateStyle(object type)
{
    var s = new Style(typeof(type));
    s.Setters.Add(new Setter{ Property = Button.BackgroundProperty, Value = Color.Red });
    s.Setters.Add(new Setter{ Property = Button.BorderRadiusProperty, Value = 4 });

    return s;
}