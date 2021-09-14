using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LevelManager : Singleton<LevelManager>
    {
        [Header("Properties")]
        public BaseLevel level;
        public List<BaseFlavour> baseFlavours;

        private void Start()
        {
            FlavourManager.Instance.instanceFlavourContainer(baseFlavours);
        }
    }
}
