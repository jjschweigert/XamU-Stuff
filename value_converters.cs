public class PasswordStrengthConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        PasswordStrength pwdstr = (PasswordStrength)value;
        ...
        return Color.Red;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        Color pwdstr = (Color)value;
        ...
        return new PasswordStrength();

        OR

        throw new NotSupportedException();
    }

    public CreateBindingWithConverter()
    {
        var binding = new Binding("PasswordStrength")
        {
            Converter = new PasswordStrengthConverter()
        };
    }
}