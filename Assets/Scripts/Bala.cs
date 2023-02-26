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
        switch (objectDeColisao.tag) {
            case Tags.Inimigo:
                objectDeColisao.GetComponent<ControlaInimigo>().TomarDano(danoDoTiro);
                break;
            case Tags.ChefeDeFase:
                objectDeColisao.GetComponent<ControlaChefe>().TomarDano(danoDoTiro);
                break;
        }

        Destroy(gameObject);
    }
}
