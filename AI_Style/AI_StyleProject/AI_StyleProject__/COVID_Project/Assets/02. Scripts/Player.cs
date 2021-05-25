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

    public Transform targetPos1; // 첫 번째 targetPos
    public Transform targetPos2;
    private NavMeshAgent nvAgent;
    public GameObject panel;

    Animator anim; // 애니메이션 조절
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
        // target1으로 플레이어 이동
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
            // Player 애니메이션 멈추기
            anim.SetBool("isStop", true);
            // 왼쪽으로 90도 회전
            transform.Rotate(0, -90, 0);
            // 상태를 Stop으로 바꿈
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
            // Player 애니메이션 멈추기
            anim.SetBool("isStop", true);
            // 상태를 Stop으로 바꿈
            state = State.Stop;
        }
    }


    public void Panel()
    {
        panel.SetActive(true);
    }

    void Wait3Sec()
    {
        // Player 애니메이션 멈추기
        anim.SetBool("isStop", false);
        // 왼쪽으로 90도 회전
        transform.Rotate(0, 90, 0);
        // 상태를 Stop으로 바꿈
        state = State.Walk;       
    }







}
