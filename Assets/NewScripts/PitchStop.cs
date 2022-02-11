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

        //Random key 
        for (var j = 0; j < less; j++)
        {
            var key = Random.Range(0, listItems.Length);
            listItems[key].SetActive(false);
            keys.Add(key);
        }

        Debug.Log("Key Player " + keyPlayer.Count);
        Debug.Log("Keys " + keys.Count);

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
        // if (Player.stop)
        // {
        //     for (var j = 0; j < addItems.Length; j++)
        //     {
        //         if (j == keys.Count - 1)
        //         {
        //             addItems[j].SetActive(true);
        //         }
        //     }
        // }
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

        Debug.Log("Key Player Confitm " + keyPlayer.Count);
        Debug.Log("New Keys Confitm " + newKeys.Count);

        Player.stop = false;

        var count = 0;
        var check = false;

        foreach (var list in listItems)
        {
            if (list.activeSelf)
            {
                check = true;
            }
            else
            {
                check = false;
                break;
            }
        }
       
        for (var i = 0; i < keyPlayer.Count; i++)
        {
            if (newKeys.Contains(keyPlayer[i]))
            {
                count++;
            }
        }

        Debug.Log("Count "+count +" NewKeysCount "+newKeys.Count);

        if (count == newKeys.Count && check)
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