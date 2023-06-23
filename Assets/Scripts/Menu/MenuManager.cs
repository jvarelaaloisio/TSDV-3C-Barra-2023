using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
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
        void Start()
        {
            playButton.Select();
            gameObject.SetActive(true);
            optionsMenu.SetActive(false);
            creditsMenu.SetActive(false);
        }

        public void OnPlayButtonClick()
        {
            //TODO: Fix - Hardcoded value
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void OnOptionsButtonClick()
        {
            gameObject.SetActive(false);
            optionsMenu.SetActive(true);
            optionsBackButton.Select();
            
        }

        public void OnCreditsButtonClick()
        {
            gameObject.SetActive(false);
            creditsMenu.SetActive(true);
            creditsBackButton.Select();
        }

        public void OnExitButtonClick()
        {
            Application.Quit();
        }
    }
}