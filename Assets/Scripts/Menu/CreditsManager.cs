using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    //TODO: Documentation - Add summary
    public class CreditsManager : MonoBehaviour
    {
        [Header("Menu")]
        [SerializeField] private GameObject mainMenu;

        [Header("Buttons")]
        [SerializeField] private Button backButton;
        [SerializeField] private Button menuCreditsButton;

        //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
        void Start()
        {
            backButton.Select();
        }

        public void OnBackButtonClick()
        {
            gameObject.SetActive(false);
            mainMenu.SetActive(true);
            menuCreditsButton.Select();
        }
    }
}
