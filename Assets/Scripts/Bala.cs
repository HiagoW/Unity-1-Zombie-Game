using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    public float Velocidade = 20;
    private Rigidbody rigidbodyBala;
    public AudioClip SomDeMorte;
    private int danoDoTiro = 1;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbodyBala.MovePosition
            (rigidbodyBala.position + 
            transform.forward * Velocidade * Time.deltaTime);
    }

    // Chamado quando bala colidir com outro objeto
    void OnTriggerEnter(Collider objectDeColisao)
    {
        Quaternion rotacaoOpostaABala = Quaternion.LookRotation(-transform.forward);
        switch (objectDeColisao.tag) {
            case Tags.Inimigo:
                ControlaInimigo inimigo = objectDeColisao.GetComponent<ControlaInimigo>();
                inimigo.TomarDano(danoDoTiro);
                inimigo.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;
            case Tags.ChefeDeFase:
                ControlaChefe chefe = objectDeColisao.GetComponent<ControlaChefe>();
                chefe.TomarDano(danoDoTiro);
                chefe.ParticulaSangue(transform.position, rotacaoOpostaABala);
                break;
        }

        Destroy(gameObject);
    }
}
