using System;
using System.Globalization;
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

        private void Start()
        {
            targetsManager = FindObjectOfType<TargetsManager>();
        }

        private void Update()
        {
            //TODO: Fix - Should be event based
            ShowTargetsRemaining();
            ShowTimer();

        }

        private void ShowTimer()
        {
            timer.text = targetsManager.Timer.ToString("0.##");
        }

        private void ShowTargetsRemaining()
        {
            targetsRemaining.text = "Targets remaining: " + targetsManager.GetTargetsAmmount();
        }
    }
}
