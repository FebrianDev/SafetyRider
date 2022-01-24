using System;
using System.Collections.Generic;
using UnityEngine;

public class HelmChoice : MonoBehaviour
{
    
    [SerializeField] private List<Helm> _list = new List<Helm>();
    private int temp;
    
    private void Start()
    {
        
    }

    public void SetHelm(int id)
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
}