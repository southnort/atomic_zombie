using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game
{
    [Serializable]
    internal sealed class BulletModel_Core
    {
        [SerializeField]
        public Timer Timer;

        [Section]
        [SerializeField]
        public MoveSection Mover;
                
       
        [Section]
        [SerializeField]
        public CollisionSection Collision;

       
        [SerializeField]
        public DamageDealer DamageDealer;
    }
}
