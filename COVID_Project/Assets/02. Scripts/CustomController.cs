using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CustomController : MonoBehaviour
{
    public InputDeviceCharacteristics characteristics;

    [SerializeField]
    private List<GameObject> controllerModels;
    private GameObject controllerInstance;
    private InputDevice availableDevice;

    public bool renderController; // Hand�� Controller ���̸� ������ ����
    public GameObject handModel; // �ڵ� �� (������)
    private GameObject handInstance; // �ڵ� �ν��Ͻ�

    private Animator handModelAnimator; // �ڵ� �� �ִϸ��̼� ����

    void Start()
    {
        TryInitialize();
    }

    void Update()
    {
        if(!availableDevice.isValid)
        {
            TryInitialize();
            return;
        }

        if(renderController)
        {
            handInstance.SetActive(false);
            controllerInstance.SetActive(true);
        }
        else
        {
            handInstance.SetActive(true);
            controllerInstance.SetActive(false);
            UpdateHandAnimation(); // �ڵ� �ִϸ��̼��� ���⼭�� ����
        }
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        // ���� ����Ʈ ����̽��� XR ��Ŷ���� ��ŧ���� ��ġ (������)���� �ν��� �ϰ� ����
        foreach (var device in devices)
        {
            Debug.Log($"������ ����̽� �̸�: {device.name}, Ư¡: {device.characteristics}");
            Debug.Log(devices.Count);
        }
        if (devices.Count > 0)
        {
            availableDevice = devices[0];
            string name = "";
            if ("Oculus Touch Controller - Left" == availableDevice.name)
            {
                name = "Oculus Quest Controller - Left";
            }
            else if ("Oculus Touch Controller - Right" == availableDevice.name)
            {
                name = "Oculus Quest Controller - Right";
            }
            GameObject currentControllerModel = controllerModels.Find(controller => controller.name == name);
            if (currentControllerModel)
            {
                controllerInstance = Instantiate(currentControllerModel, transform);
            }
            else
            {
                Debug.LogError("������ ����̽��� �����ϴ�!");
                controllerInstance = Instantiate(controllerModels[0], transform);
            }
        }

        handInstance = Instantiate(handModel, transform); // �ڵ� �ν��Ͻ� �߰�
        handModelAnimator = handInstance.GetComponent<Animator>();
    }
    void UpdateHandAnimation()
    {
        if (availableDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handModelAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handModelAnimator.SetFloat("Trigger", 0);
        }

        if(availableDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handModelAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handModelAnimator.SetFloat("Grip", 0);
        }
    }
}
