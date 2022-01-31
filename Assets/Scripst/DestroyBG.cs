using UnityEngine;

namespace Scripst
{
    public class DestroyBG : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            //Destroy Player
            if(other.gameObject.CompareTag("Player")) Destroy(GameObject.FindWithTag("Player"));
        }
    }
}