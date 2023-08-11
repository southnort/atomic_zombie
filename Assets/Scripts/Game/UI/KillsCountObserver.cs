using TMPro;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class KillsCountObserver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI killsCountTmp;
        private KillsCounter _killsCounter;

        [Inject]
        public void Construct(KillsCounter killsCounter)
        {
            _killsCounter = killsCounter;
        }

        private void Start()
        {
            _killsCounter.OnKillsCountChanged += UpdateKills;
            UpdateKills(0);
        }

        private void UpdateKills(int killsCount)
        {
            var infoString = $"KILLS: {killsCount}";
            killsCountTmp.text = infoString;
        }
    }
}
