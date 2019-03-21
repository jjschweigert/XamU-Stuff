/* Set Binding Mode */
void SetBindingMode()
{
    // Using same example in xaml
    SomeEntry.SetBinding(Entry.TextProperty, new Binding("Notes")
    {
        Mode = BindingMode.TwoWay
    });
}