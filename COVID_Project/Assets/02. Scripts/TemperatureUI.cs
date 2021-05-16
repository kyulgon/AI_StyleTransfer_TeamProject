using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemperatureUI : MonoBehaviour
{
    public GameObject showTemperature; // 체온 보여주는 UI 오브젝트
    public Text temperatureTxt; // 온도텍스트 변수
    public Button NextBtn; // 다음 버튼

    private float temperature; // 온도 값
    private bool ShowTemp; // UI보여주는 상태

    void Start()
    {
        temperature = 0; // 온도 초기화
        ShowTemp = false;

        ShowTemperatureUI();



    }

    void Update()
    {

       
       
    }


    void ShowTemperatureUI()
    {
        ShowTemp = true;
        showTemperature.SetActive(true);

        temperature = Random.Range((float)36.4, (float)36.9);

        temperatureTxt.text = System.Math.Round((float)temperature, 1) + " ℃ 입니다";

        Invoke("Wait3Sec", 3f);

    }      

    void Wait3Sec()
    {
        showTemperature.SetActive(false);
    }

}
