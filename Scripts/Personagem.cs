using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Personagem : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;

    public float Speed;
    public float JumpForce;
    public bool IsJumping;
    //public bool DoubleJump;

    public int health;
    public bool invunerable = false;


    // Start is called before the first frame update
    void Start()
    {
        try{
            rig = GetComponent<Rigidbody2D>(); 
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
        }
        catch(Exception e){
            Debug.Log("Erro: "+ e);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

//Controle movimento andar
    void Move()
    {
        try{
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;
            //Direita
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
        catch(Exception e){
            Debug.Log("Erro: "+ e);

        }
    }
    //Controle pulo
    void Jump()
    {
        try{
            if(Input.GetButtonDown("Jump"))
            {
                if(!IsJumping)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                }
                /*else
                {                
                    if(DoubleJump == true)
                    {
                        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                        DoubleJump = false;
                    }
                }*/
            }
        }
        catch(Exception e){
            Debug.Log("Erro: "+ e);

        }
    }
//Se caiu no chao
    void OnCollisionEnter2D(Collision2D collision)
    {
        try{
            if((collision.gameObject.layer == 8)||(collision.gameObject.layer == 9))
            {
                IsJumping = false;
                //DoubleJump = true;
                anim.SetBool("jump", false);
            }
        }
        catch(Exception e){
            Debug.Log("Erro: "+ e);

        }
    }
//Verifica se ja esta pulando
    void OnCollisionExit2D(Collision2D collision)
    {
        try{
            if((collision.gameObject.layer == 8)||(collision.gameObject.layer == 9))
            {
                IsJumping = true;
                anim.SetBool("jump", true);
            }
        }
        catch(Exception e){
            Debug.Log("Erro: "+ e);

        }
    }

    //Funcao dano

    IEnumerator Damage(){
    

        for (float i = 0f; i < 1f; i += 0.1f) {
            sprite.enabled = false;
            yield return new WaitForSeconds (0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds (0.1f);

        }

        invunerable = false;
    }

//Recebe dano
    public void DamagePlayer(){

        invunerable = true;
        health--;
        StartCoroutine (Damage());

        /*if (health < 1){
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game_Over");
        }*/
    }
   //Adiciona vida 
   /* public void LifePlayer(int num)
    {
        if(health<6)
        {
            health += num;
        }
    }*/
}