using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrPJogoCidade : MonoBehaviour
{

    void Start()
    {   
    }

    void Update()
    {
    }
      
    public void ChamaCidade()
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("Cidade");
    } 

    public void PlayerLucas()
    {
      PlayerPrefs.SetInt("personagemSelecionado", 3);
      PlayerPrefs.Save();
    }

    public void PlayerPedro()
    {
      PlayerPrefs.SetInt("personagemSelecionado", 2);
      PlayerPrefs.Save();
    }

    public void PlayerAna()
    {
      PlayerPrefs.SetInt("personagemSelecionado", 1);
      PlayerPrefs.Save();
    }

    public void PlayerMaria()
    {
      PlayerPrefs.SetInt("personagemSelecionado", 0);
      PlayerPrefs.Save();
    }

}
