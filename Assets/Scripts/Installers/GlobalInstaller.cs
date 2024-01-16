using UnityEngine;
using Zenject;

namespace VD
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
        }

        private void BindInput()
        {
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }
    }
}
