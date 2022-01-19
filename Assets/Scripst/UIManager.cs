using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coin;
    [SerializeField] private Text score;
    [SerializeField] private Text speed;

    [SerializeField] private GameObject panelGameOver;

    private void Start()
    {
        Data.coin = 0;
        Data.score = 0;
        Data.speed = 0;
        Data.isGameOver = false;
        
        panelGameOver.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        coin.text = $"Coin {Data.coin.ToString()}";
        score.text = $"Distance {(int) (Data.score / 10)} Km";
        speed.text = $"{Data.speed} Km/h";

        if (Data.isGameOver)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}