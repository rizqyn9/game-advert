using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaker : MonoBehaviour
{
    public Transform inputPowder;
    public Machine machine;

    private void Awake()
    {
        machine = GetComponent<Machine>();
    }


}
