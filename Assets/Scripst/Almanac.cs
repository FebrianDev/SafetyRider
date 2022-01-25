using System;
using System.Collections.Generic;
using UnityEngine;

public class Almanac : MonoBehaviour
{
    [SerializeField] private List<DataAlamanac> _list = new List<DataAlamanac>();
    [SerializeField] private string KEY;
    private int temp;

    private void Start()
    {
        temp = PlayerPrefs.GetInt(KEY, 0);
        for (var i = 0; i < _list.Count; i++)
        {
            _list[i].obj.SetActive(temp == i);
        }
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

    [Serializable]
    struct DataAlamanac
    {
        public int id;
        public GameObject obj;
    }
}