using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    float currentTime;
    float makeTime;
    float makeTime2;
    float makeTime3;
    float time;
    void Start()
    {
        currentTime = 0f;
        makeTime = 3.0f;
        makeTime2 = 6.0f;
        makeTime3 = 9.0f;
    }

    // Update is called once per frame
    void Update()
    {

        currentTime += Time.deltaTime;
        
        if (currentTime > makeTime && currentTime < makeTime2)
        {
            GameObject.Find("Mans").transform.Find("Man2").gameObject.SetActive(true);

        }
        if (currentTime > makeTime2 && currentTime < makeTime3)
        {
            GameObject.Find("Mans").transform.Find("Man3").gameObject.SetActive(true);
        }
    }

}
