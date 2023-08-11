using System;


namespace Game
{
    [Serializable]
    internal sealed class BulletsCountComponent
    {
        public event Action<int> OnBulletsCountChanged;
        public int CurrentBulletsCount => _bulletsCount.CurrentBulletsCount.Value;
        public int MaxBulletsCount => _bulletsCount.MaxBulletsCount.Value;

        private readonly GunBulletsCount _bulletsCount;


        public BulletsCountComponent(GunBulletsCount bulletsCount)
        {
            _bulletsCount = bulletsCount;

            _bulletsCount.CurrentBulletsCount.OnChanged += (count) =>
            {
                OnBulletsCountChanged?.Invoke(count);
            };
        }
    }
}
