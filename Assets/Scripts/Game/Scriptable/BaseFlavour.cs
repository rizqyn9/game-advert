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
    public Sprite containerSprite;

    [Header("Base on drag/powder")]
    public Sprite powderSprite;

    [Header("Base on tool")]
    public GameObject prefabFlavourOnTool;
    public Sprite flavourSpriteOnTool;
}


public enum FlavourType : byte
{
    LATTE_RED_VELVET,
    LATTE_CHOCO,
    LATTE_TARO,
    LATTE_MATCHA,
    SHAKE_MELON,
    SHAKE_CHOCO,
    SHAKE_STRAWBERRY
}