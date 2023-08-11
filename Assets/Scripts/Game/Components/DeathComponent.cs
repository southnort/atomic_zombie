using System;


namespace Game
{
    [Serializable]
    internal sealed class DeathComponent
    {
        public event Action OnDie;

        public DeathComponent(LifeSection life)
        {
            life.isDead.OnChanged += (dead) =>
            {
                if (dead)
                    OnDie?.Invoke();
            };
        }
    }
}
