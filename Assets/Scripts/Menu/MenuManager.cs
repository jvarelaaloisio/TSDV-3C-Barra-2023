using UnityEngine;
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
        [SerializeField] private Button optionsBackButton;
        [SerializeField] private Button creditsBackButton;

        [Header("Menus")] 
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject creditsMenu;

        //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
        private void Start()
        {
            ChangeMenu(Menus.Main);
        }

        public void OnPlayButtonClick()
        {
            const int sceneOffset = 1;
            LoadNextScene(sceneOffset);
        }


        public void OnOptionsButtonClick()
        {
            ChangeMenu(Menus.Options);
        }

        public void OnCreditsButtonClick()
        {
            ChangeMenu(Menus.Credits);
        }

        public void OnExitButtonClick()
        {
            Application.Quit();
        }

        private void LoadNextScene(int sceneOffset)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneOffset);
        }

        public void ChangeMenu(Menus menu)
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
                    optionsBackButton.Select();
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