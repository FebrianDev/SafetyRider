using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float speed = 8;
    [SerializeField] private float rem = 0.5f;

    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] private GameObject panelJoystick;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private float percepatan;

    private bool isActive;

    [SerializeField] private AudioSource _audioSource, audioBrake;

    private bool check;
    private void Start()
    {
        isActive = false;
        check = false;
        panelJoystick.SetActive(false);
        rigid = GetComponent<Rigidbody2D>();

        _audioSource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && !check)
        {
            _audioSource.enabled = true;
            check = true;
        }
        
        if (Data.isGameOver)
        {
            _rectTransform.anchoredPosition = Vector2.zero;
            _joystick.input = Vector2.zero;
        }

        VerticalMove();
        CheckSpeed();
        ShowJoystick();
    }

    void VerticalMove()
    {
        var y = _joystick.Vertical;
        var x = _joystick.Horizontal;

        _audioSource.volume = y;
        if (y <= 0.7f)
        {
            _audioSource.volume = 0.7f;
        }

        if (y > 0)
        {
            percepatan += Time.deltaTime;

            if (percepatan >= 1.2)
            {
                percepatan = 1.2f;
            }

            transform.position +=
                (Vector3) new Vector2((x * Time.deltaTime * 1.8f), (y * speed * Time.deltaTime)) * percepatan;

            Data.speed = y * 100;

            Debug.Log(Data.speed);
        }
        else
        {
            percepatan -= Time.deltaTime;

            if (percepatan <= 0)
            {
                percepatan = 0;
            }

            Data.speed = 0;
            transform.position += (Vector3) new Vector2((x * rem * Time.deltaTime * 1.8f), (y * rem * Time.deltaTime));
        }

        if (y < 0)
        {
            audioBrake.mute = false;
            audioBrake.PlayOneShot(audioBrake.clip);
        }
        else
        {
            audioBrake.mute = true;
        }

        Data.score = transform.position.y;
    }

    void CheckSpeed()
    {
        if (LimitSpeed.limitSpeedActive)
        {
            if (Data.speed > 65)
            {
                Data.isGameOver = true;
                Time.timeScale = 0f;
                Data.message = "Kamu terlalu cepat! perhatikan batas kecepatan";
            }
        }
    }

    void ShowJoystick()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene" && !isActive)
        {
            panelJoystick.SetActive(true);
            isActive = true;
        }

        if (!Data.isGameOver && SceneManager.GetActiveScene().name == "SampleScene")
        {
            panelJoystick.SetActive(true);
        }
        else
        {
            panelJoystick.SetActive(false);
        }
    }
}