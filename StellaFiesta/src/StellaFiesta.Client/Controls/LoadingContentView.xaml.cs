using Xamarin.Forms;

namespace StellaFiesta.Client.Controls
{
    // https://xamarinhelp.com/xamarin-forms-page-templates/
    public partial class LoadingContentView : ContentView
    {
        public LoadingContentView()
        {
            InitializeComponent();

            Root.BackgroundColor = Color.Gray.MultiplyAlpha(0.1);
            IsVisible = false;
        }

        public static BindableProperty LoadingTextProperty =
            BindableProperty.Create(
                propertyName: nameof(LoadingText),
                returnType: typeof(string),
                declaringType: typeof(LoadingContentView),
                defaultValue: string.Empty,
                propertyChanged: OnLoadingTextChanged);

        public static BindableProperty IsLoadingProperty =
            BindableProperty.Create(
                nameof(IsLoading),
                typeof(bool),
                typeof(LoadingContentView),
                defaultValue: false,
                propertyChanged: OnIsLoadingChanged);

        public string LoadingText
        {
            get { return (string)GetValue(LoadingTextProperty); }
            set { SetValue(LoadingTextProperty, value); }
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        private static void OnLoadingTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoadingContentView)bindable;
            var text = (string)newValue;

            control.loadingLabel.Text = text;
        }

        private static void OnIsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoadingContentView)bindable;
            var isVisible = (bool)newValue;

            FadeControl(control, isVisible);
        }

        private async static void FadeControl(LoadingContentView control, bool toBecomeVisible)
        {
            if (toBecomeVisible)
            {
                control.IsVisible = true;
                control.Opacity = 0.0;
                var isCancelled = await control.FadeTo(1.0, AnimationHelper.ControlFadeInDurationInMs);
            }
            else
            {
                var isCancelled = await control.FadeTo(0.0, AnimationHelper.ControlFadeOutDurationInMs);
                control.IsVisible = false;
            }
        }
    }
}
