using UnityEngine;
using Atomic.Declarative;


namespace Game.Zombie
{
    internal sealed class ZombieModel : DeclarativeModel
    {

        [Section]
        [SerializeField]
        public ZombieModel_Core Core;

        [Section]
        [SerializeField]
        public ZombieModel_View View;




        [Construct]
        public void Construct()
        {
            Core.Life.isDead.OnChanged += (dead) =>
            {
                if (dead)
                    Destroy(gameObject, 2f);
            };
        }
    }
}
