using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Trash : Singleton<Trash>
    {
        /// <summary>
        /// Trigger when Tools / Igrendients drop on Trash
        /// </summary>
        /// <param name="toolsType"></param>
        public void onTrash(ToolsType toolsType) {
            //Desk.Instance.respawnTools(toolsType);
            Debug.Log("trashh");
        }
    }
}
