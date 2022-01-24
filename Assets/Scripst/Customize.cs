using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customize : MonoBehaviour
{
    [SerializeField] private List<Items> _list = new List<Items>();
    [SerializeField] private List<Image> btnList = new List<Image>();
    [SerializeField] private string KEY;

    [SerializeField] private List<GameObject> buy = new List<GameObject>();
    private int temp, coin;
    private bool item;

    private void Start()
    {
        coin = PlayerPrefs.GetInt(Constant.COIN);
        temp = PlayerPrefs.GetInt(KEY);

        PlayerPrefs.SetInt(KEY + "0", 1);

        for (var i = 0; i < _list.Count; i++)
        {
            buy[i].GetComponentInChildren<Text>().text = $"{_list[i].price.ToString()} Coins \n Buy";
            _list[i].obj.SetActive(temp == i);
            item = (PlayerPrefs.GetInt(KEY + i.ToString(), 0) != 0);
            _list[i].unlock = item;
            btnList[i].color = !_list[i].unlock ? Color.black : Color.white;
        }
    }

    public void BuyItems(int id)
    {
        if (coin > _list[id].price)
        {
            _list[id].unlock = true;
            PlayerPrefs.SetInt(KEY + id.ToString(), 1);
            PlayerPrefs.SetInt(Constant.COIN, coin - _list[id].price);
            btnList[id].color = Color.white;
            buy[id].SetActive(false);
        }
    }

    public void SetItems(int id)
    {
        if (_list[id].unlock)
        {
            temp = PlayerPrefs.GetInt(KEY, 0);
            if (id != temp)
            {
                for (var i = 0; i < _list.Count; i++)
                {
                    if (id == i)
                    {
                        Debug.Log("Oke");
                        _list[i].obj.SetActive(true);
                        PlayerPrefs.SetInt(KEY, id);
                    }
                    else
                    {
                        Debug.Log("No");
                        _list[i].obj.SetActive(false);
                    }
                }
            }
        }


        for (var i = 0; i < buy.Count; i++)
        {
            buy[i].SetActive(i == id && !_list[id].unlock);
        }
    }

    [Serializable]
    class Items
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
}