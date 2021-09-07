using System;
using UnityEngine;


/**
 * if OnProcess return warning
 * !OnProcess next step
 * Run method transition => duration / animation (use Coroutine)
 * 
 */
namespace Game
{
    public class BeansMachine : Machine
    {
        [Header("Properties")]
        public MachineType machineType;
        public BeansType beansType;
        public GameObject beansPrefab;
        public Transform output;

        [Header("DEBUG")]
        [SerializeField] bool _isFilled;

        public void OnMouseDown()
        {
            machineState = MachineState.ON_VALIDATE;
        }

        public void SpawnBeans()
        {
            GameObject beansOut = Instantiate(beansPrefab, output);
            beansOut.GetComponent<Beans>().Init(beansType);
        }

        public override void onValidate()
        {
            if (machineState != MachineState.ON_IDLE
                && output.childCount > 0
                )
            {
                Debug.Log("Beans Already");
                return;
            }

            machineState = MachineState.ON_PROCESS;
        }

        public override void onProcess()
        {
            SpawnBeans();
            machineState = MachineState.ON_IDLE;
        }
    }
}
