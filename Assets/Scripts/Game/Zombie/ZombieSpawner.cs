using System.Collections;
using UnityEngine;
using VContainer;
using Yrr.Utils;
using Game.Player;
using Game.Zombie;


namespace Game
{
    internal sealed class ZombieSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private ZombieEntity zombiePrefab;
        [SerializeField] private Vector2 spawnTimeMinMax;

        [Inject] private readonly PlayerProvider _playerProvider;
        [Inject] private readonly KillsCounter _killsCounter;

        private void Start()
        {
            StartCoroutine(TimeCoroutine());
        }

        private IEnumerator TimeCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(spawnTimeMinMax.x, spawnTimeMinMax.y));
                SpawnZombie();
            }
        }

        private void SpawnZombie()
        {
            var pos = spawnPoints.GetRandomItem().position;
            var zombie = Instantiate(zombiePrefab, pos, Quaternion.identity, transform);

            var lookAt = zombie.Get<LookAtTargetComponent>();
            var player = _playerProvider.GetPlayer();
            lookAt.SetTarget(player.transform);

            var moveTo = zombie.Get<MoveToPointComponent>();
            moveTo.SetTargetPoint(player.transform);

            var attack = zombie.Get<ZombieAttack>();
            attack.SetTarget(player);
        }
    }
}
