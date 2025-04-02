using Providers;
using Services.WeatherService;
using ToastMessageService;
using Utils;
using Zenject;

namespace Configurations.DCInstaller
{
    public class DependencyConfigurations : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<OpenMetroWeatherUtil>().AsTransient();
            Container.BindInterfacesTo<WeatherService>().AsTransient();
            Container.Bind<LocationProvider>().AsSingle();
            Container.BindInterfacesTo<ToastService>().AsSingle();
        }
    }
}
