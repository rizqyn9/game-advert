using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSpawner : Singleton<BuyerSpawner>
{
    [Header("Properties")]
    public int maxBuyer = 5;

    [Header("Debug")]
    public List<Buyer> buyers;
    public int buyerResourceCount;

    private void Start()
    {
        buyerResourceCount = BuyerResource.Instance.buyers.Count;

        for(int i = 0; i < 5; i++)
        {
            buyers.Add(BuyerResource.Instance.buyers[Random.RandomRange(0, buyerResourceCount)]);
        }
    }
}
