using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Destroy : MonoBehaviour
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
        if (collision.gameObject.tag == "Monster")
        {
            
            Destroy(collision.gameObject);
            GameObject.Find("Training table").transform.Find("SecondMask").gameObject.SetActive(true);
            print("1");
            Destroy(this.gameObject);
            print("2");
            //gameObject.SetActive(false);
        }
        
        
    }
}
