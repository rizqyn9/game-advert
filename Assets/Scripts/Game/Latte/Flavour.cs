using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Flavour : MonoBehaviour
    {
        [Header("Properties")]
        public LayerMask toolLayerMask;

        [Header("Debug")]
        public FlavourContainer flavourContainer;
        public bool isDragged;
        [SerializeField] Vector2 lastPosition;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] BoxCollider2D boxCollider2D;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();
            lastPosition = transform.position;
        }

        private void OnMouseDown()
        {
            isDragged = true;
            spriteRenderer.enabled = true;
        }

        private void OnMouseDrag()
        {
            if (isDragged)
            {
                // create object follow pointer and set middle object from pointer
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePos);
            }
        }

        private void OnMouseUp()
        {
            getPlacement();
            isDragged = false;
        }

        private void getPlacement()
        {
            try
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, 2f, toolLayerMask);

                if ( hit
                    && hit.collider.CompareTag("Tool")
                    )
                {
                    Debug.Log("hahah");

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

        private void resetPlacement()
        {
            transform.position = lastPosition;
        }
    }
}
