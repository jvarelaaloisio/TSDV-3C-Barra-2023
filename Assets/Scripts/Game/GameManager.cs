using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public float Timer { get; set; }
        [SerializeField] private int levelTimer = 30;
        private int targets;
        public static Action OnLoseEvent;

        private void Start()
        {
            Timer = levelTimer;
        }

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
            if (Timer <= 0)
            {
                OnLoseEvent?.Invoke();
                gameObject.SetActive(false);
            }
            yield return null;
        }

    }
}
