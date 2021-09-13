using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class ResourcesManager : Singleton<ResourcesManager>
{
    public List<BaseBuyer> BuyerResources;
    public List<BaseMenu> MenuResources;
    public List<BaseLevel> LevelResources;
    public List<BaseFlavour> FlavourResources;

    [ContextMenu("Load All resources")]
    public void validateAllesources()
    {
        buyerValidate();
        menuValidate();
        levelValidate();
        flavourValidate();
    }

    [ContextMenu("Validate Buyer")]
    public void buyerValidate()
    {
        BuyerResources = Resources.LoadAll<BaseBuyer>("Buyer").ToList();
    }

    [ContextMenu("Validate Menu")]
    public void menuValidate()
    {
        MenuResources = Resources.LoadAll<BaseMenu>("Menu").ToList();
    }

    [ContextMenu("Validate Level")]
    public void levelValidate()
    {
        LevelResources = Resources.LoadAll<BaseLevel>("Level").ToList();
    }
    [ContextMenu("Validate Flavour")]
    public void flavourValidate()
    {
        FlavourResources = Resources.LoadAll<BaseFlavour>("Flavour").ToList();
    }
}
