using System.Collections;
using Scripst;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject items;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float second;
    [SerializeField] private Text textTime;
    [SerializeField] private Slider sliderTime;
    [SerializeField] private GameObject panelItems;
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
        panelItems.SetActive(!DataGame.isPause);
        
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
            GameObject.FindWithTag("PitchStop").GetComponent<SpriteRenderer>().enabled = false;
        }

        if (other.gameObject.CompareTag("Destroy"))
        {
            GenerateCustomer.generate = false;
            GameObject.FindWithTag("PitchStop").GetComponent<SpriteRenderer>().enabled = true;
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
        yield return new WaitForSeconds(1);
        GameObject.FindWithTag("PitchStop").GetComponent<SpriteRenderer>().enabled = true;
    }

    private void ShowUI(bool active)
    {
        items.SetActive(active);
    }
}