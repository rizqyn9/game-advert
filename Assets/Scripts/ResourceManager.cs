using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Transform serbukObj;
    public Transform seduhObj;
    public Transform jadiObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameObject.name == "biji")
        {
            if (GameManager.grinder == "empty")
            {
                Instantiate(serbukObj, new Vector2(4.06f, 1), serbukObj.rotation);
                GameManager.grinder = "full";
            }
        }

        if(gameObject.name =="serbuk(Clone)")
        {
            if(GameManager.brewer == "empty")
            {
                Destroy(this.gameObject);
                GameManager.grinder = "empty";
                Instantiate(seduhObj, new Vector2(7.1f , 0.92f), seduhObj.rotation);
                GameManager.brewer = "full";
            }
        }

        if(gameObject.name == "seduh(Clone)")
        {
            if(GameManager.cup1 == "empty")
            {
                Destroy(this.gameObject);
                GameManager.brewer = "empty";
                Instantiate(jadiObj, new Vector2(-0.9f , -2.17f), jadiObj.rotation);
                GameManager.cup1 = "full";
            }
            else if (GameManager.cup2 == "empty")
            {
                Destroy(this.gameObject);
                GameManager.brewer = "empty";
                Instantiate(jadiObj, new Vector2(1.23f , -2.17f), jadiObj.rotation);
                GameManager.cup2= "full";
            }
        }

        //if (gameObject.tag == "KopiHitam")
       // {
         //   if(GameManager.kopiHitam =="onProgress")
          //  {
             //   Destroy(this.gameObject);
             //   if(GameManager.cup1 == "full")
              //  {
              //      GameManager.cup1 = "empty";
              //  }
              //  else if (GameManager.cup2 == "full")
               // {
               //     GameManager.cup2 = "empty";
               // }
           // }
        //}
    }
}
