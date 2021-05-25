using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public enum State
    {
        Walk,
        Stop
    }
    public State state;

    [SerializeField]
    private float speed = 10;

    public Transform targetPos1; // ù ��° targetPos
    public Transform targetPos2;
    private NavMeshAgent nvAgent;
    public GameObject panel;

    Animator anim; // �ִϸ��̼� ����
    Rigidbody myRid;

    void Start()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        myRid = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        // target1���� �÷��̾� �̵�
        if(targetPos1 != null)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos1.transform.position, 1f);
        }
        if(targetPos2 != null)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            // transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPos2.transform.position, 1f);
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FirstPos")
        {
            // Player �ִϸ��̼� ���߱�
            anim.SetBool("isStop", true);
            // �������� 90�� ȸ��
            transform.Rotate(0, -90, 0);
            // ���¸� Stop���� �ٲ�
            state = State.Stop;

            Panel();
            Destroy(other.gameObject);

            Invoke("Wait3Sec", 6f);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "SecPos")
        {
            // Player �ִϸ��̼� ���߱�
            anim.SetBool("isStop", true);
            // ���¸� Stop���� �ٲ�
            state = State.Stop;
        }
    }


    public void Panel()
    {
        panel.SetActive(true);
    }

    void Wait3Sec()
    {
        // Player �ִϸ��̼� ���߱�
        anim.SetBool("isStop", false);
        // �������� 90�� ȸ��
        transform.Rotate(0, 90, 0);
        // ���¸� Stop���� �ٲ�
        state = State.Walk;       
    }







}
