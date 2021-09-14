using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Tools : Draggable
    {
        [Header("Properties field")]
        public Transform igrendientsParent;
        public LayerMask layerMask = 6;
        public LayerMask custLayerMask;

        [Header("Debug")]
        public List<enumIgrendients> listIgrendients;
        [SerializeField] Machine _Machine;
        [SerializeField] SpriteRenderer spriteRenderer;
        public Flavour flavour;
        public CoffeeMaker coffeeMaker;
        public Plate plate;
        public FreshMilk freshMilk;
        public WhippedCream whippedCream;
        public Syrup syrup;
        public MilkSteam milkSteam;

        public Machine machine
        {
            get => _Machine;
            set
            {
                // DO SOMETHING
                if (_Machine) _Machine.machineState = MachineState.ON_DONE;
                _Machine = value;
            }
        }

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
                if (custHit) raycastCustomerHandler(custHit);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, layerMask);
                if (hit) raycastMachineHandler(hit);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
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
            machine = _freshMilk as Machine;
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
            if (!flavour                                                        // flavour must set to null
                && listIgrendients.Contains(enumIgrendients.MILK_STEAMMED)      // tool must have Milk Steammed
                ) return true;
            return false;
        }
        #endregion

        private void raycastMachineHandler(RaycastHit2D hit)
        {
            machine = hit.transform.GetComponent<Machine>();
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
                Trash.Instance.onTrash();
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
                onSyrup(hit.transform.GetComponent<Syrup>());
            }
            else if (
                hit.collider.CompareTag("MilkSteam")
                && hit.transform.GetComponent<MilkSteam>()
              )
            {
                onSteam(hit.transform.GetComponent<MilkSteam>());
            }
            else
            {
                throw new Exception();
            }
        }

        private void raycastCustomerHandler(RaycastHit2D custHit)
        {
            //do Something
            Debug.Log("Customer");
            custHit.transform.GetComponent<BuyerHandler>().onToolRequest(this);
        }
    }
}
