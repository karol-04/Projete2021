using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//criar um game object com o nome do script
//selecionar essa função no on click do botao com cada um tendo um botao
//criar um game object para uma posição fixa e colocar o script de baixo nele
/* Em outro script
public GameObject[] personagens;
private void Awake()
{
    Instantiate(personagens[PlayerPrefs.GetInt("personagemSelecionado")],transform.position, Quaternion.identity);
}*/
public class nomeDoScript: MonoBehaviour
{
    public Text[] button_txt;
    public int[] preço;

    private int scoreGame; //moeda

    private void Start()
    {
        if(PlayerPrefs.GetInt("0")==0)
        {
            PlayerPrefs.SetInt("0", 1);
        }
        scoreGame= PlayerPrefs.GetInt("totalScore");
    }

    private void Update()
    {
        for(int i=0; i<button_txt.Length;i++)
        {
            button_txt[i].text= "selecionar";
        }
    }

public void selectChar(int numButtton)
{
    if(PlayerPrefs.GetInt(numButtton.ToString())==0)
    {
        //desbloqueia
    }
    else
    {
        //seleciona
        PlayerPrefs.SetInt("personagemSelecionado", numButtton);
        PlayerPrefs.Save();
    }
}
}