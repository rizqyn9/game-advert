using UnityEngine;



[CreateAssetMenu(menuName = "Tool")]
public class Tool : ScriptableObject
{
    [SerializeField] string Name;
    [SerializeField] Machine targetMachine;
    [SerializeField] Machine targetPlace;

}
