using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour
{
    private float tempoParaAProximaGeracao = 0;
    public float tempoEntreGeracoes = 60;
    public GameObject ChefePrefab;

    void Start()
    {
        tempoParaAProximaGeracao = tempoEntreGeracoes;    
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > tempoParaAProximaGeracao)
        {
            Instantiate(ChefePrefab, transform.position, Quaternion.identity);
            tempoParaAProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
        }
    }
}
