using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCenaInicial : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
    }
       public void ChamaCenaInicial(){
     UnityEngine.SceneManagement.SceneManager.LoadScene("CenaInicial");
    } 

}
