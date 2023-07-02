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

        [SerializeField] private GameManager gameManager;

        private WeaponContainer weaponContainer;
        private int targetAmount;

        private void Start()
        {
            weaponContainer = FindObjectOfType<WeaponContainer>();
            gameManager = FindObjectOfType<GameManager>();

            Target.OnTargetDeath += UpdateRemainingTargets;
            InputManager.OnBulletsUpdate += ShowBullets;

            targetAmount = GameObject.FindGameObjectsWithTag("Target").Length;
            ShowTargetsRemaining();
        }

        private void OnDestroy()
        {
            Target.OnTargetDeath -= UpdateRemainingTargets;
            InputManager.OnBulletsUpdate -= ShowBullets;
        }

        private void Update()
        {
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

        private void UpdateRemainingTargets()
        {
            targetAmount--;
            ShowTargetsRemaining();
        }

        /// <summary>
        /// OnTargetDeath event, update targets remaining in ui
        /// </summary>
        private void ShowTargetsRemaining()
        {
            targetsRemaining.text = "Targets remaining: " + targetAmount;
        }

        /// <summary>
        /// Shows currently equipped weapon's remaing bullets
        /// </summary>
        private void ShowBullets()
        {
            if (weaponContainer.GetWeapon() == null)
            {
                bulletsCounter.text = "";
                return;
            }

            bulletsCounter.text = weaponContainer.GetWeapon()?.Bullets + "/" + weaponContainer.GetWeapon()?.MaxBullets;
        }
    }
}