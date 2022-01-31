using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject time, items;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float second;
    [SerializeField] private Text textTime;
    private bool stop;
    
    private float timer;
    void Start()
    {
        timer = second;
        stop = false;
        ShowUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            textTime.text = Mathf.FloorToInt(timer % 60).ToString();
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = second;
            }
        }

        if(!stop) transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PitchStop"))
        {
            StartCoroutine("Customize");
        }

        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Customize()
    {
        stop = true;
        ShowUI(true);
        yield return new WaitForSeconds(5);
        ShowUI(false);
        stop = false;
    }

    private void ShowUI(bool active)
    {
        items.SetActive(active);
        time.SetActive(active);
    }
}
