using Xamarin.Forms;

namespace StellaFiesta.Client.Controls
{
    public class IntelligentButton : Button
    {
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(
            propertyName: nameof(Padding),
            returnType: typeof(Thickness),
            declaringType: typeof(IntelligentButton),
            defaultValue: new Thickness(0, 0, 0, 0));

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
    }
}
