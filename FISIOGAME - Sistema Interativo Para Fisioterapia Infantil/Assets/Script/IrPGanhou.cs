using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IrPGanhou : MonoBehaviour
{
    private Maria player;
    
    void Start()
    {
        player = GameObject.Find("Maria").GetComponent<Maria>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
		
    	//Se o jogador encostar no item chama a função dentro do script maria
    	if(collider.gameObject.layer == 6)
        {
            player.VoceGanhou();
        }
    }
			
}