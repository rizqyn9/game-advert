using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BeansType : byte
{
    ARABICA,
    ROBUSTA
}

/**
 * if OnProcess return warning
 * !OnProcess next step
 * Run method transition => duration / animation (use Coroutine)
 * 
 */

public class BeansMachine : MonoBehaviour
{
    public bool onProcess = false;
    public BeansType beansType;
    public GameObject beansPrefab;
    public Transform output;
    public int beans;

    [SerializeField] bool _isFilled;

    // Call on user click the machine button
    public void OnMouseDown()
    {
        if (onProcess) return;

        // Check fill output
        if (output.childCount > 0) return;

        // Spawn beans
        SpawnBeans();
    }

    public void SpawnBeans()
    {
        GameObject beansOut = Instantiate(beansPrefab, output);
        beansOut.GetComponent<Beans>().Init(beansType);
    }

}
