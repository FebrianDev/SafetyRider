using System.Collections.Generic;
using System.Linq;
using Scripst;
using UnityEngine;
using UnityEngine.UI;

public class PitchStop : MonoBehaviour
{
    [SerializeField] private GameObject[] listItems, addItems;
    [SerializeField] private List<Image> listSelected = new List<Image>();
    
    private int less;
    private HashSet<int> keys = new HashSet<int>();
    private List<int> keyPlayer = new List<int>();

    private Image[] sprites;
    [SerializeField] private Sprite[] s;

    [SerializeField] private GameObject canvas;

    void Start()
    {
        less = Random.Range(1, 6);

        var i = 0;

        for (var j = 0; j < less; j++)
        {
            var key = Random.Range(0, listItems.Length);
            listItems[key].SetActive(false);
            keys.Add(key);
        }

        for (var j = 0; j <= addItems.Length - 1; j++)
        {
            if (j == keys.Count - 1)
            {
                sprites = addItems[j].GetComponentsInChildren<Image>();
                break;
            }
        }

        for (var j = 1; j < keys.Count + 1; j++)
        {
            sprites[j].sprite = s[keys.ToList()[j - 1]];
        }
    }

    private void Update()
    {
        if (Player.stop)
        {
            
            // for (var j = 0; j < addItems.Length; j++)
            // {
            //     if (j == keys.Count - 1)
            //     {
            //         addItems[j].SetActive(true);
            //     }
            // }
            
        }
    }

    public void SetItem(int id)
    {
        if (keyPlayer.Contains(id))
        {
            Selected(new Color(1f, 1f, 1f, 1f), id);
            listItems[id].SetActive(false);
            keyPlayer.Remove(id);
        }
        else
        {
            Selected(new Color(0f, 1f, 0f, 1f), id);
            listItems[id].SetActive(true);
            keyPlayer.Add(id);
        }
    }

    public void Confirm()
    {
        keyPlayer.Sort();
        var newKeys = keys.ToList();
        newKeys.Sort();

        // for (int i = 0; i < listItems.Length; i++)
        // {
        //     for (var j = 0; j < keyPlayer.Count; j++)
        //         if (keyPlayer[j] == i)
        //             listItems[i].SetActive(true);
        // }

        Player.stop = false;

        var check = false;
        if (keyPlayer.Count == keys.Count)
        {
            for (var i = 0; i < keys.Count; i++)
            {
                check = keyPlayer[i] == newKeys[i];
            }
        }

        if (check)
        {
            DataGame.score += 1;
        }
        else
        {
            DataGame.health -= 1;
        }
        
        canvas.SetActive(false);
    }

    private void Selected(Color color, int id)
    {
        listSelected[id].color = color;
    }
}