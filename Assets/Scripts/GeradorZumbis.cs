using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{

    public GameObject Zumbi;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZumbi;
    private float distanciaDeGeracao = 3;
    private float DistanciaDoJogadorParaGeracao = 20;
    private GameObject jogador;

    private void Start()
    {
        jogador = GameObject.FindWithTag(Tags.Jogador);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, jogador.transform.position) > DistanciaDoJogadorParaGeracao)
        {
            contadorTempo += Time.deltaTime;

            if (contadorTempo >= TempoGerarZumbi)
            {
                StartCoroutine(GerarNovoZumbi());
                contadorTempo = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Desenha na scene o gerador de zumbis com o raio
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaDeGeracao);
    }

    IEnumerator GerarNovoZumbi()
    {
        Vector3 posicaoDeCriacao = AleatorizarPosicao();
        // detecta colisores que estejam dentro em uma esfera de raio 1
        // LayerZumbi para detectar apenas colisão de zumbis e excluir o chão, pois o zumbi deve colidir com o chão
        Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);

        while (colisores.Length > 0)
        {
            posicaoDeCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);
            // Não vai travar o frame. Se não conseguir gerar o zumbi, aguarda próximo frame
            yield return null;
        }

        Instantiate(Zumbi, posicaoDeCriacao , transform.rotation);
    }

    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * distanciaDeGeracao;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }
}
