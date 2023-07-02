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
            GameManager.OnLoseEvent += GameOver;
        }

        private void OnDestroy()
        {
            GameManager.OnLoseEvent -= GameOver;
        }

        private void GameOver()
        {
            restartLevel.Select();
            gameOverMenu.SetActive(true);
        }
    }
}