using UnityEngine;

public enum BuyerType : byte
{
    Boss,
    Caseer,
    Pler
}

[CreateAssetMenu(menuName = "Buyer")]
public class Buyer : ScriptableObject
{
    [SerializeField] string NameBuyer;
    [SerializeField] string BuyerID;
    [SerializeField] Animation animation;
    [SerializeField] Sprite sprite;
}
