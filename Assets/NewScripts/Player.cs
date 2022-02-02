using System.Collections;
using Scripst;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject time, items;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float second;
    [SerializeField] private Text textTime;
    [SerializeField] private Slider sliderTime;

    public static bool stop;

    private float timer;

    void Start()
    {
        timer = second;
        stop = false;
        ShowUI(false);
        sliderTime.value = 100;
    }

    // Update is called once per frame
    private void Update()
    {
        if (stop)
        {
            var time = Mathf.FloorToInt(timer % 60);
            sliderTime.value = time  * 10;
            textTime.text = time.ToString();
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = second;
            }
        }

        if (!stop) transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PitchStop"))
        {
            StartCoroutine("Customize");
        }

        if (other.gameObject.CompareTag("Destroy"))
        {
            GenerateCustomer.generate = false;
            Destroy(gameObject);
        }
    }

    IEnumerator Customize()
    {
        stop = true;
        ShowUI(true);
        yield return new WaitForSeconds(second);
        DataGame.health -= 1;
        ShowUI(false);
        stop = false;
    }

    private void ShowUI(bool active)
    {
        items.SetActive(active);
        time.SetActive(active);
    }
}