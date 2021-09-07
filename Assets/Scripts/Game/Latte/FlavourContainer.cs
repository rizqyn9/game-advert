using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
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
        public Transform spawnPos;
        public GameObject spawnObject;

        [Header("Debug")]
        [SerializeField] Flavour flavour;

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
                flavour.flavourContainer = this;
            }
        }


    }
}
