using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
    }
       public void ChamaMenu(){
     UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    } 

}
