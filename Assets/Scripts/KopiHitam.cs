using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KopiHitam : MonoBehaviour
{
    [SerializeField]
    private Transform test;

    private Vector2 initialPos;
    private Vector2 mousePos;

    private float deltaX, deltaY;

    public static bool locked;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
            deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;       
    }

    private void OnMouseDrag()
    {             
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);      
    }

    private void OnMouseUp()
    {
            transform.position = new Vector2(initialPos.x, initialPos.y);  
    }
}
