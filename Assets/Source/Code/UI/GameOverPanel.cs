using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.UI
{
    public sealed class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Button _retryBtn;
        [SerializeField] private Button _exitGameBtn;

        private void Awake()
        {
            _retryBtn.onClick.AddListener(ReloadScene);
            _exitGameBtn.onClick.AddListener(ExitGame);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}