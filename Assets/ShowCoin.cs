using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoin : MonoBehaviour
{
    [SerializeField] private Text coin;
    // Start is called before the first frame update
    void Start()
    {
        coin.text = PlayerPrefs.GetInt(Constant.COIN).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
