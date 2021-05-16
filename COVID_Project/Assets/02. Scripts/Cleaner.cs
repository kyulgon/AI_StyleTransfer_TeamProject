using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cleaner : MonoBehaviour
{
    public GameObject particle;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(particle, transform.position, transform.rotation);
            audio.Play();
        }

        Invoke("NextScene", 3f);
        
    }

    void NextScene()
    {
        SceneManager.LoadScene("Scene3");
    }
}
