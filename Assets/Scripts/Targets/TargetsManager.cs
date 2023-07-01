using System.Collections;
using UnityEngine;

namespace Targets
{
    public class TargetsManager : MonoBehaviour
    {
        public float Timer { get; set; }
        private int targets;
        
       
        private void Update()
        {
            StartCoroutine(TimerCoroutine());
        }

        /// <summary>
        /// Calculates time remaining until lose
        /// </summary>
        /// <returns></returns>
        private IEnumerator TimerCoroutine()
        {
            Timer -= Time.deltaTime;
            //TODO CALL EVENT ON LOSE
            if (Timer <= 0)
            {
                OnLose();
            }
            yield return null;
        }

        /// <summary>
        /// Trigger player's defeat
        /// </summary>
        private void OnLose()
        {
        //TODO Make player lose
        }

    }
}
