using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //cek kondisi tools
    public static string cup1 = "empty";
    public static string cup2 = "empty";
    public static string grinder = "empty";
    public static string brewer = "empty";

    //cek kondisi pesanan
    public static string kopiHitam = "onProgress";


    // cek skor
    public static int playerScore = 0;

    public Transform scoreObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreObj.GetComponent<Text>().text = "Score : " + playerScore.ToString();
    }
}
