using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MachineType
{
    GRINDER,
    COFFEE_MAKER,
}

public class Machine : MonoBehaviour
{
    public MachineType machineType;
    public Transform toolPlacement;
    public bool onProcess = false;

    [Header("Debug")]
    public GameObject toolsNow;

    public void toolRequest(GameObject tool)
    {
        toolsNow = tool;
        tool.transform.position = toolPlacement.position;
    }

}
