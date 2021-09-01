using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDetection : MonoBehaviour
{
    public string nametag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(nametag))
        {
            Debug.Log("Order Received");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            if (GameManager.cup1 == "full")
            {
                GameManager.cup1 = "empty";
            }
            else if (GameManager.cup2 == "full")
            {
                GameManager.cup2 = "empty";
            } 
        }
    }
}
