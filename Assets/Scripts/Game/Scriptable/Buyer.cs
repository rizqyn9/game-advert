using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum buyerType
{
    BUYER_1,
    BUYER_2
}


[CreateAssetMenu(fileName = "Buyer", menuName = "scriptable/buyer")]
public class Buyer : ScriptableObject
{
    [Header("Properties")]
    public buyerType buyerType;
    public int difficulty;
    public int minCost;
    public int maxCost;
    
}
