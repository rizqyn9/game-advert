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
    public delegate void DragEndDelegate(Tools draggableObject);
    public DragEndDelegate dragEndDelegate;

    [Header("Properties field")]
    public ToolsType toolsType;
    public Vector3 initialPosition;
    [SerializeField] bool isDragged;
    public LayerMask layerMask = 6;

    [Header("Recipe")]
    public Recipe recipe;

    [Header("Debug")]
    public MachineType stateMachine;
    public GameObject machineGO;
    public Machine machine;
    public CoffeeMaker coffeeMaker;


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
            if (hit && hit.collider.CompareTag("CoffeeMaker") && hit.transform.gameObject.GetComponent<CoffeeMaker>().isAcceptable(false))
            {
                coffeeMaker = hit.transform.GetComponent<CoffeeMaker>();
                coffeeMaker.toolOnAccept(this);
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

    public void onCoffeeMaker()
    {

    }

    private void OnDestroy()
    {
        Debug.Log("On destroy tool");
        //Desk.Instance.updateDesk();
    }

    private void resetPlacement()
    {
        transform.position = initialPosition;
    }
}
