using System;
using System.Collections;
using UI;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int levelTimer = 30;
        public float Timer { get; set; }
        
        private int targets;
        
        public static Action OnLoseEvent;
        public static Action OnWinEvent;


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
            StartCoroutine(TimerCoroutine());
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
                OnLoseEvent?.Invoke();
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }
}