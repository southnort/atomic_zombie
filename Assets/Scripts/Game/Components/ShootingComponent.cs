using Atomic;


namespace Game
{
    internal sealed class ShootingComponent
    {
        private readonly AtomicAction _onShoot;


        public ShootingComponent(AtomicAction shootAction)
        {
            _onShoot = shootAction;
        }

        public void Shoot()
        {
            _onShoot?.Invoke();
        }
    }
}
