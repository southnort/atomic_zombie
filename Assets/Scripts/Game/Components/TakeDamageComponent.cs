namespace Game
{
    internal sealed class TakeDamageComponent
    {
        private readonly LifeSection _life;

        public TakeDamageComponent(LifeSection life)
        {
            _life = life;
        }

        public void TakeDamage(int damage)
        {
            _life.hitPoints.Value -= damage;
        }
    }
}
