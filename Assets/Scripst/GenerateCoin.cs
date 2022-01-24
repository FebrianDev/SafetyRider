using UnityEngine;

public class GenerateCoin : MonoBehaviour
{
    [SerializeField] private GameObject[] coins;

    void Start()
    {
        var obj = Instantiate(coins[Random.Range(0, coins.Length)], transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
}