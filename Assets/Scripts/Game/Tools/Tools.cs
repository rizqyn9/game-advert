using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolsType : byte
{
    GLASS,
    CUP
}

public class Tools : MonoBehaviour
{
    public delegate void DragEndDelegate(Tools draggableObject);
    public DragEndDelegate dragEndDelegate;

    public ToolsType toolsType;
    [SerializeField] Vector3 initialPosition;
    [SerializeField] bool isDragged;
    [SerializeField] List<GameObject> machine;


    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDown()
    {
        isDragged = true;
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
        float distance = Vector2.Distance(machine[0].transform.position, transform.position);
        if(distance < 1.0f)
        {
            transform.parent = machine[0].transform;
            Debug.Log("snap");
        }
        isDragged = false;
    }

}
