using Zenject;

namespace VD
{
    public class MediatorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAbilityMediator();
            BindGamePlayMediator();
        }

        private void BindAbilityMediator()
        {
            Container.Bind<AbilityMediator>().AsSingle();
        }

        private void BindGamePlayMediator()
        {
            Container.Bind<GamePlayMediator>().AsSingle();
        }

    }
}
