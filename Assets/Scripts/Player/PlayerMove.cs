using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    float InitialMoveSpd;


    private float moveSpeed;

    Animator bodyAni;

    void Start()
    {
        moveSpeed = InitialMoveSpd;

        bodyAni = GetComponent<Animator>();
    }
    void Move(float x, float y)
    {
        rb.velocity = new Vector2(x, y).normalized * moveSpeed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Move(x, y);

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            bodyAni.Play("bLeft");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            bodyAni.Play("bRight");
        }

        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            bodyAni.Play("bVert");
        }

        else
        {
            bodyAni.Play("Empty");
        }
    }
}