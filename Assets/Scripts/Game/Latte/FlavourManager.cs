using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FlavourManager : Singleton<FlavourManager>
    {
        [Header("Properties")]
        public List<Transform> instancePos;
        public GameObject flavourContainerPrefab;

        [Header("Debug")]
        public List<FlavourContainer> listInstance;


        /// <summary>
        /// Spawn Flavour Container from Level Manager
        /// </summary>
        public void instanceFlavourContainer(List<BaseFlavour> listReq)
        {
            foreach(BaseFlavour baseFlavour in listReq)
            {
                GameObject GO = Instantiate(flavourContainerPrefab, instancePos.Find(pos => pos.childCount == 0));
                FlavourContainer flavourContainer = GO.GetComponent<FlavourContainer>();
                listInstance.Add(flavourContainer);
                flavourContainer.Init(baseFlavour);
            }
        }
    }
}
