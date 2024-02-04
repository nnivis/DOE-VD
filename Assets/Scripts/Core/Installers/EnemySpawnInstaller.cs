using UnityEngine;
using Zenject;

namespace VD
{
    public class EnemySpawnInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>().AsSingle();
        }
    }
}
