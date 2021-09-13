using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [System.Serializable]
    public struct flavourSprite
    {
        public FlavourType flavourType;
        public Sprite sprite;
    }

    public enum FlavourType : byte
    {
        LATTE_RED_VELVET,
        LATTE_CHOCO,
        LATTE_TARO,
        LATTE_MATCHA,
        SHAKE_MELON,
        SHAKE_CHOCO,
        SHAKE_STRAWBERRY
    }

    public class FlavourContainer : MonoBehaviour
    {
        [Header("Properties")]
        public FlavourType flavourType;
        public enumIgrendients resIgrendients;
        public Transform spawnPos;
        public GameObject spawnObject;
        public List<flavourSprite> spriteFlavourData;

        [Header("Debug")]
        [SerializeField] Flavour flavour;
        [SerializeField] flavourSprite flavourSprite;

        private void Awake()
        {
            spawnFlavour();
        }

        public void spawnFlavour()
        {
            if(spawnPos.childCount == 0)
            {
                Debug.Log("Spawn Flavour");
                flavour = Instantiate(spawnObject, spawnPos).GetComponent<Flavour>();
                flavourSprite = spriteFlavourData.Find(res => res.flavourType == flavourType);
                flavour.spriteOnTool = flavourSprite.sprite;
                flavour.flavourContainer = this;
                flavour.resIgrendients = resIgrendients;
            }
        }


    }
}
