using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviourSingleton<AudioManager>
    {
        [SerializeField] private AudioSource audioSource;
        
        /// <summary>
        /// Plays an audioclip in the audio source
        /// </summary>
        /// <param name="audioClip"> Audio source in player </param>
        public void PlaySound(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}