using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class Timer : IUpdateListener
    {
        [SerializeField] private float timerTime;
        private float _currentTime;

        private event Action OnTimerEnd;


        public void StartTimer(Action onTimerEndCallback)
        {
            OnTimerEnd = onTimerEndCallback;
            _currentTime = timerTime;
        }


        void IUpdateListener.Update(float deltaTime)
        {
            _currentTime -= deltaTime;

            if (_currentTime <= 0)
            {
                OnTimerEnd?.Invoke();
                OnTimerEnd = null;
            }
        }
    }
}
