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


    public class Beans : MonoBehaviour
    {
        [Header("Properties")]
        public BeansType beansType;
        public BeanState beanState;
        public List<Sprite> spriteList;

        [Header("Debug")]
        public SpriteRenderer spriteRenderer;
        public BoxCollider2D boxCollider2D;
        public bool isDragged;
        public Vector2 lastPosition;
        [SerializeField] LayerMask machineLayerMask;

        private Grinder grinder;
        private CoffeeMaker coffeeMaker;


        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            lastPosition = transform.position;
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

            if (
                hit
                && hit.collider.CompareTag("Grinder")               // Get Grinder from Tag
                && beanState == BeanState.BEANS                     // beans state as Beans not powder
                && !hit.transform.GetComponent<Grinder>().beans     // beans in grinder == null
                )
            {
                onGrinderInput(hit.transform.gameObject);
            } else if (
                hit
                && hit.collider.CompareTag("CoffeeMaker")
                && beanState == BeanState.POWDER
                && hit.transform.GetComponent<CoffeeMaker>().isValidated(true)
                )
            {
                onCoffeeMakerInput(hit.transform.gameObject);
            }
            else
            {
                resetPlacement();
            }
        }

        public void transformBeans(Transform _transform)
        {
            transform.parent = _transform;
            transform.position = _transform.position;
            lastPosition = _transform.position;
        }

        #region ON GRINDER
        private void onGrinderInput(GameObject _grinder)
        {
            grinder = _grinder.GetComponent<Grinder>();
            grinder.beans = this;
            grinder.machineState = MachineState.ON_INPUT;
        }

        public void onGrinderProcess()
        {
            // do Something
            boxCollider2D.enabled = false;
        }

        public void onGrinderOutput()
        {
            boxCollider2D.enabled = true;
            beanState = BeanState.POWDER;
        }
        #endregion

        #region ON COFFEE MAKER

        private void onCoffeeMakerInput(GameObject _coffeeMaker)
        {
            coffeeMaker = _coffeeMaker.GetComponent<CoffeeMaker>();
            coffeeMaker.onBeansInput(this);
            coffeeMaker.machineState = MachineState.ON_PROCESS;
        }

        public void inputCoffeeMaker(CoffeeMaker _coffeeMaker)
        {
            coffeeMaker = _coffeeMaker;
        }

        #endregion

        private void resetPlacement()
        {
            transform.position = lastPosition;
        }
    }
}
