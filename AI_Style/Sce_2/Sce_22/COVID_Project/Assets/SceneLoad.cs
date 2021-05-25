using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loadlevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Loadlevel()
    {
        Debug.Log("Invoke3");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Scene2");
        Debug.Log("Invoke4");
    }
}
