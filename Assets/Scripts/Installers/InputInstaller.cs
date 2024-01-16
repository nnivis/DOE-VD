using Zenject;

namespace VD
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputHandler>().AsSingle();
        }
    }
}
