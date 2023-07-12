using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public float Timer { get; set; }

        public static Action OnDefeatEvent;
        public static Action OnWinEvent;

        [SerializeField] private bool startTimer = true;
        [SerializeField] private int levelTimer = 30;

        private int targets;

        private void Start()
        {
            Timer = levelTimer;
            PlayerUI.OnNoTargets += PlayerWin;

            if (startTimer)
            {
                StartCoroutine(TimerCoroutine());
            }
        }

        private void OnDestroy()
        {
            PlayerUI.OnNoTargets -= PlayerWin;
        }


        /// <summary>
        /// in case of win, disables this object to stop unecesary calculation and invokes win event.
        /// </summary>
        private void PlayerWin()
        {
            gameObject.SetActive(false);
            OnWinEvent?.Invoke();
        }

        /// <summary>
        /// Calculates time remaining until lose
        /// </summary>
        /// <returns></returns>
        private IEnumerator TimerCoroutine()
        {
            while (Timer > 0)
            {
                Timer -= Time.deltaTime;
                yield return null;
            }
            
            if ((Timer > 0)) yield break;
            
            OnDefeatEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}