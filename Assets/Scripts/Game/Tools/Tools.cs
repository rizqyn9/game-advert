using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolsType : byte
{
    GLASS,
    CUP
}

public struct ListIgredients
{

}

public class Tools : MonoBehaviour
{
    public delegate void DragEndDelegate(Tools draggableObject);
    public DragEndDelegate dragEndDelegate;

    public ToolsType toolsType;
    public Vector3 initialPosition;
    [SerializeField] bool isDragged;

    public LayerMask layerMask = 6;
   

    [Header("Debug")]
    public MachineType stateMachine;
    public GameObject machineGO;
    public Machine machine;


    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        isDragged = true;
    }

    private void Update()
    {
        //getPlacement();
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            // create object follow pointer and set middle object from pointer
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);

        }       
    }

    private void OnMouseUp()
    {
        getPlacement();
        isDragged = false;
    }

    private void getPlacement()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, layerMask);
        if (hit)
        {
            //Debug.Log(hit.transform.gameObject.name);
            machineGO = hit.transform.gameObject;
            machine = machineGO.GetComponent<Machine>();
            machine.toolRequest(this.gameObject);

        } else
        {
            resetPlacement();
        }
    }

    private void resetPlacement()
    {
        transform.position = initialPosition;
    }
}
