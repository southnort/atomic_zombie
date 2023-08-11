using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class GunBulletsCount : IStartListener
    {
        [SerializeField]
        public AtomicVariable<int> MaxBulletsCount;

        public AtomicVariable<int> CurrentBulletsCount;

        void IStartListener.Start()
        {
            CurrentBulletsCount.Value = MaxBulletsCount.Value;
        }
    }
}
