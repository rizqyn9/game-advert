using UnityEngine;

namespace Game
{
    public class Grinder : Machine, ICoffeeMachine
    {
        [Header("Properties")]
        public Transform inputBeansPos;
        public Transform outputPowderPos;

        [Header("Debug")]
        public Beans beans;

        public bool isBeansValidated(Beans _beans)
        {
            if (outputPowderPos.childCount == 0)
            {
                beans = _beans;
                return true;
            }
            else return false;
        }

        public override void onInput()
        {
            /// Do Somehing when user input beans
            beans.transformBeans(inputBeansPos);
            beans.boxCollider2D.enabled = false;
            
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
            beans.beanState = BeanState.POWDER;
            beans.boxCollider2D.enabled = true;

            boxCollider2D.enabled = false;
        }
    }
}
