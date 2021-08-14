using Demo.GameTime;
using Demo.InputService;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMovementInput();
            BindGameTime();
        }

        private void BindGameTime()
        {
            Container.Bind<IGameTime>().To<GameTime>().AsSingle();
        }

        private void BindMovementInput()
        {
            Container.Bind<IMovementInput>().To<MovementInput>().AsSingle();
        }
    }
}