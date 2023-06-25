using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;

        public void ShotSound()
        {
            audioSource.Play();
        }
    }
}