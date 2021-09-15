using UnityEngine;

namespace Game
{
    public class CoffeeMaker : Machine, ICoffeeMachine
    {
        [Header("Properties")]
        public Transform inputPowderPos;
        public Transform toolPlacePos;

        [Header("Debug")]
        public Beans beans;
        public Tools tools;

        public bool isBeansValidated(Beans _beans)
        {
            if (!beans && toolPlacePos.childCount != 0)
            {
                Debug.Log("Beans Input");
                beans = _beans;
                beans.transformBeans(inputPowderPos);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool isValidatedMachine(Tools _tools)
        {
            if (!tools)
            {
                tools = _tools;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void onInput()
        {
            Debug.Log("coffee maker input");
            tools.transformTool(toolPlacePos);
        }

        public void onToolInput(Tools _tools)
        {
            tools = _tools;
            tools.transformTool(toolPlacePos);
        }

        public void onBeansInput(Beans _beans)
        {
            beans = _beans;
            beans.transformBeans(inputPowderPos);
        }

        public override void onProcess()
        {
            tools.listIgrendients.Add(beans.resIgrendients);
            base.onProcess();
            Destroy(beans.gameObject);
        }
    }
}
