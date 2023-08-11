using Game.Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;


namespace Game
{
    internal sealed class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;

        private PlayerProvider _playerProvider;
        private DeathComponent _deathComponent;

        [Inject]
        public void Construct(PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        private void Start()
        {
            _deathComponent =
                _playerProvider.GetPlayer().Get<DeathComponent>();

            _deathComponent.OnDie += ShowScreen;
        }

        private void ShowScreen()
        {
            gameOverPanel.SetActive(true);
        }

        public void ClickOnRestart()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
    }
}
