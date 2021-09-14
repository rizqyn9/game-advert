using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Game;

public class TestDebug : MonoBehaviour
{
    public List<enumIgrendients> igren1;
    public List<enumIgrendients> igren2;

    public bool res;
    public bool res1;

    [ContextMenu("assert test")]
    public void assert()
    {
        res1 = igren1.Equals(igren1);
        res = igren1.SequenceEqual(igren2);
    }
}
