using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BeanState : byte
{
    BEANS,
    POWDER,
}


public class Beans : MonoBehaviour
{
    public BeansType beansType;
    public BeanState beanState;
    public List<Sprite> spriteList;
    public SpriteRenderer spriteRenderer;
    public bool isDragged;
    public bool isDragable = true;
    public Vector2 lastPosition;
    [SerializeField] LayerMask machineLayerMask;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastPosition = transform.position;
    }

    private void Update()
    {
        //getPlacement();
    }

    // Trigger from BeanMachine on Instantiate
    public void Init(BeansType _beansType)
    {
        beansType = _beansType;
        if(beansType == BeansType.ARABICA)
        {
            spriteRenderer.color = Color.yellow;
        } else
        {
            spriteRenderer.color = Color.grey;
        }
    }

    public void OnMouseDown() => isDragged = true;

    private void OnMouseDrag()
    {
        //Debug.Log("dragBeans");
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
        //Debug.Log("get Placement");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, machineLayerMask);

        if (hit && hit.collider.CompareTag("Grinder"))
        {
            Debug.Log("grind");
            getGrinder(hit.transform.gameObject);
        } else if (hit && hit.collider.CompareTag("CoffeeMaker"))
        {
            Debug.Log("grind");

        }
        else
        {
            resetPlacement();
        }
    }

    #region ON GRINDER
    private void getGrinder(GameObject _grinder)
    {
        _grinder.GetComponent<Grinder>().reqInput(this.gameObject);
        isDragable = false;
    }

    public void grinderOutput(Transform _transformParent)
    {
        lastPosition = _transformParent.position;

        transform.parent = _transformParent.parent;
        transform.position = _transformParent.position;

        isDragable = true;
    }
    #endregion


    private void resetPlacement()
    {
        transform.position = lastPosition;
    }
}
