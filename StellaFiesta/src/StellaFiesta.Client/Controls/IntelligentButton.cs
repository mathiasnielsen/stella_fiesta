using Xamarin.Forms;

namespace StellaFiesta.Client.Controls
{
    public class IntelligentButton : Button
    {
        public static readonly BindableProperty ButtonPaddingProperty = BindableProperty.Create(
            propertyName: nameof(Padding),
            returnType: typeof(Thickness),
            declaringType: typeof(IntelligentButton),
            defaultValue: new Thickness(0, 0, 0, 0));

        public Thickness ButtonPadding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
    }
}
