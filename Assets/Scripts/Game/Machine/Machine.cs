using UnityEngine;

public enum MachineType
{
    GRINDER,
    COFFEE_MAKER,
    FRESHMILK,
    WHIPPED_CREAM,
    SYRUP,
    MILK_STEAM

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

        public virtual bool isValidatedMachine(Tools _tools) {
            return true;
        }

        /// <summary>
        /// trigger every state changed
        /// </summary>
        public virtual void onChanged() {
            //Debug.Log("onChanged");
        }

        /// <summary>
        /// trigger when state on machine state on Idle
        /// </summary>
        public virtual void onIdle() {
            Debug.Log("onIdle");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObject try to validating before init on Machine"></param>
        public virtual void onValidate(GameObject gameObject = null) {
            Debug.Log("onValidate");
        }

        /// <summary>
        /// trigger when 
        /// </summary>
        public virtual void onInput() {
            Debug.Log("onInput");
            onProcess();
        }

        public virtual void onProcess() {
            Debug.Log("onProcess");
            onDone();
        }

        public virtual void onDone() {
            boxCollider2D.enabled = false;
            Debug.Log("onDone");
        }

        public virtual void onOutput() {
            Debug.Log("onOutput");
            boxCollider2D.enabled = true;
            machineState = MachineState.ON_IDLE;
        }


    }
}
