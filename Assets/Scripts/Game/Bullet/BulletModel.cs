using Atomic.Declarative;
using UnityEngine;


namespace Game
{
    internal sealed class BulletModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        public BulletModel_Core Core;
    }
}
