using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuyerPrototype
{
    public enumBuyerType enumBuyerType;
    public List<menuListName> menuListName;
}

public class BuyerSpawner : Singleton<BuyerSpawner>
{
    [Header("Properties")]
    public int maxBuyer = 3;
    public GameObject buyerPrefab;
    public Transform[] spawnPlace;

    [Header("Debug")]
    public List<BuyerPrototype> buyerProto = new List<BuyerPrototype>();
    public int buyerResourceCount;
    public int menuResourceRegistered;
    public List<menuListName> debugMenu;

    private void Start()
    {
        buyerResourceCount = BuyerResource.Instance.buyers.Count;
        menuResourceRegistered = System.Enum.GetNames(typeof(menuListName)).Length;

        for(int i = 0; i < maxBuyer; i++)
        {
            BuyerPrototype _buyerPrototype = new BuyerPrototype();
            _buyerPrototype.enumBuyerType = enumBuyerType.BUYER_1;
            _buyerPrototype.menuListName = getMenu(Random.Range(1,4));
            GameObject go = Instantiate(buyerPrefab, spawnPlace[i]);
            go.GetComponent<BuyerHandler>().buyerPrototype = _buyerPrototype;
        }
    }

    /// <summary>
    /// Generate random and get menu enum
    /// </summary>
    /// <param name="_total"></param>
    /// <returns></returns>
    public List<menuListName> getMenu(int _total)
    {
        List<menuListName> menuGen = new List<menuListName>();
        while(_total != 0)
        {
            menuGen.Add((menuListName)Random.Range(0, menuResourceRegistered));
            _total--;
        }
        return menuGen;
    }

    public void haha()
    {
        throw new System.NotImplementedException();
    }
}