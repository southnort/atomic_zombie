using System;
using UnityEngine;


namespace Game.Gun
{
    [Serializable]
    internal sealed class GunSoundsController
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip shotSound;
        [SerializeField] private AudioClip noAmmoSound;
        [SerializeField] private AudioClip reloadSound;



        internal void PlayShot()
        {
            audioSource.clip = shotSound;
            audioSource.Play();
        }

        internal void PlayNoAmmo()
        {
            audioSource.clip = noAmmoSound;
            audioSource.Play();
        }     

        internal void PlayReload()
        {
            audioSource.clip = reloadSound;
            audioSource.Play();
        }
    }
}
