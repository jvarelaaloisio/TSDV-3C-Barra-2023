using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class LoadNextLevel : MonoBehaviour
    {
        private const int SceneOffset = 1;

        /// <summary>
        /// Last hour implementation :)
        /// </summary>
        private void OnDestroy()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + SceneOffset);
        }
    }
}