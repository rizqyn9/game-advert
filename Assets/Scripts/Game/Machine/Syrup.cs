using UnityEngine;

namespace Game
{
    public enum SyrupType
    {
        ORANGE,
        PASSION,
        PEACH
    }

    public class Syrup : Machine
    {
        [Header("Properties")]
        public Transform toolPos;
        public SyrupType syrupType;

        [Header("Debug")]
        public Tools tools;

        public bool isValidated()
        {
            if (toolPos.childCount == 0
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
            base.onDone();
        }

        public override void onOutput()
        {
            base.onOutput();
        }

        public override bool isValidatedMachine()
        {
            throw new System.NotImplementedException();
        }
    }
}
