using System;


namespace Game
{
    internal sealed class KillsCounter
    {
        public event Action<int> OnKillsCountChanged;
        private int _killsCount;

        public void AddKill()
        {
            _killsCount++;
            OnKillsCountChanged?.Invoke(_killsCount);
        }
    }
}
