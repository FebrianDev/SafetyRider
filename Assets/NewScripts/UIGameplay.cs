using Scripst;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] private Text textScore, textHealth;
    [SerializeField] private GameObject panelGameOver, newHighscore, panelPause, pause;
    [SerializeField] private Text finalScore;

    private int highscore;

    void Start()
    {
        panelGameOver.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;
        DataGame.health = 3;
        DataGame.score = 0;

        highscore = PlayerPrefs.GetInt(Constant.HIGHSCORE);
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"Score : {DataGame.score}";
        textHealth.text = $"Health : {DataGame.health}";

        if (DataGame.health == 0)
        {
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
            pause.SetActive(false);
            finalScore.text = $"Score : {DataGame.score}";

            if (DataGame.score > highscore)
            {
                highscore = DataGame.score;
                PlayerPrefs.SetInt(Constant.HIGHSCORE, highscore);
                newHighscore.SetActive(true);
            }
            else
            {
                newHighscore.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}