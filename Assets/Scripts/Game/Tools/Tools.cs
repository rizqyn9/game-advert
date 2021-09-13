using System;
using System.Collections.Generic;
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


    public class Tools : Draggable
    {
        [Header("Properties field")]
        public ToolsType toolsType;
        public Transform igrendientsParent;
        public LayerMask layerMask = 6;
        public LayerMask custLayerMask;

        [Header("Recipe")]
        public Recipe recipe;
        public List<enumIgrendients> listIgrendients;

        [Header("Debug")]
        [SerializeField] SpriteRenderer spriteRenderer;
        public CoffeeMaker coffeeMaker;
        public Plate plate;
        public FreshMilk freshMilk;
        public WhippedCream whippedCream;
        public Syrup syrup;
        public MilkSteam milkSteam;

        public override void OnMouseUp()
        {
            base.OnMouseUp();
            getPlacement();
            Desk.Instance.updateDesk();
        }

        #region Placement
        private void getPlacement()
        {
            try
            {
                RaycastHit2D custHit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, custLayerMask);
                if (custHit)
                {
                    //do Something
                    Debug.Log("Customer");
                    custHit.transform.GetComponent<BuyerHandler>().onToolRequest(this);
                }

                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, layerMask);
                raycastMachineHandler(hit);
            }
            catch
            {
                Debug.Log("reset");
                resetPlacement();
            }
        }

        #endregion

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

        private void onSteam(MilkSteam _milkSteam)
        {
            milkSteam = _milkSteam;
            milkSteam.tools = this;
            milkSteam.machineState = MachineState.ON_INPUT;
        }

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

        #region Flavour
        public bool isValidated()
        {
            Debug.Log("Kontol");
            return true;
        }
        #endregion

        private void raycastMachineHandler(RaycastHit2D hit)
        {
            if (
                hit.collider.CompareTag("CoffeeMaker")
                && hit.transform.GetComponent<CoffeeMaker>().isValidated(false)
                )
            {
                onCoffeeMaker(hit.transform.GetComponent<CoffeeMaker>());
            }
            else if (
              hit.collider.CompareTag("Trash")
              )
            {
                Trash.Instance.onTrash(toolsType);
                Destroy(this.gameObject);
            }
            else if (
                hit.collider.CompareTag("Plate")
                && hit.transform.GetComponent<Plate>().isValidated()
              )
            {
                Debug.Log("Plate");
                onPlate(hit.transform.GetComponent<Plate>());
            }
            else if (
                hit.collider.CompareTag("FreshMilk")
                && hit.transform.GetComponent<FreshMilk>()
              )
            {
                Debug.Log("freshmik");
                onFreshMilk(hit.transform.GetComponent<FreshMilk>());
            }
            else if (
                hit.collider.CompareTag("WhippedCream")
                && hit.transform.GetComponent<WhippedCream>()
              )
            {
                Debug.Log("WhippedCream");
                onWhippedCream(hit.transform.GetComponent<WhippedCream>());
            }
            else if (
                hit.collider.CompareTag("Syrup")
                && hit.transform.GetComponent<Syrup>()
              )
            {
                Debug.Log("Syrup");
                onSyrup(hit.transform.GetComponent<Syrup>());
            }
            else if (
                hit.collider.CompareTag("MilkSteam")
                && hit.transform.GetComponent<MilkSteam>()
              )
            {
                Debug.Log("MilkSteam");
                onSteam(hit.transform.GetComponent<MilkSteam>());
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
