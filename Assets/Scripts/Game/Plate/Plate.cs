using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Plate : MonoBehaviour
    {
        [Header("Properties")]
        public Transform toolPlace;

        [Header("Debug")]
        [SerializeField] Tools tools;
        [SerializeField] BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public bool isValidatedPlate(Tools _tools)
        {
            if (toolPlace.childCount > 0) return false;
            tools = _tools;
            return true;
        }

        public void onInput(Tools _tools)
        {
            tools = _tools;
            tools.transformTool(toolPlace.transform);
            boxCollider2D.enabled = false;
        }

        public void onOut()
        {
            boxCollider2D.enabled = true;
        }
    }
}
