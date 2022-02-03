using Scripst;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] private GameObject panelGameOver, newHighscore, panelPause, pause;
    [SerializeField] private Text finalScore;

    [SerializeField] private GameObject[] healths;

    private int highscore;
    private bool isGameOver;
    void Start()
    {
        isGameOver = false;
        panelGameOver.SetActive(false);
        pause.SetActive(true);
        Time.timeScale = 1f;
        DataGame.health = 3;
        DataGame.score = 0;
        DataGame.isPause = false;

        highscore = PlayerPrefs.GetInt(Constant.HIGHSCORE);
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = $"Score: {DataGame.score}";
        
        SetHealth();

        Clear();
        
        if (DataGame.health == 0 && !isGameOver)
        {
            Time.timeScale = 0f;
            panelGameOver.SetActive(true);
            pause.SetActive(false);
            finalScore.text = $"Score: {DataGame.score}";

            if (DataGame.score > highscore)
            {
                Debug.Log("New Highscore");
                highscore = DataGame.score;
                PlayerPrefs.SetInt(Constant.HIGHSCORE, highscore);
                newHighscore.SetActive(true);
            }
            else
            {
                newHighscore.SetActive(false);
            }

            isGameOver = true;
        }
    }

    private void Clear()
    {
        if (Input.GetKey(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
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
        DataGame.isPause = true;
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        DataGame.isPause = false;
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    private void SetHealth()
    {
        if (DataGame.health == 3)
        {
             healths[0].SetActive(true);
             healths[1].SetActive(false);
             healths[2].SetActive(false);
        }
        else if (DataGame.health == 2)
        {
            healths[0].SetActive(false);
            healths[1].SetActive(true);
            healths[2].SetActive(false);
        }
        else if (DataGame.health == 1)
        {
            healths[0].SetActive(false);
            healths[1].SetActive(false);
            healths[2].SetActive(true);
        }
        else if (DataGame.health <= 0)
        {
            foreach (var imgHealth in healths)
            {
                imgHealth.SetActive(false);
            }
        }
    }
}