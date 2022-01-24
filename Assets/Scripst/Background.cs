using System.Collections;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject[] bg;
    private float posY = 40;

    private void Start()
    {
        StartCoroutine("CreateBg");
    }

    IEnumerator CreateBg()
    {
        while (true && !Data.isGameOver)
        {
            yield return new WaitForSeconds(1);
            var go = Instantiate(bg[Random.Range(0, bg.Length)], new Vector3(0, posY, 0), Quaternion.identity);
            go.transform.parent = gameObject.transform;
            posY += 10;
        }
    }
}