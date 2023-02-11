using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody meuRigidbody;

    private void Awake()
    {
        meuRigidbody = GetComponent<Rigidbody>();
    }
    public void Movimentar(Vector3 direcao, float velocidade)
    {
        // normalized = normaliza direção pra equivaler a = 1
        // * Time.deltaTime para movimentar por segundo, não baseado nos frames
        meuRigidbody.MovePosition(
            meuRigidbody.position +
            direcao.normalized * velocidade * Time.deltaTime);
    }

    public void Rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        meuRigidbody.MoveRotation(novaRotacao);
    }
}
