using Atomic.Declarative;
using UnityEngine;


namespace Game.Player
{
    internal sealed class PlayerProvider : MonoBehaviour
    {
        [SerializeField] private PlayerEntity player;

        public Entity GetPlayer()
        {
            return player;
        }
    }
}
