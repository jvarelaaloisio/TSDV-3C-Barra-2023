using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Audio
{
    public class SoundEventListener : MonoBehaviour
    {
        [System.Serializable]
        public class EventResponse
        {
            public SoundEvent soundEvent;
            public UnityEvent response;
        }

        [SerializeField] private List<EventResponse> eventResponses = new List<EventResponse>();

        private void OnEnable()
        {
            foreach (var eventResponse in eventResponses)
            {
                eventResponse.soundEvent.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            foreach (var eventResponse in eventResponses)
            {
                eventResponse.soundEvent.UnregisterListener(this);
            }
        }

        public void OnEventRaised(SoundEvent soundEvent)
        {
            foreach (var eventResponse in eventResponses)
            {
                if (eventResponse.soundEvent == soundEvent)
                {
                    eventResponse.response.Invoke();
                    break;
                }
            }
        }
    }
}