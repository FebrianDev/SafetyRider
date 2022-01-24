using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform objFollow;

    private Vector3 offset;

    void Start()
    {
        //posisi enemy - posisi player
        offset = transform.position - objFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, objFollow.position.y + offset.y, transform.position.z);
    }
}