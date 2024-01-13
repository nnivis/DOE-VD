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
            if (SystemInfo.deviceType == DeviceType.Handheld)
                Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();

        }
    }
}
