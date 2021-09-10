using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class Desk : MonoBehaviour
    {
        private static Desk _instance;
        public static Desk Instance { get { return _instance; } }

        [Header("Property field")]
        public GameObject glassPrefab;
        public GameObject cupPrefab;
        public Transform glassPos;
        public Transform cupPos;

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

        private void Start()
        {
            updateDesk();
        }

        private void Update()
        {
            updateDesk();
        }
        public void updateDesk()
        {
            //Debug.Log("updateDesk");
            if (glassPos.childCount < 1) respawnTools(ToolsType.GLASS);
            if (cupPos.childCount < 1) respawnTools(ToolsType.CUP);
        }

        public void respawnTools(ToolsType _toolsType)
        {
            //Debug.Log("asdad");
            switch (_toolsType)
            {
                case ToolsType.GLASS:
                    Instantiate(glassPrefab, glassPos);
                    break;

                case ToolsType.CUP:
                    Instantiate(cupPrefab, cupPos);
                    break;

                default:
                    throw new System.Exception("respawn Error");
            }
        }
    }
}
