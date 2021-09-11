using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Menu", menuName ="scriptable/menu")]
public class Menu : ScriptableObject
{
    public string nameMenu;
    public menuListName menuListName;
    public menuClassification menuClassifications;
    public List<enumIgrendients> igrendients;
    public int difficulty;
    public GameObject menuPrefab;
    public string description;
}

/// <summary>
/// List menu classification
/// </summary>
public enum menuClassification
{
    COFFEE,
    SQUASH,
    LATTE,
    MILKSHAKE
}

/// <summary>
/// List for igrendients menu
/// </summary>
public enum enumIgrendients
{
    FRESHMILK,
    MILK_STEAMMED,
    SQUASH_ORANGE,
    SQUASH_PEACH,
    SQUASH_FRUIT,
    SQUASH_CHIA_SEED,
    SODA,
    MILK_MELON,
    MILK_STRAWBERRY,
    MILK_CHOCO,
    LATTE_CHOCO,
    LATTE_RED_VELVET,
    LATTE_MATCHA,
    LATTE_TARO,
    WHIPPED_CREAM,
    ICE,
    COFFEE_FILTERED,
    BEANS_ARABICA,
    BEANS_ROBUSTA
}


/// <summary>
/// List menu registered
/// </summary>
public enum menuListName : int
{
    LATTE_MATCHA,
    LATTE_RED_VELVET,
    LATTE_TARO,
    LATTE_CHOCOLATE,
    HOT_LATTE_MATCHA,
    HOT_LATTE_RED_VELVET,
    HOT_LATTE_TARO,
    HOT_LATTE_CHOCOLATE,
    SQUASH_ORANGE,
    SQUASH_PEACH,
    SQUASH_GRENADINE,
    MIILKSHAKE_MELON,
    MIILKSHAKE_STRAWBERRY,
    MIILKSHAKE_CHOCO,
    ICE_CAPPUCINO,
    ICE_CAFFE_LATTE,
    ICE_KOPI_SUSU,
    HOT_ICE_CAPPUCINO,
    HOT_ICE_CAFFE_LATTE,
    HOT_ICE_KOPI_SUSU,
    ARABICA_FILTER,
    ROBUSTA_FILTER

}