using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FlavourContainer : MonoBehaviour
    {
        [Header("Properties")]
        public Transform spawnPos;
        public GameObject spawnPowderPrefab;
        public SpriteRenderer staticSpriteContainer;

        [Header("Debug")]
        [SerializeField] BaseFlavour baseFlavour;
        [SerializeField] Flavour flavour;

        public void Init(BaseFlavour _baseFlavour)
        {
            baseFlavour = _baseFlavour;
            staticSpriteContainer.sprite = baseFlavour.containerSprite;
            spawnFlavour();
        }

        public void spawnFlavour()
        {
            if(spawnPos.childCount == 0)
            {
                Debug.Log("Spawn Flavour");
                flavour = Instantiate(spawnPowderPrefab, spawnPos).GetComponent<Flavour>();
                flavour.baseFlavour = baseFlavour;
                flavour.flavourContainer = this;
            }
        }
    }
}
