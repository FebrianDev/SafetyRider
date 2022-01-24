using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Serializable]
    struct Helm
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
    
    [Serializable]
    struct Gloves
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
    
    [Serializable]
    struct Celana
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
    
    [Serializable]
    struct Jaket
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
    
    [Serializable]
    struct Pads
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
    
    [Serializable]
    struct Sepatu
    {
        public int id;
        public bool unlock;
        public int price;
        public GameObject obj;
    }
}
