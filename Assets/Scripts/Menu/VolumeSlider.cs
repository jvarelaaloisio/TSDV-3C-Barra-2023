using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Menu
{
    public class VolumeSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer mainMixer;
        [SerializeField] private Slider volumeSlider;

        void Start()
        {
            mainMixer.GetFloat("Volume", out float currentVolume);
            volumeSlider.value = currentVolume;
        }
        
        /// <summary>
        /// Changes the game's volume
        /// </summary>
        /// <param name="volume"> new volume </param>
        public void SetVolume(float volume)
        {
            mainMixer.SetFloat("Volume", volume);
        }
    }
}
