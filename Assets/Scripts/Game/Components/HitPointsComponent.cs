using System;


namespace Game
{
    [Serializable]
    internal sealed class HitPointsComponent
    {
        public event Action<int> OnHitPointsChanged;
        private readonly LifeSection _life;

        public int CurrentHitPoints => _life.hitPoints.Value;


        public HitPointsComponent(LifeSection life)
        {
            _life = life;
            _life.hitPoints.OnChanged += (hp) =>
            {
                OnHitPointsChanged?.Invoke(hp);
            };
        }
    }
}
