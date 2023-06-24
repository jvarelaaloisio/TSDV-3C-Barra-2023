using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Menu
{
    public class OptionsManager : MonoBehaviour
    {
        [Header("Menu")]
        [SerializeField] private MenuManager menuManager;

        [Header("Buttons")]
        [SerializeField] private Button backButton;

        void Start()
        {
            backButton.Select();
        }

        //TODO: Fix - Repeated code
        public void OnBackButtonClick()
        {
            menuManager.ChangeMenu(Menus.Main);
        }
        
        
    }
}