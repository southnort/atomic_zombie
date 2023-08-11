using Game.Player;
using TMPro;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class PlayerHpObserver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hitPointsTmp;
        private HitPointsComponent _playerLifeComponent;
        private PlayerProvider _playerProvider;

        [Inject]
        public void Construct(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        private void Start()
        {
            _playerLifeComponent = _playerProvider.GetPlayer().Get<HitPointsComponent>();

            _playerLifeComponent.OnHitPointsChanged += UpdateHp;

            UpdateHp(_playerLifeComponent.CurrentHitPoints);
        }

        private void UpdateHp(int hitPoints)
        {
            var infoString = $"HIT POINTS: {hitPoints}";
            hitPointsTmp.text = infoString;
        }
    }
}
