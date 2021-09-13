using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class BuyerHandler : MonoBehaviour
{
    [Header("Properties")]
    public GameObject itemMenuPrefab;
    public BuyerPrototype buyerPrototype;
    public List<Transform> posInstanceMenu;

    public List<GameObject> itemGO;

    public void instanceListMenu()
    {
        for(int i = 0; i < buyerPrototype.menuListName.Count; i++)
        {
            GameObject GO = Instantiate(itemMenuPrefab, posInstanceMenu[i]);
            itemGO.Add(GO);
            GO.GetComponent<SpriteRenderer>().sprite = buyerPrototype.menuListName[i].menuSprite;
        }
    }

    public void onToolRequest(Tools _tools)
    {
        // doSomething
        Debug.Log("request come from player");
        foreach(Menu _menu in buyerPrototype.menuListName)
        {
            if(checkerMenu(_menu, _tools.listIgrendients))
            {
                int res = buyerPrototype.menuListName.IndexOf(_menu);
                Debug.Log(res);
                Destroy(itemGO[res]);
            }
        }

        Destroy(_tools.gameObject);

    }

    private bool checkerMenu(Menu _menu, List<enumIgrendients> _igrendients)
    {
        Debug.Log(_igrendients.SequenceEqual(_menu.igrendients));
        return _menu.igrendients.SequenceEqual(_igrendients);
    }
}
