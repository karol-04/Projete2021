using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maria : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool IsJumping;
    public bool IsCrouching;
    public int health;
    public bool invunerable = false;
    public GameObject PanelPause;

    
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;
    private bool isPaused= false;
    private Menu menu;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if(!isPaused)
        {
            Move();
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
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
                    anim.SetBool("IsJumping", true); //ativa o parametro de condição para a animação
                }
        }
        else if(Input.GetButtonUp("Jump"))
        {
            anim.SetBool("IsJumping", false); //desativa o parametro de condição para a animação
        }
    }

    //Verifica se não está pulando
    void OnCollisionEnter2D(Collision2D collision)
    {
        
            if((collision.gameObject.layer == 8)||(collision.gameObject.layer == 9))
            {
                IsJumping = false;
                anim.SetBool("IsJumping", false);
            }
        
    }
    
    //Verifica se ja está pulando
    void OnCollisionExit2D(Collision2D collision)
    {

            if((collision.gameObject.layer == 8)||(collision.gameObject.layer == 9))
            {
                IsJumping = true;
                anim.SetBool("IsJumping", true);
            }
    
    }

    //Ativa o painel de pause se for chamada e não estiver pausada
    void PauseScreen()
    {
        if(isPaused)
        {
            isPaused= false;
            PanelPause.SetActive(false);
        }
        else
        {
            isPaused= true;
            PanelPause.SetActive(true);
        }
    }

    //ativa e desativa o sprite renderer fazendo o personagem piscar
    IEnumerator Damage()
    {
        for (float i = 0f; i < 1f; i += 0.1f) {
            sprite.enabled = false;
            yield return new WaitForSeconds (0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds (0.1f);

        }

        invunerable = false;
    }

    //Recebe dano quando a vida é maior que zero e chama a cena perdeu quando acaba as vidas
    public void DamagePlayer()
    {
        invunerable = true;
        if(health>0){

            health--; 

        }   
        StartCoroutine (Damage());

        if (health < 1){
            
            UnityEngine.SceneManagement.SceneManager.LoadScene("Perdeu");
        }
    }
   
    //Adiciona vida quando a vida é menor que três
    public void LifePlayer()
    {
        if(health<3)
        {
            health += 1;

        }
    }
    
    //Chama a cena ganhou quando a vida é maior que zero
    public void VoceGanhou()
    {  
        if(health > 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Ganhou");
        }
    }
    
    //chama a programação do menu principal
    public void BackToMenu()
    {
        menu.ChamaMenu();
    }
    
}
