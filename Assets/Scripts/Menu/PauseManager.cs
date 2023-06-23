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
        private InputAction pauseAction;

        private new void Awake()
        {
            base.Awake();
            resumeButton.Select();
            //TODO: Fix - Hardcoded value - Why not just setup this in the input window?
            pauseAction = new InputAction(binding: "<Keyboard>/escape");
            pauseAction.performed += OnPause;
        }

        private void OnEnable()
        {
            pauseAction.Enable();
        }

        private void OnDisable()
        {
            pauseAction.Disable();
        }

        public void OnPause(InputAction.CallbackContext context)
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
            playerInput.enabled = false;
            pauseMenu.SetActive(true);
            resumeButton.Select();
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            playerInput.enabled = true;
            pauseMenu.SetActive(false);
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
