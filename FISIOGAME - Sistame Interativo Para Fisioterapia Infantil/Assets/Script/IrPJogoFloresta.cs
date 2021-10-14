using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrPJogoFloresta : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
    }
    
    public void ChamaFloresta()
    {
     UnityEngine.SceneManagement.SceneManager.LoadScene("Floresta");
    } 
    
    /*public void PlayerCervo()
    {
      PlayerPrefs.SetInt("personagemSelecionado", 0);
      PlayerPrefs.Save();
    }

    public void PlayerCoelho()
    {
      PlayerPrefs.SetInt("personagemSelecionado", 1);
      PlayerPrefs.Save();
    }*/

}
