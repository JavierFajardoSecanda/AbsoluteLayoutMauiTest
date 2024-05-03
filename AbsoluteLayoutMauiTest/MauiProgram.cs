using AbsoluteLayoutMauiTest.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AbsoluteLayoutMauiTest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePrism(prism =>
                {
                    prism
                        .RegisterTypes(container =>
                        {
                            container.RegisterForNavigation<MainPage, MainPageViewModel>();
                        })
                        .OnAppStart(navigationService =>
                            navigationService.CreateBuilder()
                                .AddNavigationPage()
                                .AddSegment(nameof(MainPage))
                                .NavigateAsync());
                    prism.OnInitialized(container => {
                        var eventAggregator = container.Resolve<IEventAggregator>();
                        eventAggregator.GetEvent<NavigationRequestEvent>().Subscribe(context => {
                            Debug.WriteLine($"{nameof(NavigationRequestEvent)}: Uri={context.Uri}, Parameters={context.Parameters}, Success={context.Result.Success}, Error={context.Result.Exception}.");
                            if (context.Result.Success == false) Debugger.Break();
                        });
                    });
                })
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
