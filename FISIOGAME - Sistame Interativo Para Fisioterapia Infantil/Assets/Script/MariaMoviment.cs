using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariaMoviment : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool IsJumping;
    public bool IsCrouching;
    public bool invunerable = false;
    
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        Jump();
        Crouch();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal") > 0f){
                anim.SetBool("walking", true);
                transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            //Esquerda
            if(Input.GetAxis("Horizontal") < 0f){
               anim.SetBool("walking", true);
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
            //Parado
            if(Input.GetAxis("Horizontal") == 0f){
                anim.SetBool("walking", false);
            }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!IsJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    anim.SetBool("IsJumping", true);
                }
        }
        else if(Input.GetButtonUp("Jump"))
        {
            anim.SetBool("IsJumping", false);
        }
    }

//Função da animação de agachar
    void Crouch(){
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(!IsCrouching)
                {
                    anim.SetBool("IsCrouching", true);
                }
            }
            else if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                IsCrouching = false;
                anim.SetBool("IsCrouching", false);
            }
    }

}
