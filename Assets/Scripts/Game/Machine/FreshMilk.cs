using UnityEngine;

// Notes dont forget clear Debug after tool onOutput()

namespace Game
{
    public class FreshMilk : Machine
    {
        [Header("Properties")]
        public enumIgrendients resIgrendients;
        public Transform toolPos;
        public GameObject milkPrefab;

        [Header("Debug")]
        public Tools tools;

        public bool isValidated()
        {
            if( toolPos.childCount == 0
                && !tools
                )
            {

                return true;
            }
            return false;
        }

        public override void onInput()
        {
            tools.transformTool(toolPos);
            base.onInput();
        }

        public override void onProcess()
        {
            base.onProcess();
        }

        public override void onDone()
        {
            tools.listIgrendients.Add(resIgrendients);
            GameObject go = Instantiate(milkPrefab, tools.igrendientsParent);
            base.onDone();
        }

        public override void onOutput()
        {
            base.onOutput();
        }
    }
}
