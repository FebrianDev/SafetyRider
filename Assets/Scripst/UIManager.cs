using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coin;
    [SerializeField] private Text score;
    [SerializeField] private Text speed;

    [SerializeField] private Text finalScore;

    [SerializeField] private Text message;

    [SerializeField] private GameObject panelGameOver, panelGamePlay, newHighscore, panelPause, pause;

    private int highscore, tempCoin;

    [SerializeField] private GameObject cam, img;

    private void Start()
    {
        cam.SetActive(false);
        img.SetActive(false);
        Init();

        highscore = PlayerPrefs.GetInt(Constant.HIGHSCORE);
        tempCoin = PlayerPrefs.GetInt(Constant.COIN);
    }

    private void Update()
    {
        var scoreValue = ((int) (Data.score / 10) < 0) ? 0 : (int) (Data.score / 10);

        coin.text = $"{Data.coin.ToString()}";
        score.text = $"{scoreValue} Km";
        speed.text = $"{(int) Data.speed} Km/h";

        if (Data.isGameOver)
        {
            img.SetActive(true);
            cam.SetActive(true);
            panelGameOver.SetActive(true);
            panelGamePlay.SetActive(false);
            pause.SetActive(false);
            finalScore.text = $"Score : {scoreValue}";
            message.text = Data.message;

            if (Data.score > highscore)
            {
                highscore = (int) Data.score;
                PlayerPrefs.SetInt(Constant.HIGHSCORE, highscore);
                newHighscore.SetActive(true);
            }
            else
            {
                newHighscore.SetActive(false);
            }
            
            PlayerPrefs.SetInt(Constant.COIN, Data.coin + tempCoin);
            LimitSpeed.limitSpeedActive = false;
        }
    }

    public void Restart()
    {
        GameObject.FindWithTag("Player").GetComponent<Transform>().position = new Vector3(1.4f, -18, 0);
        GameObject.FindWithTag("MainCamera").GetComponent<Transform>().position = new Vector3(0, -18, -10);
        Init();
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit()
    {
        Init();
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.FindWithTag("MainCamera"));
        SceneManager.LoadScene("MainMenu");
    }

    private void Init()
    {
        Data.coin = 0;
        Data.score = 0;
        Data.speed = 0;
        Data.isGameOver = false;
        Data.message = "";

        panelGameOver.SetActive(false);
        panelPause.SetActive(false);
        panelGamePlay.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        panelPause.SetActive(true);
        cam.SetActive(true);
        img.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        img.SetActive(false);
        cam.SetActive(false);
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}