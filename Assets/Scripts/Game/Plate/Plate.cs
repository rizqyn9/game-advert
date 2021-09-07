using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Plate : MonoBehaviour
    {
        [Header("Debug")]
        [SerializeField] Tools tools;
        [SerializeField] BoxCollider2D boxCollider2D;

        private void Awake()
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public bool isValidated()
        {
            return true;
        }

        public void onInput(Tools _tools)
        {
            tools = _tools;
            tools.transformTool(gameObject.transform);
            boxCollider2D.enabled = false;
        }

        public void onOut()
        {

        }
    }
}
