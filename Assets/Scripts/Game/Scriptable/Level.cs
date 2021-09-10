using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "scriptable/level")]
public class Level : ScriptableObject
{
    [Header("Properties")]
    public int numLevel;
    public int minBuyerOrder;
    public int maxBuyerOrder;


}
