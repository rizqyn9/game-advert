using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[CreateAssetMenu(fileName = "Flavour", menuName = "scriptable/flavour")]
public class BaseFlavour : ScriptableObject
{
    [Header("Base on container")]
    public FlavourType flavourType;
    public enumIgrendients resIgrendients;

    [Header("Base on tool")]
    public GameObject prefabFlavourOnTool;

}
