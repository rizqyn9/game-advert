using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Draggable : MonoBehaviour
{
    [Header("Draggable")]
    public bool isDragged;
    public Vector3 lastPosition;


    public virtual void Awake()
    {
        lastPosition = transform.position;
    }

    public virtual void OnMouseDown()
    {
        isDragged = true;
    }

    public virtual void OnMouseDrag()
    {
        if (isDragged)
        {
            // create object follow pointer and set middle object from pointer
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);

        }
    }

    public virtual void OnMouseUp()
    {
        isDragged = false;
    }
}

