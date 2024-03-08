using Zenject;

namespace VD
{
    public class LocationInstaller : MonoInstaller
    {
        public LocationHandler locationHandler;
        public override void InstallBindings()
        {
            BindLocationHandler();
        }

        public void BindLocationHandler()
        {
            //Container.BindInterfacesAndSelfTo<LocationHandler>().FromComponentInHierarchy(locationHandler).AsSingle();

            Container.Bind<ILocationProvaider>().FromComponentInHierarchy(locationHandler).AsSingle();
        }
    }
}
