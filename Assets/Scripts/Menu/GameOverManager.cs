using Game;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private Button restartLevel;
        private void Start()
        {
            GameManager.OnDefeatEvent += GameOver;
        }

        private void OnDestroy()
        {
            GameManager.OnDefeatEvent -= GameOver;
        }

        /// <summary>
        /// in case of defeat event, activates the game over menu
        /// </summary>
        private void GameOver()
        {
            PauseManager.ChangeMouseState(true);
            restartLevel.Select();
            gameOverMenu.SetActive(true);
        }
    }
}