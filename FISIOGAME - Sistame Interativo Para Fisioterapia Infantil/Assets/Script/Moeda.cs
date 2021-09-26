using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moeda : MonoBehaviour
{

	private SpriteRenderer spriteRenderer;
	private PolygonCollider2D polygonCollider2D;
	private Maria player;

    // Start is called before the first frame update
    void Start()
    {
    	spriteRenderer = GetComponent<SpriteRenderer>();
    	polygonCollider2D = GetComponent<PolygonCollider2D>();
		player = GameObject.Find("Maria").GetComponent<Maria>();
    }

    private void OnTriggerEnter2D(Collider2D collider){
		
    	//Se o jogador encostar no item
    	if(collider.gameObject.layer == 6){
			
    		//desabilita o render e a colisão do objeto
    		spriteRenderer.enabled = false;
    		polygonCollider2D.enabled = false;

    		//destroi o item após 300ms
    		Destroy(gameObject, 0.3f);

    	}
    }
}

