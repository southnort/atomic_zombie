using Game.Player;
using TMPro;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class BulletsCountObserver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bulletsCountTmp;
        private BulletsCountComponent _bulletsCount;
        private PlayerProvider _playerProvider;

        [Inject]
        public void Construct(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        private void Start()
        {
            _bulletsCount = _playerProvider.GetPlayer().Get<IGunComponent>().Entity.Get<BulletsCountComponent>();
            _bulletsCount.OnBulletsCountChanged += UpdateBulletsCount;
            UpdateBulletsCount(_bulletsCount.CurrentBulletsCount);
        }


        private void UpdateBulletsCount(int currentBullets)
        {
            var maxBullets = _bulletsCount.MaxBulletsCount;
            var infoString =
                $"BULLETS: {currentBullets}/{maxBullets}";
            bulletsCountTmp.text = infoString;
        }
    }
}
