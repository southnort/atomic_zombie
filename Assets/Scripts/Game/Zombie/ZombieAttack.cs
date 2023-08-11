using Atomic;
using Atomic.Declarative;
using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace Game
{
    [Serializable]
    internal sealed class ZombieAttack : IUpdateListener
    {
        [SerializeField] private int damage;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackCooldown;
        private float _currentAttackCooldown;

        private Transform _rootTransform;
        private LifeSection _life;

        private Entity _targetEntity;
        private TakeDamageComponent _enemy;
        private HitPointsComponent _targetHitPoints;

        public AtomicEvent OnAttack;

        public void Construct(Transform rootTransform, LifeSection life)
        {
            _rootTransform = rootTransform;
            _life = life;
        }

        public void SetTarget(Entity targetEntity)
        {
            _targetEntity = targetEntity;
            _enemy = _targetEntity.Get<TakeDamageComponent>();
            _targetHitPoints = _targetEntity.Get<HitPointsComponent>();
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (_life.isDead.Value) return;
            if (!_targetEntity || _targetHitPoints.CurrentHitPoints < 0) return;

            _currentAttackCooldown -= deltaTime;

            var distance = (_rootTransform.position - _targetEntity.transform.position).sqrMagnitude;
            if (distance < (attackRange * attackRange))
            {
                Attack();
            }
        }

        private void Attack()
        {
            if (!(_currentAttackCooldown <= 0)) return;
            OnAttack?.Invoke();
            _currentAttackCooldown = attackCooldown;
        }

        public void DealDamage()
        {
            if (!_targetEntity) return;
            _enemy.TakeDamage(damage);
        }
    }
}
