using UnityEngine;

// Notes dont forget clear Debug after tool onOutput()

namespace Game
{
    public class MilkSteam : Machine
    {
        [Header("Properties")]
        public enumIgrendients resIgrendients;
        public Transform toolPos;
        public GameObject milkSteamPrefab;

        [Header("Debug")]
        public Tools tools;

        public override bool isValidatedMachine(Tools _tools)
        {
            Debug.Log("onValidate");
            if (toolPos.childCount < 1 && !_tools.listIgrendients.Contains(resIgrendients))
            {
                tools = _tools;
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
            GameObject go = Instantiate(milkSteamPrefab, tools.igrendientsParent);
            base.onDone();
        }

        public override void onOutput()
        {
            tools = null;
            base.onOutput();
        }
    }
}
