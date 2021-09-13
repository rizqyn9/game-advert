using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enumBuyerType
{
    BUYER_1,
    BUYER_2
}


[CreateAssetMenu(fileName = "Buyer", menuName = "scriptable/buyer")]
public class BaseBuyer : ScriptableObject
{
    [Header("Properties")]
    public enumBuyerType enumBuyerType;
    public int difficulty;
    public int minCost;
    public int maxCost;
}
