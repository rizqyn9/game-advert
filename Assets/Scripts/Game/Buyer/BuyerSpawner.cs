using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuyerPrototype
{
    public enumBuyerType enumBuyerType;
    public List<Menu> menuListName;
}

public class BuyerSpawner : Singleton<BuyerSpawner>
{
    [Header("Properties")]
    public int maxBuyer = 2;
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
        menuResourceRegistered = MenuResource.Instance.menus.Count;

        for(int i = 0; i < maxBuyer; i++)
        {
            BuyerPrototype _buyerPrototype = new BuyerPrototype();
            _buyerPrototype.enumBuyerType = enumBuyerType.BUYER_1;
            _buyerPrototype.menuListName = getMenu(Random.Range(1,3));
            GameObject go = Instantiate(buyerPrefab, spawnPlace[i]);
            BuyerHandler buyerHandler = go.GetComponent<BuyerHandler>();
            buyerHandler.buyerPrototype = _buyerPrototype;
            buyerHandler.instanceListMenu();
        }
    }

    /// <summary>
    /// Generate random and get menu enum
    /// </summary>
    /// <param name="_total"></param>
    /// <returns></returns>
    public List<Menu> getMenu(int _total)
    {
        List<Menu> menuGen = new List<Menu>();
        while(_total != 0)
        {
            menuGen.Add(MenuResource.Instance.menus[Random.Range(0, menuResourceRegistered)]);
            _total--;
        }
        return menuGen;
    }

    public void haha()
    {
        throw new System.NotImplementedException();
    }
}