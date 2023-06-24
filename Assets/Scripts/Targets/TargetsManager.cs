using System;
using System.Collections;
using UnityEngine;

namespace Targets
{
    public class TargetsManager : MonoBehaviour
    {
        public float Timer { get; set; }
        private int targets;
        
        private void Start()
        {
            UpdateTargets();
        }
        private void Update()
        {
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            // Decrement the timer
            Timer -= Time.deltaTime;
            // Check if the timer has expired
            if (Timer <= 0)
            {
                // Call the OnLose function
                OnLose();
            }
            // Yield until the next frame
            yield return null;
        }

        private void OnLose()
        {
        //TODO Make player lose
        }
        public void UpdateTargets()
        {
            //TODO: Fix - Should be event based
            targets = FindObjectsOfType<Target>().Length;
        }

        public int GetTargetsAmmount()
        {
            return targets;
        }
    
    
    }
}
