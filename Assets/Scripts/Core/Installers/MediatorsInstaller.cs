using Zenject;

namespace VD
{
    public class MediatorsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAbilityMediator();
            BindGamePlayMediator();
            BindGameTransitionMediator();
        }

        private void BindAbilityMediator()
        {
            Container.Bind<AbilityMediator>().AsSingle();
        }

        private void BindGamePlayMediator()
        {
            Container.Bind<GamePlayMediator>().AsSingle();
        }
        private void BindGameTransitionMediator()
        {
            Container.Bind<TransitionSceneMediator>().AsSingle();
        }

    }
}
