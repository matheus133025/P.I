using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string NomeDoLevelDeJogo;
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject PainelOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene(NomeDoLevelDeJogo);
    }
    public void AbrirOp��es()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void FecharOp��es()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");

    }
}
