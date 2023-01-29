using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    private Vector3 direcao;
    public LayerMask MascaraDoChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;

    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        if(direcao != Vector3.zero)
        {
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            animatorJogador.SetBool("Movendo", false);
        }

        if(!Vivo)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        // * Time.deltaTime para movimentar por segundo, não baseado nos frames
        rigidbodyJogador.MovePosition
            (rigidbodyJogador.position +
            (direcao * Velocidade * Time.deltaTime));
        
        // Raio que parte da camera principal até a posição do ponteiro do mouse
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        // * 100 para ver o raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        // Onde raio toca o chão
        RaycastHit impacto;
        
        // Lança um raio a partir de uma referência "raio" e detecta quando raio impactor em algo,
        // limitando a busca a 100m e apenas a camada do chão
        if(Physics.Raycast(raio, out impacto, 100, MascaraDoChao))
        {
            // posição do impacto referente à posição do jogador
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            // Trava em Y para não mirar pra cima ou para baixo
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            rigidbodyJogador.MoveRotation(novaRotacao);
        }
    }
}
