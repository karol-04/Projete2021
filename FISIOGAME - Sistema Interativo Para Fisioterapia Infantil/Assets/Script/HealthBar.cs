using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   public Sprite[] bar;
   public Image healthBarUI;
   private Maria player;

    void Start()
    {
       player = GameObject.Find("Maria").GetComponent<Maria> (); //para manipular qualquer coisa dentro de Maria.
    }

//Altera o hud de acordo com a vida
    void Update()
    {
        healthBarUI.sprite = bar [player.health];
    }
}
