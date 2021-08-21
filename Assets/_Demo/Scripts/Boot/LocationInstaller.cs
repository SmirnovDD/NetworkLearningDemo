using Demo.MovementControlService;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private ThirdPersonCamera _thirdPersonCamera;
        
        public override void InstallBindings()
        {
            Container.Bind<IThirdPersonCamera>().To<ThirdPersonCamera>().FromInstance(_thirdPersonCamera).AsSingle();
        }
    }
}