using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class PauseManager : MonoBehaviourSingleton<PauseManager>
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Button resumeButton;
        private const int MenuSceneIndex = 0;
        private new void Awake()
        {
            base.Awake();
            resumeButton.Select();
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
            Time.timeScale = 0;
            ChangeState();
            resumeButton.Select();
        }

        /// <summary>
        /// Resumes the game and reactivates the gameplay inputs.
        /// </summary>
        public void ResumeGame()
        {
            Time.timeScale = 1;
            ChangeState();
        }

        /// <summary>
        /// Enables or disavles the player's input and the pause menu
        /// </summary>
        private void ChangeState()
        {
            playerInput.enabled = !playerInput.inputIsActive;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        /// <summary>
        /// Reloads the current scene.
        /// </summary>
        public void OnResetButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Loads the menu scene
        /// </summary>
        public void OnLoadMenuButtonClick()
        {
            Time.timeScale = 1;
            
            SceneManager.LoadScene(MenuSceneIndex);
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