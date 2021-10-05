using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maria : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool IsJumping;
    public bool IsCrouching;
    public int health;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        
            if((collision.gameObject.layer == 8)||(collision.gameObject.layer == 9))
            {
                IsJumping = false;
                anim.SetBool("IsJumping", false);
            }
        
    }
    
    //Verifica se ja esta pulando
    void OnCollisionExit2D(Collision2D collision)
    {

            if((collision.gameObject.layer == 8)||(collision.gameObject.layer == 9))
            {
                IsJumping = true;
                anim.SetBool("IsJumping", true);
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

    IEnumerator Damage(){
        Debug.Log("entrou pisca");

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
        Debug.Log("entrou função");
        invunerable = true;
        if(health>0){

            health--; 

        }   
        StartCoroutine (Damage());

        if (health < 1){
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("Perdeu");
        }
    }
   
   //Adiciona vida 
    public void LifePlayer(int num)
    {
        if(health<4)
        {
            health += num;
        }
    }
    
    private void OnCollisonEnter2D(Collider2D collider){
        
        if((collider.gameObject.layer == 10)&&(health > 0)){
            
                UnityEngine.SceneManagement.SceneManager.LoadScene("Ganhou");
            
    
        }
    }
}
