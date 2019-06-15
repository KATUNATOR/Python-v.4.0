using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private int M_RECORD_COUNT;

    [SerializeField]
    private GameObject m_startCanvas;
    [SerializeField]
    private GameObject m_gameCanvas;
    [SerializeField]
    private GameObject m_pauseCanvas;
    [SerializeField]
    private GameObject m_signInCanvas;
    [SerializeField]
    private GameObject m_recordsCanvas;
    [SerializeField]
    private GameObject m_gameController;

    [SerializeField]
    private Text m_gameScoreText;

    [SerializeField]
    private Text m_signInScoreText;
    [SerializeField]
    private Text m_signInNameText;

    [SerializeField]
    private Text[] m_recordNameTexts;
    [SerializeField]
    private Text[] m_recordScoreTexts;

    public int GameScore
    {
        get
        {
            return int.Parse(m_gameScoreText.text);
        }
        set
        {
            m_gameScoreText.text = value.ToString();
        }
    }

    public int SignInScore
    {
        get
        {
            return int.Parse(m_signInScoreText.text);
        }
        set
        {
            m_signInScoreText.text = value.ToString();
        }
    }

    public string SignInName
    {
        get
        {
            return m_signInNameText.text;
        }
        set
        {
            m_signInNameText.text = value;
        }
    }

    public GameObject StartCanvas { get { return m_startCanvas; } }
    public GameObject GameCanvas { get { return m_gameCanvas; } }
    public GameObject PauseCanvas { get { return m_pauseCanvas; } }
    public GameObject SignInCanvas { get { return m_signInCanvas; } }
    public GameObject RecordsCanvas { get { return m_recordsCanvas; } }

    private void HandlerOnFoodHasBeenEaten()
    {
        GameScore += 1;
    }

    private void Start()
    {
        FoodController.OnFoodHasBeenEaten += HandlerOnFoodHasBeenEaten;

        m_gameCanvas.SetActive(false);
        m_pauseCanvas.SetActive(false);
        m_signInCanvas.SetActive(false);
        m_recordsCanvas.SetActive(false);

        m_startCanvas.SetActive(true);
    }

    public void StartCanvas_PlayButton()
    {
        m_startCanvas.SetActive(false);

        m_gameCanvas.SetActive(true);
        m_gameController.GetComponent<GameController>().NewGame();
    }

    public void GameCanvas_PauseButton()
    {
        Time.timeScale = 0f;

        m_pauseCanvas.SetActive(true);
    }

    public void PauseCanvas_ResumeButton()
    {
        Time.timeScale = 1f;

        m_pauseCanvas.SetActive(false);
    }

    public void PauseCanvas_RestartButton()
    {
        Time.timeScale = 1f;

        m_pauseCanvas.SetActive(false);

        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Game"));

        m_gameController.GetComponent<GameController>().NewGame();
    }

    public void PauseCanvas_ExitButton()
    {
        Application.Quit();
    }

    public void PauseCanvas_RecordsButton()
    {
        m_recordsCanvas.SetActive(true);

        for (int i = 0; (PlayerPrefs.HasKey("name" + i)) && (i < M_RECORD_COUNT); i++)
        {
            m_recordNameTexts[i].text = PlayerPrefs.GetString("name" + i);
            m_recordScoreTexts[i].text = PlayerPrefs.GetInt("score" + i).ToString();
        }
    }

    public void SignInCanvas_OKButton()
    {
        m_signInCanvas.SetActive(false);

        SRecord newRecord = new SRecord(SignInName, SignInScore);

        List<SRecord> records = new List<SRecord>();

        for (int i = 0; (PlayerPrefs.HasKey("name" + i)) && (i < M_RECORD_COUNT) ; i++)
        {
            records.Add(new SRecord(
                PlayerPrefs.GetString("name" + i),
                PlayerPrefs.GetInt("score" + i)));
        }

        records.Add(newRecord);

        records.Sort(new RecordComparer());

        m_recordsCanvas.SetActive(true);

        for (int i = 0; i < records.Count; i++)
        {
            m_recordNameTexts[i].text = records[i].Name;
            m_recordScoreTexts[i].text = records[i].Score.ToString();

            PlayerPrefs.SetString("name" + i, records[i].Name);
            PlayerPrefs.SetInt("score" + i, records[i].Score);
        }
    }

    public void RecordsCanvas_OKButton()
    {
        m_recordsCanvas.SetActive(false);

        if (!m_pauseCanvas.activeSelf)
        {
            m_gameCanvas.SetActive(false);
            m_startCanvas.SetActive(true);
        }
    }
}
