using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class Desk : Singleton<Desk>
    {
        [Header("Property field")]
        public GameObject glassPrefab;
        public GameObject cupPrefab;
        public Transform glassPos;
        public Transform cupPos;

        private void Start()
        {
            updateDesk();
        }

        private void Update()
        {
            if (glassPos.childCount < 1) Instantiate(glassPrefab, glassPos);
            //updateDesk();
        }
        public void updateDesk()
        {
            //Debug.Log("updateDesk");
            if (glassPos.childCount < 1) Instantiate(glassPrefab, glassPos);
            //if (cupPos.childCount < 1) respawnTools(ToolsType.CUP);
        }

        //public void respawnTools(ToolsType _toolsType)
        //{
        //    //Debug.Log("asdad");
        //    switch (_toolsType)
        //    {
        //        case ToolsType.GLASS:
        //            Instantiate(glassPrefab, glassPos);
        //            break;

        //        case ToolsType.CUP:
        //            Instantiate(cupPrefab, cupPos);
        //            break;

        //        default:
        //            throw new System.Exception("respawn Error");
        //    }
        //}
    }
}
