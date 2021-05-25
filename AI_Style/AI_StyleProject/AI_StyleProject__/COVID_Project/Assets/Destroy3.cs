using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroy3 : MonoBehaviour
{
    public GameObject desk;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster3")
        {
            
            Destroy(collision.gameObject);
            GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
            Destroy(desk);
            Destroy(this.gameObject);
        }
        
    }
    
    //IEnumerator NextScene()
    //{
    //    Debug.Log("Invoke3");
    //    yield return new WaitForSeconds(3f);
    //    Debug.Log("Invoke4");
    //    SceneManager.LoadScene("Scene2");
    //    Debug.Log("Invoke5");
    //}
    //public void NextScene()
    //{
    //    Debug.Log("Invoke3");
    //    SceneManager.LoadScene("Scene2");
    //    Debug.Log("Invoke4");
    //}
}









