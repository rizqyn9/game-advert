using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Trash : MonoBehaviour
    {
        [ContextMenu("test")]
        public void test()
        {
            BuyerResource.Instance.test();
        }

        private static Trash _instance;
        public static Trash Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }
        public void onTrash(ToolsType toolsType) {
            //Desk.Instance.respawnTools(toolsType);
            Debug.Log("trashh");
        }
    }
}
