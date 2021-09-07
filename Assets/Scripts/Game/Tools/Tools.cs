using System;
using UnityEngine;
using Game;

[Serializable]
public struct Recipe
{
    public BeansType beansType;
    public BeanState beanState;
}

public enum ToolsType
{
    GLASS,
    CUP
}

public struct ListIgredients
{

}

public class Tools : MonoBehaviour
{
    [Header("Properties field")]
    public ToolsType toolsType;
    public LayerMask layerMask = 6;

    [Header("Recipe")]
    public Recipe recipe;

    [Header("Debug")]
    [SerializeField] bool isDragged;
    public Vector3 lastPosition;
    public MachineType stateMachine;
    public GameObject machineGO;
    public CoffeeMaker coffeeMaker;


    private void Awake()
    {
        lastPosition = transform.position;
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
        getPlacement();
        isDragged = false;

        // Update desk 
        Desk.Instance.updateDesk();
    }

    private void getPlacement()
    {
        try
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, layerMask);
            if (
                hit
                && hit.collider.CompareTag("CoffeeMaker")
                && hit.transform.gameObject.GetComponent<CoffeeMaker>().isValidated(false)
                )
            {
                onCoffeeMaker(hit.transform.GetComponent<CoffeeMaker>());
            } else if (hit && hit.collider.CompareTag("Trash"))
            {
                Trash.Instance.onTrash(toolsType);
                Debug.Log("Trashh");
                Destroy(this.gameObject);
            }
            else
            {
                throw new Exception();
            }

        }
        catch
        {
            Debug.Log("reset");
            resetPlacement();
        }
    }

    public void onCoffeeMaker(CoffeeMaker _coffeeMaker)
    {
        coffeeMaker = _coffeeMaker;
        coffeeMaker.onToolInput(this);
    }

    private void resetPlacement()
    {
        transform.position = lastPosition;
    }

    public void transformTool(Transform _transform)
    {
        transform.parent = _transform;
        transform.position = _transform.position;
        lastPosition = _transform.position;
    }

    private void OnDestroy()
    {
        Debug.Log("On destroy tool");
        //Desk.Instance.updateDesk();
    }
}
