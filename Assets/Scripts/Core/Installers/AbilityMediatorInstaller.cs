using Zenject;

namespace VD
{
    public class AbilityMediatorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AbilityMediator>().AsSingle();
        }
    }
}
