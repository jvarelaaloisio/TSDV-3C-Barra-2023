using UnityEngine;

namespace Targets
{
    public class TargetsManager : MonoBehaviour
    {
        public float Timer { get; set; }
        private int targets;

        private void Update()
        {
            //TODO: Fix - Could be a coroutine
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                OnLose();
            }
        }

        //TODO: TP2 - Remove unused methods/variables/classes
        private void OnLose()
        {
        //TODO Make player lose
        }
        private void Start()
        {
            UpdateTargets();
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
