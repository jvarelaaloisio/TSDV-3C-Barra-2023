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
        }

        private void OnDestroy()
        {
            PlayerUI.OnNoTargets -= PlayerWin;
        }

        private void Update()
        {
            if (startTimer)
            {
                StartCoroutine(TimerCoroutine());
            }
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
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                OnDefeatEvent?.Invoke();
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }
}