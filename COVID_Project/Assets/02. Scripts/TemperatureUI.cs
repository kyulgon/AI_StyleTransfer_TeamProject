using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemperatureUI : MonoBehaviour
{
    public GameObject showTemperature; // ü�� �����ִ� UI ������Ʈ
    public Text temperatureTxt; // �µ��ؽ�Ʈ ����
    public Button NextBtn; // ���� ��ư

    private float temperature; // �µ� ��
    private bool ShowTemp; // UI�����ִ� ����

    void Start()
    {
        temperature = 0; // �µ� �ʱ�ȭ
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

        temperatureTxt.text = System.Math.Round((float)temperature, 1) + " �� �Դϴ�";

        Invoke("Wait3Sec", 3f);

    }      

    void Wait3Sec()
    {
        showTemperature.SetActive(false);
    }

}
