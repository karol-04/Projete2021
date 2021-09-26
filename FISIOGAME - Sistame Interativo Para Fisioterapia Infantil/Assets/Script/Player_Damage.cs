using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Damage : MonoBehaviour
{
    private Maria player;
    
    void Awake() {

        player = GameObject.Find("Maria").GetComponent<Maria>();

    }

//Verifica colisao objetos dano
    void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag ("Lixeira")){//Objetos que dao dano

            if (player.invunerable == false){

                player.DamagePlayer();

            }

        }        
    }
}