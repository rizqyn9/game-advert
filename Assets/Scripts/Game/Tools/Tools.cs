using System;
using UnityEngine;

namespace Game
{
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
        [SerializeField] SpriteRenderer spriteRenderer;
        public Vector3 lastPosition;
        //public GameObject machineGO;
        public CoffeeMaker coffeeMaker;
        public Plate plate;
        public FreshMilk freshMilk;
        public WhippedCream whippedCream;
        public Syrup syrup;

        #region DRAG
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

        #endregion

        private void getPlacement()
        {
            try
            {
                
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, layerMask);
                if (
                    hit
                    && hit.collider.CompareTag("CoffeeMaker")
                    && hit.transform.GetComponent<CoffeeMaker>().isValidated(false)
                    )
                {
                    onCoffeeMaker(hit.transform.GetComponent<CoffeeMaker>());
                } else if (
                    hit
                    && hit.collider.CompareTag("Trash")
                    )
                {
                    Trash.Instance.onTrash(toolsType);
                    Debug.Log("Trashh");
                    Destroy(this.gameObject);
                } else if (
                    hit
                    && hit.collider.CompareTag("Plate")
                    && hit.transform.GetComponent<Plate>().isValidated()
                    )
                {
                    Debug.Log("Plate");
                    onPlate(hit.transform.GetComponent<Plate>());
                } else if (
                    hit
                    && hit.collider.CompareTag("FreshMilk")
                    && hit.transform.GetComponent<FreshMilk>()
                    )
                {
                    Debug.Log("freshmik");
                    onFreshMilk(hit.transform.GetComponent<FreshMilk>());
                } else if (
                    hit
                    && hit.collider.CompareTag("WhippedCream")
                    && hit.transform.GetComponent<WhippedCream>()
                    )
                {
                    Debug.Log("WhippedCream");
                    onWhippedCream(hit.transform.GetComponent<WhippedCream>());
                } else if (
                    hit
                    && hit.collider.CompareTag("Syrup")
                    && hit.transform.GetComponent<Syrup>()
                    )
                {
                    Debug.Log("Syrup");
                    onSyrup(hit.transform.GetComponent<Syrup>());
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


        #region onCoffeeMaker
        public void onCoffeeMaker(CoffeeMaker _coffeeMaker)
        {
            coffeeMaker = _coffeeMaker;
            coffeeMaker.onToolInput(this);
        }
        #endregion

        #region onPlate
        void onPlate(Plate _plate)
        {
            plate = _plate;
            plate.onInput(this);
        }
        #endregion

        #region OnFreshMilk
        public void onFreshMilk(FreshMilk _freshMilk)
        {
            Debug.Log("onFreshMilk");
            freshMilk = _freshMilk;
            freshMilk.tools = this;
            freshMilk.machineState = MachineState.ON_INPUT;
        }
        #endregion

        #region OnWhippedCream
        private void onWhippedCream(WhippedCream _whippedCream)
        {
            whippedCream = _whippedCream;
            whippedCream.tools = this;
            whippedCream.machineState = MachineState.ON_INPUT;
        }

        #endregion

        #region OnSyrup
        private void onSyrup(Syrup _syrup)
        {
            syrup = _syrup;
            syrup.tools = this;
            syrup.machineState = MachineState.ON_INPUT;
        }
        #endregion

        #region Depends

        private void resetPlacement()
        {
            transform.position = lastPosition;
        }

        public void transformTool(Transform _transform)
        {
            Debug.Log("asdasdad");
            transform.parent = _transform;
            transform.position = _transform.position;
            lastPosition = _transform.position;
        }

        private void OnDestroy()
        {
            Debug.Log("On destroy tool");
            //Desk.Instance.updateDesk();
        }

        #endregion
    }
}
