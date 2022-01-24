using UnityEngine;

namespace Scripst
{
    public class DestroyBG : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Destroy BG");
            Destroy(GameObject.FindWithTag("Background"));
        }
    }
}