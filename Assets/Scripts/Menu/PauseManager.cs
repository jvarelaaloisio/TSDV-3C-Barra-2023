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

        private new void Awake()
        {
            base.Awake();
            resumeButton.Select();
            //TODO: Fix - Hardcoded value - Why not just setup this in the input window?
        }

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

        private void PauseGame()
        {
            Time.timeScale = 0;
            ChangeState();
            resumeButton.Select();
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            ChangeState();
        }

        private void ChangeState()
        {
            playerInput.enabled = !playerInput.inputIsActive;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }

        public void OnResetButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnLoadMenuButtonClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}