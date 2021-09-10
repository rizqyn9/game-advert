using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyerResource : Singleton<BuyerResource>
{
    [Header("Properties")]
    public List<Buyer> buyers;

    public void test()
    {
        Debug.Log("testt");
    }

    private void OnValidate()
    {
        Debug.Log("Vlidate reesoursce buyer");
        buyers = Resources.LoadAll<Buyer>("Buyer").ToList();        
    }

    private void Awake()
    {
        Debug.Log("awake");
    }
}
