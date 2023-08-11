using Atomic.Declarative;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    internal sealed class TargetFinder : MonoBehaviour
    {
        private readonly HashSet<Transform> _targets = new();

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            if (!_targets.Contains(other.transform))
                _targets.Add(other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy"))
                _targets.Remove(other.transform);
        }

        internal Transform GetNearestEnemy()
        {
            var distance = float.MaxValue;
            Transform target = null;

            foreach (var t in _targets)
            {
                if (!t) continue;

                var hp = t.GetComponent<Entity>().Get<HitPointsComponent>();
                if (hp.CurrentHitPoints <= 0) continue;


                var dist = (t.position - transform.position).sqrMagnitude;
                if (dist < distance)
                {
                    distance = dist;
                    target = t;
                }
            }

            return target;
        }
    }
}
