using Atomic.Declarative;
using Game.Gun;


namespace Game.Player
{
    internal sealed class PlayerModel : DeclarativeModel
    {
        [Section]
        public GunModel Gun;

        [Section]
        public PlayerModel_Core Core;

        [Section]
        public PlayerModel_View View;
    }
}
