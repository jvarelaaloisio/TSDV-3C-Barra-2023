using Game;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Menu
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Button resumeButton;
        [SerializeField] public bool canWin = true;

        private const int MenuSceneIndex = 0;

        private const float NormalTimeScale = 1;
        private const float PauseTimeScale = 0;

        private void Awake()
        {
            resumeButton.Select();
            if (canWin)
            {
                GameManager.OnLoseEvent += OnGameEnd;
                GameManager.OnWinEvent += OnGameEnd;
            }
        }

        private void OnDestroy()
        {
            if (canWin)
            {
                GameManager.OnLoseEvent -= OnGameEnd;
                GameManager.OnWinEvent -= OnGameEnd;
            }
        }

        /// <summary>
        /// In case of game ending by win or lose event, stops time and disables this menu.
        /// </summary>
        private void OnGameEnd()
        {
            StopTime();
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Activates or deactivates the pause.
        /// </summary>
        private void OnPause()
        {
            if (pauseMenu.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        /// <summary>
        /// Stops the game and deactivates gameplay inputs.
        /// </summary>
        private void PauseGame()
        {
            StopTime();
            ChangeState();
            resumeButton.Select();
        }

        /// <summary>
        /// Resumes the game and reactivates the gameplay inputs.
        /// </summary>
        public void ResumeGame()
        {
            playerInput.enabled = true;
            ResumeTime();
            ChangeState();
        }

        /// <summary>
        /// Enables or disavles the player's input and the pause menu
        /// </summary>
        private void ChangeState()
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        /// <summary>
        /// Reloads the current scene.
        /// </summary>
        public void OnResetButtonClick()
        {
            ResumeTime();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Loads the menu scene
        /// </summary>
        public void OnLoadMenuButtonClick()
        {
            ResumeTime();

            SceneManager.LoadScene(MenuSceneIndex);
        }

        /// <summary>
        /// Modifies time scale to PauseTimeScale
        /// </summary>
        private void StopTime()
        {
            playerInput.enabled = false;
            Time.timeScale = PauseTimeScale;
        }

        /// <summary>
        /// Modifies time scale to NormalTimeScale
        /// </summary>
        private void ResumeTime()
        {
            Time.timeScale = NormalTimeScale;
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        public void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}