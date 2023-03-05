using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorChefe : MonoBehaviour
{
    private float tempoParaAProximaGeracao = 0;
    public float tempoEntreGeracoes = 60;
    public GameObject ChefePrefab;
    private ControlaInterface scriptControlaInterface;
    public Transform[] PosicoesPossiveisDeGeracao;
    private Transform jogador;

    void Start()
    {
        tempoParaAProximaGeracao = tempoEntreGeracoes;
        scriptControlaInterface = GameObject.FindObjectOfType(typeof(ControlaInterface)) as ControlaInterface;
        jogador = GameObject.FindWithTag(Tags.Jogador).transform;
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > tempoParaAProximaGeracao)
        {
            Vector3 posicaoDeCriacao = CalcularPosicaoMaisDistanteDoJogador();
            Instantiate(ChefePrefab, posicaoDeCriacao, Quaternion.identity);
            scriptControlaInterface.AparecerTextoChefeCriado();
            tempoParaAProximaGeracao = Time.timeSinceLevelLoad + tempoEntreGeracoes;
        }
    }

    Vector3 CalcularPosicaoMaisDistanteDoJogador()
    {
        Vector3 posicaoDeMaiorDistancia = Vector3.zero;
        float maiorDistancia = 0;

        foreach (Transform posicao in PosicoesPossiveisDeGeracao)
        {
            float distanciaEntreOJogador = Vector3.Distance(posicao.position, jogador.position);
            if (distanciaEntreOJogador > maiorDistancia)
            {
                maiorDistancia = distanciaEntreOJogador;
                posicaoDeMaiorDistancia = posicao.position;
            }
        }

        return posicaoDeMaiorDistancia;
    }
}
