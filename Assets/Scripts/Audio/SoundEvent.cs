using System.Collections.Generic;
using UnityEngine;

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
                listener.OnEventRaised(this);
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