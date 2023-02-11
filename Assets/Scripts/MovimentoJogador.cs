using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoJogador : MovimentoPersonagem
{
    public void RotacaoJogador(LayerMask MascaraDoChao)
    {
        // Raio que parte da camera principal até a posição do ponteiro do mouse
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        // * 100 para ver o raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        // Onde raio toca o chão
        RaycastHit impacto;

        // Lança um raio a partir de uma referência "raio" e detecta quando raio impactor em algo,
        // limitando a busca a 100m e apenas a camada do chão
        if (Physics.Raycast(raio, out impacto, 100, MascaraDoChao))
        {
            // posição do impacto referente à posição do jogador
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            // Trava em Y para não mirar pra cima ou para baixo
            posicaoMiraJogador.y = transform.position.y;

            Rotacionar(posicaoMiraJogador);
        }
    }
}
