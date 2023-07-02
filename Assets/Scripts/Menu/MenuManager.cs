using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public enum Menus
    {
        Main,
        Options,
        Credits
    }

    public class MenuManager : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private Button playButton;
        [SerializeField] private Slider volumeSlider;
        [SerializeField] private Button creditsBackButton;

        [Header("Menus")] 
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject creditsMenu;

        private void Start()
        {
            LoadMenu();
        }

        /// <summary>
        /// Shows the main menu in the menu scene.
        /// </summary>
        public void LoadMenu()
        {
            ChangeMenu(Menus.Main);
        }

        /// <summary>
        /// Loads the game scene
        /// </summary>
        public void LoadGame()
        {
            const int sceneOffset = 1;
            LoadNextScene(sceneOffset);
        }
        
        /// <summary>
        /// Shows the options in the menu scene.
        /// </summary>
        public void LoadOptions()
        {
            ChangeMenu(Menus.Options);
        }
        /// <summary>
        /// Shows the credits in the menu scene.
        /// </summary>
        public void LoadCredits()
        {
            ChangeMenu(Menus.Credits);
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        public void OnExitButtonClick()
        {
            Application.Quit();
        }

        /// <summary>
        /// Loads the required scene from the current scene.
        /// </summary>
        /// <param name="sceneOffset"></param>
        private void LoadNextScene(int sceneOffset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneOffset);
        }

        /// <summary>
        /// Basic menu state machine.
        /// </summary>
        /// <param name="menu"></param>
        private void ChangeMenu(Menus menu)
        {
            optionsMenu.SetActive(false);
            creditsMenu.SetActive(false);
            gameObject.SetActive(false);

            switch (menu)
            {
                case Menus.Main:
                    playButton.Select();
                    gameObject.SetActive(true);
                    break;
                case Menus.Options:
                    volumeSlider.Select();
                    optionsMenu.SetActive(true);
                    break;
                case Menus.Credits:
                    creditsBackButton.Select();
                    creditsMenu.SetActive(true);
                    break;
                default:
                    playButton.Select();
                    gameObject.SetActive(true);
                    break;
            }
        }
    }
}