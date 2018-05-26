using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;
    public float RotationSpeed;
    CharacterController cc;
    private Animator anim;
    protected Vector3 gravidade = Vector3.zero;
    protected Vector3 move = Vector3.zero;
    private bool jump = false;
    public int Chaves;
    Animator animator;


    void Start()
    {
        Chaves = 0;
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Parado");
    }

    void Update()
    {
      
        Vector3 move = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * MoveSpeed;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime, 0));

     
        if (!cc.isGrounded)
        {
            gravidade += Physics.gravity * Time.deltaTime;
        }
        else
        {
            gravidade = Vector3.zero;
            if (jump)
            {
                gravidade.y = 6f;
                jump = false;
            }
        }
        move += gravidade;
        cc.Move(move * Time.deltaTime);
        Anima();

        if (Chaves == 2)
        {
            Destroy(GameObject.FindWithTag("Porta"));

        }

        
    }

    void Anima()
    {
        if (!Input.anyKey)
        {
            anim.SetTrigger("Parado");
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("Pula");
                jump = true;
            }
            else
            {
                anim.SetTrigger("Corre");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "chave")
        {
            Destroy(other.gameObject);

            Chaves = Chaves + 1;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if(collision.gameObject.tag == "platform")
        {
            Destroy(collision.gameObject, 3f);
        }
    }
}
