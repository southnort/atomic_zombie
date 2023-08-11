using UnityEngine;
using VContainer;
using VContainer.Unity;
using Game.Player;

namespace Game
{
    internal sealed class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private AimMover aimMover;
        [SerializeField] private PlayerProvider playerProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(playerInput);
            builder.RegisterComponent(aimMover);
            builder.RegisterComponent(playerProvider);

            builder.Register<KillsCounter>(Lifetime.Singleton);
        }
    }
}
