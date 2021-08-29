using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour
{
    public GameObject LevelSelect;
    // Start is called before the first frame update
    void Start()
    {
        LevelSelect.SetActive(false);
        StartCoroutine(TransitionIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TransitionIn()
    {

        yield return new WaitForSeconds(1);

        LevelSelect.SetActive(true);
    }
}
