using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private CanvasController m_canvasController;

    private void Awake()
    {
        SnakeController.OnTailDetected += GameOver;
        WallController.OnSnakeDetected += GameOver;
    }

    private void GameOver()
    {
        SceneManager.UnloadSceneAsync("Game");

        m_canvasController.SignInCanvas.SetActive(true);

        m_canvasController.SignInScore = m_canvasController.GameScore;
    }

    public void NewGame()
    {
        m_canvasController.GameScore = 0;

        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
    }
}