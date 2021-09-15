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
        public Plate plate;
        public Flavour flavour;
        public CoffeeMaker coffeeMaker;
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
                if (_Machine) _Machine.machineState = MachineState.ON_OUTPUT;
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
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, layerMask);

                if (custHit) raycastCustomerHandler(custHit);

                //if (hit) raycastMachineHandler(hit);
                else if (hit) newRaycastSystem(hit);

                else throw new Exception();

            }
            catch (Exception e)
            {
                Debug.LogError(e);
                resetPlacement();
            }
        }

        public void newRaycastSystem(RaycastHit2D _hit)
        {
            Machine _machine = _hit.transform.GetComponent<Machine>();
            Plate _plate = _hit.transform.GetComponent<Plate>();

            /// clear plate
            if (plate) plate.onOut();

            if (_machine && _machine.isValidatedMachine(this))
            {
                Debug.Log("Tools on Machine Class");

                machine = _machine;
                machine.machineState = MachineState.ON_INPUT;
            } else if (_hit.collider.CompareTag("Trash"))
            {
                machine = null;
                Trash.Instance.onTrash();
                Destroy(gameObject);
            } else if (_plate && _plate.isValidatedPlate(this))
            {
                plate = _plate;
                machine = null;
                _plate.onInput(this);
            } else
            {
                throw new Exception();
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

        private void raycastCustomerHandler(RaycastHit2D custHit)
        {
            //do Something
            Debug.Log("Customer");
            custHit.transform.GetComponent<BuyerHandler>().onToolRequest(this);
        }
    }
}
