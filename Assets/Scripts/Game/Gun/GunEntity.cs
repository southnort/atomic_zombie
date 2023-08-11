using Atomic.Declarative;
using UnityEngine;


namespace Game.Gun
{
    internal sealed class GunEntity : Entity
    {
        [SerializeField]
        public GunModel Model;



        private void Awake()
        {
            Add(new BulletsCountComponent(Model.Core.BulletsCount));
        }
    }
}
