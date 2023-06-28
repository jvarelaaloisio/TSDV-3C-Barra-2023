using System;
using UnityEngine;

namespace Audio
{
    public class GetReference : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        private AudioManager audioManager;
        private void Start()
        {
            audioManager = GetComponent<AudioManager>();

            audioManager.audioSource = audioSource;
        }
    }
}
