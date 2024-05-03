namespace AbsoluteLayoutMauiTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            
            window.Title = "Test AbsoluteLayout";

            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                var displayInfo = DeviceDisplay.MainDisplayInfo;
                window.MinimumWidth = 1000;
                window.MinimumHeight = 800;
                window.Width = 1000;
                window.Height = 800;
                window.X = (displayInfo.Width - window.Width) / 2;
                window.Y = (displayInfo.Height - window.Height) / 2;
            }

            return window;
        }
    }
}
