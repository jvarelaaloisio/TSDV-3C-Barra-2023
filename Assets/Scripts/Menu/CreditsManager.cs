using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    //TODO: Documentation - Add summary
    public class CreditsManager : MonoBehaviour
    {
        [Header("Main Menu")]
        [SerializeField] private MenuManager menuManager;
        
        [Header("Buttons")]
        [SerializeField] private Button backButton;

        //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
        private void Start()
        {
            backButton.Select();
        }

        public void OnBackButtonClick()
        {
            menuManager.ChangeMenu(Menus.Main);
        }
    }
}
