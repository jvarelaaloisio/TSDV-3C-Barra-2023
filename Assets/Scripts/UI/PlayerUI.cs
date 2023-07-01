using Game;
using Player;
using Targets;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text timer;
        [SerializeField] private TMP_Text targetsRemaining;
        [SerializeField] private TMP_Text bulletsCounter;
        [FormerlySerializedAs("targetsManager")] [SerializeField] private GameManager gameManager;
        private WeaponContainer weaponContainer;
        private int targetAmount;

        private void Start()
        {
            weaponContainer = FindObjectOfType<WeaponContainer>();
            gameManager = FindObjectOfType<GameManager>();
            targetAmount = GameObject.FindGameObjectsWithTag("Target").Length;
            Target.OnTargetDeath += ShowTargetsRemaining;
            ShowTargetsRemaining();
            InputManager.OnBulletsUpdate += ShowBullets;
        }

        private void OnDestroy()
        {
            Target.OnTargetDeath -= ShowTargetsRemaining;
            InputManager.OnBulletsUpdate -= ShowBullets;
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
            timer.text = gameManager.Timer.ToString("0.##");
        }

        /// <summary>
        /// OnTargetDeath event, update targets remaining in ui
        /// </summary>
        private void ShowTargetsRemaining()
        {
            targetAmount = GameObject.FindGameObjectsWithTag("Target").Length;
            targetsRemaining.text = "Targets remaining: " + targetAmount;
        }

        /// <summary>
        /// Shows currently equipped weapon's remaing bullets
        /// </summary>
        private void ShowBullets()
        {
            if (weaponContainer.GetWeapon()==null)
            {
                bulletsCounter.text = "";
                return;
            }
            bulletsCounter.text = weaponContainer.GetWeapon()?.Bullets + "/" + weaponContainer.GetWeapon()?.MaxBullets;
        }
    }
}