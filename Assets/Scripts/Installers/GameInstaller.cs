using Zenject;

namespace VD
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputHandler>().AsSingle();
        }
    }
}
