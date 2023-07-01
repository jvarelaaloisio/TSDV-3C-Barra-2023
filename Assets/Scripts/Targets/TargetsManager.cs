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

        private void OnLose()
        {
        //TODO Make player lose
        }

    }
}
