using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class CoffeeMaker : MonoBehaviour
{
    [Header("Properties")]
    public Transform inputPowder;
    public Transform toolPlace;

    [Header("Debug")]
    public Machine machine;
    [SerializeField] Beans beans;
    [SerializeField] Tools tools;

    private void Awake()
    {
        machine = GetComponent<Machine>();
    }

    public bool isAcceptable(bool isBeans)
    {
        //if (machine.onProcess) return false;
        // Beans validate
        if (isBeans && toolPlace.childCount == 1 && inputPowder.childCount < 1) return true;
        // Tools validate
        if (!isBeans && toolPlace.childCount < 1) return true;
        return false;
    }

    public void toolOnAccept(Tools _tools)
    {
        tools = _tools;
        _tools.gameObject.transform.parent = toolPlace;
        _tools.gameObject.transform.position = toolPlace.position;
    }

    public void beanInput(Beans _beans)
    {
        //validate reqyest from benas
        //Debug.Log("req powder to coffeeMaker");
        beans = _beans;
        beans.inputCoffeeMaker(this);

        onProcessCoffeeMaker();
    }

    private void onProcessCoffeeMaker()
    {
        //Do Something
        //machine.onProcess = true;
        Destroy(beans.gameObject);
        tools.recipe.beanState = beans.beanState;
        tools.recipe.beansType = beans.beansType;
    }
}
