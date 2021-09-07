using UnityEngine;

namespace Game
{
    public class CoffeeMaker : Machine
    {
        [Header("Properties")]
        public Transform inputPowderPos;
        public Transform toolPlacePos;

        [Header("Debug")]
        public Beans beans;
        public Tools tools;

        public bool isValidated(bool isBeansChecker)
        {
            // validate beans
            if (isBeansChecker
                && !beans
                && tools
                )
            {
                Debug.Log("Tools validated");
                return true;
            } else 
            // validate tools
            if (!isBeansChecker
                && !beans
                && !tools
                )
            {
                Debug.Log("Tools validated");
                return true;
            } else
            {
                Debug.Log("Beans not validated");
                return false;
            }
        }

        public override void onInput()
        {
            base.onInput();
        }

        public void onToolInput(Tools _tools)
        {
            tools = _tools;
            tools.transformTool(toolPlacePos);
        }

        public void onBeansInput(Beans _beans)
        {
            beans = _beans;
            beans.inputCoffeeMaker(this);
            beans.transformBeans(inputPowderPos);
        }

        public override void onProcess()
        {
            tools.recipe.beanState = beans.beanState;
            tools.recipe.beansType = beans.beansType;
            base.onProcess();
            Destroy(beans.gameObject);
        }
    }
}
