using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorestaPEscolha : MonoBehaviour
{
    private Maria player;

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void ChamaCenaEscolhaFloresta()
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("CenaEscolhaFloresta");
    } 
}