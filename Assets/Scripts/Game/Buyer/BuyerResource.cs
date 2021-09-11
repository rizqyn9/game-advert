using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyerResource : Singleton<BuyerResource>
{
    [Header("Properties")]
    public List<BuyerType> buyers;

    private void OnValidate()
    {
        buyers = Resources.LoadAll<BuyerType>("Buyer").ToList();
        checkBuyerTypeIsDifferent();
        Debug.Log("Validate resources buyer success");
    }

    /// <summary>
    /// validate buyer type, to prevent same value in buyerType
    /// </summary>
    private void checkBuyerTypeIsDifferent()
    {
        List<enumBuyerType> containerBuyerTypes = new List<enumBuyerType>();

        foreach(BuyerType buyerType in buyers)
        {
            if (containerBuyerTypes.Contains(buyerType.enumBuyerType))
            {
                Debug.LogError("Buyer Type must deferent");
            } else
            {
                containerBuyerTypes.Add(buyerType.enumBuyerType);
            }
        }
    }
}
