using UnityEngine;

public enum MachcineType : byte
{
    Mach1,
    Mach2,
    Mach3
}


[CreateAssetMenu(menuName = "Machine")]
public class Machine : ScriptableObject
{
    [SerializeField] string Name;
    [SerializeField] string CodeID;
    [SerializeField] Animation animation;
    [SerializeField] int level;
    [SerializeField] float speed;
    [SerializeField] int ProcessingMax;
    [SerializeField] Sprite machineAsset;
    [SerializeField] Object InputTool;
    [SerializeField] Object OutputTool;

}
