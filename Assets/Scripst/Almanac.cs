using System;
using System.Collections.Generic;
using UnityEngine;

public class Almanac : MonoBehaviour
{
    [SerializeField] private List<DataAlamanac> _list = new List<DataAlamanac>();
    private int temp;

    private void Start()
    {
        if (Navigation.active == 0)
            temp = PlayerPrefs.GetInt("TEMP " + Navigation.active, 0);
        else if (Navigation.active == 1)
            temp = PlayerPrefs.GetInt("TEMP " + Navigation.active, 8);
        for (var i = 0; i < _list.Count; i++)
        {
            _list[i].obj.SetActive(temp == i);
        }

        //  PlayerPrefs.SetInt(Constant.COIN, 100000);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SetBtn(int id)
    {
        if (Navigation.active == 0)
            temp = PlayerPrefs.GetInt("TEMP " + Navigation.active, 0);
        else if (Navigation.active == 1)
            temp = PlayerPrefs.GetInt("TEMP " + Navigation.active, 8);
        if (id != temp)
        {
            for (var i = 0; i < 21; i++)
            {
                if (id == i)
                {
                    Debug.Log("Oke");
                    _list[i].obj.SetActive(true);
                    PlayerPrefs.SetInt("TEMP" + Navigation.active, id);
                }
                else
                {
                    Debug.Log("No");
                    _list[i].obj.SetActive(false);
                }
            }
        }
    }

    [Serializable]
    struct DataAlamanac
    {
        public int id;
        public GameObject obj;
    }
}