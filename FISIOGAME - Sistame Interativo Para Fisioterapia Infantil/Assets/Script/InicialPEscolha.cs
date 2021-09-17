using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicialPEscolha : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
    }
       public void ChamaCenaEscolha(){
     UnityEngine.SceneManagement.SceneManager.LoadScene("CenaEscolha");
    } 

}

