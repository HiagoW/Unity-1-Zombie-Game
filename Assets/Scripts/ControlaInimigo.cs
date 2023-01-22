using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{

    public GameObject Jogador;
    public float Velocidade = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        
        // 2 = soma dos raios dos colisores do jogador e do inimigo
        if (distancia > 2.5)
        {
            //Direcao do jogador em relacao ao inimigo
            Vector3 direcao = Jogador.transform.position - transform.position;

            Rigidbody rigidbody = GetComponent<Rigidbody>();

            // normalized = normaliza direção pra equivaler a = 1
            rigidbody.MovePosition
                (GetComponent<Rigidbody>().position +
                direcao.normalized * Velocidade * Time.deltaTime);

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            rigidbody.MoveRotation(novaRotacao);
        }
    }
}
