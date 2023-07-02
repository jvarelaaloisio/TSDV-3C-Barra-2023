using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class WinManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameWonMenu;
        [SerializeField] private Button selectButton;
        private void Start()
        {
            GameManager.OnWinEvent += GameWin;
        }

        private void OnDestroy()
        {
            GameManager.OnWinEvent -= GameWin;
        }

        private void GameWin()
        {
            selectButton.Select();
            gameWonMenu.SetActive(true);
        }
    }
}