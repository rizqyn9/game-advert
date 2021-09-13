using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Flavour : Draggable
    {
        [Header("Properties")]
        public LayerMask toolLayerMask;
        public GameObject prefabOnTool;
        public enumIgrendients resIgrendients;

        [Header("Debug")]
        public FlavourContainer flavourContainer;
        public Sprite spriteOnTool;
        [SerializeField] Tools tools;
        [SerializeField] SpriteRenderer spriteRenderer;

        public override void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            base.Awake();
        }

        public override void OnMouseDown()
        {
            spriteRenderer.enabled = true;
            base.OnMouseDown();
        }

        public override void OnMouseUp()
        {
            getPlacement();
            spriteRenderer.enabled = false;
            base.OnMouseUp();
        }

        private void getPlacement()
        {
            try
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, toolLayerMask);

                if (hit
                    && hit.collider.CompareTag("Tool")
                    && hit.collider.GetComponent<Tools>().isValidated()
                    )
                {
                    Debug.Log("hahah");
                    getTools(hit.transform.GetComponent<Tools>());
                } else
                {
                    throw new Exception();
                }
            }
            catch
            {
                resetPlacement();
            }
        }

        private void getTools(Tools _tools)
        {
            tools = _tools;
            tools.listIgrendients.Add(resIgrendients);

            GameObject go = Instantiate(prefabOnTool, tools.igrendientsParent);
            SpriteRenderer renderer = go.GetComponent<SpriteRenderer>();
            renderer.sprite = spriteOnTool;
            renderer.enabled = true;
            boxCollider2D.enabled = false;
        }

        private void resetPlacement()
        {
            Debug.Log("rest");
            gameObject.transform.position = lastPosition;
            spriteRenderer.enabled = false;
        }
    }
}
