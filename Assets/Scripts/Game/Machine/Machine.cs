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
                    onValidate();
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
            Debug.Log("onChanged");
        }

        public virtual void onIdle() {
            Debug.Log("onIdle");
        }

        public virtual void onValidate() {
            Debug.Log("onValidate");
        }

        public virtual void onInput() {
            Debug.Log("onInput");
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
        }


    }
}
