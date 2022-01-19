using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float speed = 10;
    [SerializeField] private float rem = 0.5f;

    // Update is called once per frame
    void Update()
    {
        VerticalMove();
        HorizontalMove();
    }

    private void HorizontalMove()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x >= 0)
        {
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 1.5)
        {
            transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
        }
    }

    void VerticalMove()
    {
        var y = _joystick.Vertical;
        var x = _joystick.Horizontal;

        if (y > 0)
        {
            Data.speed = y * 100;
            transform.position += new Vector3((x * Time.deltaTime), (y * speed * Time.deltaTime), 0);
        }
        else
        {
            Data.speed = 0;
            transform.position += new Vector3((x * rem * Time.deltaTime), (y * rem * Time.deltaTime), 0);
            
        }

        Data.score = transform.position.y;
    }
}