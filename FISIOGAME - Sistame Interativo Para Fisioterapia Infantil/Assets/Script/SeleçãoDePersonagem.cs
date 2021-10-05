using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleçãoDePersonagem : MonoBehaviour
{
    public GameObject[] personagens;
    private void Awake()
    {
        Instantiate(personagens[PlayerPrefs.GetInt("personagemSelecionado")],transform.position,Quaternion.identity);
    }
}
