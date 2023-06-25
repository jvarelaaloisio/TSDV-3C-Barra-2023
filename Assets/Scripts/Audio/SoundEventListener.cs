using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.Events;

public class SoundEventListener : MonoBehaviour
{
    public SoundEvent soundEvent;

    public UnityEvent response;
    private void OnEnable()
    {
        soundEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        soundEvent.UnregisterListener(this);
    }

    public void OnEventRised()
    {
        response.Invoke();
    }
}
