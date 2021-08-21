using Demo.GameTime;
using Demo.InputService;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMouseInput();
            BindMovementInput();
            BindGameTime();
        }

        private void BindMouseInput()
        {
            Container.Bind<IMouseInput>().To<MouseInput>().AsSingle();    
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