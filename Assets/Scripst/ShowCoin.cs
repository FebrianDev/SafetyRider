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
        
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = PlayerPrefs.GetInt(Constant.COIN).ToString();
    }
}
