using UnityEngine;

namespace Game
{
    public class Grinder : Machine
    {
        [Header("Properties")]
        public Transform inputBeansPos;
        public Transform outputPowderPos;

        [Header("Debug")]
        public Beans beans;

        public override void onInput()
        {
            /// Do Somehing when user input beans
            beans.transformBeans(inputBeansPos);
            
            machineState = MachineState.ON_PROCESS;
        }

        public override void onProcess()
        {
            /// Do Somehing when machine onProcess beans to powder
            //base.onProcess();
            
            machineState = MachineState.ON_DONE;
        }

        public override void onDone()
        {
            beans.transformBeans(outputPowderPos);
            beans.onGrinderOutput();

            boxCollider2D.enabled = false;
        }
    }
}
