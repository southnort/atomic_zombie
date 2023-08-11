using Atomic.Declarative;
using Game.Player;
using UnityEngine;


namespace Game.Gun
{
    internal sealed class GunModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        public GunModel_Core Core;

        [Section]
        [SerializeField]
        public GunModel_View View;
    }
}
