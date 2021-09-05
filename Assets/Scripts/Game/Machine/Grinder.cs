using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grinder : MonoBehaviour
{
    public Machine machine;
    public Transform inputBeans;
    public Transform outputPowder;
    public BeansType beansType;
    public Beans beans;
    public BoxCollider2D BoxCollider2D;

    private void Awake()
    {
        machine = GetComponent<Machine>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }


    /** Validate acceptable Beans
     *  if (tools  == null) => return 'Put tools please'
     *  if (tools already) => nextProcess
     */

    public void reqInput(GameObject _beans)
    {
        //Debug.Log("req beans to grind");

        //validate reqyest from benas
        if (machine.onProcess || inputBeans.childCount > 0) return;

        machine.onProcess = true;
        beans = _beans.GetComponent<Beans>();
        runningProcess();
    }

    // Do something
    public void runningProcess()
    {
        // Set Child
        beans.gameObject.transform.parent = inputBeans;
        beans.gameObject.transform.position = inputBeans.position;
        StartCoroutine(animate(true));

        clearProcess();

    }

    private void clearProcess()
    {
        StartCoroutine(animate(false));
    }

    IEnumerator animate(bool input)
    {
        SpriteRenderer renderer = beans.gameObject.GetComponent<SpriteRenderer>();
        Color color = renderer.material.color;

        if (input)
        {
            Debug.Log("nput");
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                color.a = f;
                renderer.material.color = color;
                yield return new WaitForSeconds(.1f);
            }

            yield return new WaitForSeconds(1f);
        } else
        {
            yield return new WaitForSeconds(5f);
            Debug.Log("out");
            outputHandler();
            color.r = 200f; 
            for (float f = 0f; f >= 0; f += 0.1f)
            {
                color.a = f;
                renderer.material.color = color;
                yield return new WaitForSeconds(.1f);
            }
        }

    }

    public void outputHandler()
    {
        beans.grinderOutput(outputPowder);
        BoxCollider2D.enabled = false;


    }

}
