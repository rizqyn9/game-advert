using UnityEngine;

public enum MachineType
{
    GRINDER,
    COFFEE_MAKER,
}

public enum MachineState
{
    ON_IDLE,
    ON_VALIDATE,
    ON_INPUT,
    ON_DONE,
    ON_PROCESS,
    ON_OUTPUT,
}

namespace Game
{
    public abstract class Machine : MonoBehaviour
    {
        [Header("Machine")]
        [SerializeField] MachineState _machineState = MachineState.ON_IDLE;
        public MachineType machineType;
        public BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public MachineState machineState
        {
            get { return _machineState; }
            set {
                _machineState = value;
                onChanged();
                updateState();
            }
        }

        private void updateState()
        {
            switch (_machineState)
            {
                case MachineState.ON_VALIDATE:
                    onValidate();
                    break;
                case MachineState.ON_INPUT:
                    onInput();
                    break;
                case MachineState.ON_DONE:
                    onDone();
                    break;
                case MachineState.ON_PROCESS:
                    onProcess();
                    break;
                case MachineState.ON_OUTPUT:
                    onOutput();
                    break;
                default:
                    onIdle();
                    break;
            }
        }

        /**
         * Tools On changed
         */
        public virtual void onChanged() {
            //Debug.Log("onChanged");
        }

        public virtual void onIdle() {
            Debug.Log("onIdle");
        }

        public virtual void onValidate(GameObject gameObject = null) {
            Debug.Log("onValidate");
        }

        public virtual void onInput() {
            Debug.Log("onInput");
            onInput();
        }

        public virtual void onProcess() {
            Debug.Log("onProcess");
            onDone();
        }

        public virtual void onDone() {
            Debug.Log("onDone");
        }

        public virtual void onOutput() {
            Debug.Log("onOutput");
            boxCollider2D.enabled = true;
        }


    }
}
