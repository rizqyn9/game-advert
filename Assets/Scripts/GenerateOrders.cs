using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOrders : MonoBehaviour
{
    public int ordersToGenerate;
    public int ordersQuantity;

    public GameObject blackCoffee;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        while (ordersQuantity < 10)
        {
            ordersToGenerate = Random.Range(1, 1);
            int xPos = Random.Range(-7, 7);
            int yPos = 3;
            if (ordersToGenerate == 1)
            {
                Instantiate(blackCoffee, new Vector2(xPos, yPos), Quaternion.identity);
            }
            yield return new WaitForSeconds(5f);
            ordersQuantity += 1;
        }
    }
}
