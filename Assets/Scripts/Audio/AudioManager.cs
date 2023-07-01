using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        public AudioSource AudioSource { get; set; }
        
        /// <summary>
        /// Plays an audioclip in the audio source
        /// </summary>
        /// <param name="audioClip"> Audio source in player </param>
        public void PlaySound(AudioClip audioClip)
        {
            AudioSource.PlayOneShot(audioClip);
        }
    }
}