using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum BeanState : byte
    {
        BEANS,
        POWDER,
    }

    public enum BeansType : byte
    {
        ARABICA,
        ROBUSTA
    }

    public interface ICoffeeMachine
    {
        public bool isBeansValidated(Beans _beans);
    }

    public class Beans : Draggable
    {
        [Header("Properties")]
        public BeansType beansType;
        public BeanState beanState;
        public List<Sprite> spriteList;

        [Header("Debug")]
        public SpriteRenderer spriteRenderer;
        public enumIgrendients resIgrendients;
        [SerializeField] LayerMask machineLayerMask;
        [SerializeField] Machine _machine;

        public Machine machine
        {
            get => _machine;
            set
            {
                _machine.machineState = MachineState.ON_OUTPUT;
                _machine = value;
            }
        }

        // Trigger from BeanMachine on Instantiate
        public void Init(BeansType _beansType)
        {
            beansType = _beansType;
            if(beansType == BeansType.ARABICA)
            {
                resIgrendients = enumIgrendients.BEANS_ARABICA;
                spriteRenderer.color = Color.yellow;
            } else
            {
                resIgrendients = enumIgrendients.BEANS_ROBUSTA;
                spriteRenderer.color = Color.grey;
            }
        }

        public override void OnMouseDown() => base.OnMouseDown();

        public override void OnMouseDrag()
        {
            if (isDragged)
            {
                // create object follow pointer and set middle object from pointer
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePos);
            }
        }

        public override void OnMouseUp()
        {
            getPlacement();
            base.OnMouseUp();
        }


        public void getPlacement()
        {
            try
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, machineLayerMask);

                if (hit)
                {
                    newRaycastSystem(hit);
                }
                else
                {
                    throw new System.Exception();
                }
            }
            catch
            {
                resetPlacement();
            }
        }

        public void newRaycastSystem(RaycastHit2D _hit)
        {
            Machine _machine = _hit.transform.GetComponent<Machine>();
            ICoffeeMachine coffeeMachine = _machine as ICoffeeMachine;
            if (_machine && coffeeMachine is ICoffeeMachine && coffeeMachine.isBeansValidated(this))
            {
                machine = _machine;
                Debug.Log("Beans Validated");
            } else
            {
                throw new System.Exception();
            }
        }


        public void transformBeans(Transform _transform)
        {
            transform.parent = _transform;
            transform.position = _transform.position;
            lastPosition = _transform.position;
        }

        private void resetPlacement()
        {
            transform.position = lastPosition;
        }
    }
}
