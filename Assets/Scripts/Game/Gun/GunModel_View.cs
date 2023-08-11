using Atomic.Declarative;
using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class GunModel_View
    {
        [SerializeField]
        public GunSoundsController SoundsController;

        [SerializeField]
        public ParticleSystem ParticleSystem;


        [Construct]
        public void Construct(GunModel_Core core)
        {
            core.Shooting.OnShoot += () => ParticleSystem.Play();
            core.Shooting.OnShoot += SoundsController.PlayShot;
            core.Shooting.OnNoAmmoShot += SoundsController.PlayNoAmmo;
            core.GunReloader.OnGunReloaded += SoundsController.PlayReload;
        }
    }
}
