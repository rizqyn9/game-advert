using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuResource : Singleton<MenuResource>
{
    [Header("Properties")]
    public List<Menu> menus;

    // To get all menu in resources folder // not input manually
    private void OnValidate()
    {
        Debug.Log("Load All Menu");
        menus = Resources.LoadAll<Menu>("Menu").ToList();
    }

    private void Start()
    {
    }
}
