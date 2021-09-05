using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OrderDetection : MonoBehaviour
{
    public string nametag;

    public float fadeSpeed;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        StartCoroutine(FadeOut());
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int scoreVal = Random.Range(1, 10);
        // jika terkena nametag yang sesuai maka....
        if (collision.tag.Equals(nametag))
        {
            Debug.Log("Order Received");
            GameManager.playerScore += scoreVal;
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

    IEnumerator FadeOut()
    {
       while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
    }
}
