using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Audio
{
    [CreateAssetMenu(fileName = "SoundEvent")]
    public class SoundEvent : ScriptableObject
    {
        public List<SoundEventListener> listeners = new List<SoundEventListener>();

        public void Raise()
        {
            foreach (SoundEventListener listener in listeners)
            {
                listener.OnEventRised();
            }
        }

        public void RegisterListener(SoundEventListener listener)
        {
            if(!listeners.Contains(listener)) listeners.Add(listener);
        }
        
        public void UnregisterListener(SoundEventListener listener)
        {
            if(listeners.Contains(listener)) listeners.Remove(listener);
        }
    }
}