using Targets;
using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text timer;
        [SerializeField] private TMP_Text targetsRemaining;
        [SerializeField] private TargetsManager targetsManager;
        private int targetAmount;
        private void Start()
        {
            targetsManager = FindObjectOfType<TargetsManager>();
            targetAmount = GameObject.FindGameObjectsWithTag("Target").Length;
            Target.OnTargetDeath += ShowTargetsRemaining;
            ShowTargetsRemaining();
        }

        private void OnDestroy()
        {
            Target.OnTargetDeath -= ShowTargetsRemaining;
        }

        private void Update()
        {
            //TODO: Fix - Should be event based
            ShowTimer();
        }

        //TODO TIMER EVENT
        /// <summary>
        /// Show time remaining
        /// </summary>
        private void ShowTimer()
        {
            timer.text = targetsManager.Timer.ToString("0.##");
        }

        /// <summary>
        /// OnTargetDeath event, update targets remaining in ui
        /// </summary>
        private void ShowTargetsRemaining()
        {
            targetAmount = GameObject.FindGameObjectsWithTag("Target").Length;
            targetsRemaining.text = "Targets remaining: " + targetAmount;
        }
    }
}