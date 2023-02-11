using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    public void RotacaoJogador(LayerMask MascaraDoChao)
    {
        // Raio que parte da camera principal at� a posi��o do ponteiro do mouse
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        // * 100 para ver o raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        // Onde raio toca o ch�o
        RaycastHit impacto;

        // Lan�a um raio a partir de uma refer�ncia "raio" e detecta quando raio impactor em algo,
        // limitando a busca a 100m e apenas a camada do ch�o
        if (Physics.Raycast(raio, out impacto, 100, MascaraDoChao))
        {
            // posi��o do impacto referente � posi��o do jogador
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            // Trava em Y para n�o mirar pra cima ou para baixo
            posicaoMiraJogador.y = transform.position.y;

            Rotacionar(posicaoMiraJogador);
        }
    }
}
