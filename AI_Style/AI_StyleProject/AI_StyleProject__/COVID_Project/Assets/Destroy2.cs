using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destroy2 : MonoBehaviour
{
    private Animator animator;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster2")
        {
            Destroy(collision.gameObject);
            print("A");
            GameObject.Find("Training table").transform.GetChild(0).gameObject.SetActive(true);
            //GameObject.Find("Training table").transform.Find("ThirdMask").gameObject.SetActive(true);
            print("B");

            Destroy(this.gameObject);
        }
    }
}
