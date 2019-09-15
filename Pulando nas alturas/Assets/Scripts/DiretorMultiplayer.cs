using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorMultiplayer : Diretor
{
    private int pontosDesdeAMorte;
    private bool alguemMorto;
    private Player[] jogadores;
    private InterfaceCanvasInativo interfaceCanvasInativo;
    [SerializeField] private int pontosParaReviver;


    protected override void Start()
    {
        base.Start();
        jogadores = FindObjectsOfType<Player>();
        interfaceCanvasInativo = FindObjectOfType<InterfaceCanvasInativo>();
    }

    public void AvisarQueAlguemMorreu(Camera camera)
    {
        if (alguemMorto)
        {
            FinalizarJogo();
            interfaceCanvasInativo.Desativar();

        }
        else
        {
            this.alguemMorto = true;
            this.pontosDesdeAMorte = 0;
            interfaceCanvasInativo.Ativar(camera);
            interfaceCanvasInativo.AtualizarTexto(pontosParaReviver);
        }
    }

    public void ReviverSePrecisar()
    {
        if (this.alguemMorto)
        {
            this.pontosDesdeAMorte++;
            interfaceCanvasInativo.AtualizarTexto(pontosParaReviver - pontosDesdeAMorte);
            if (this.pontosDesdeAMorte >= pontosParaReviver)
            {
                interfaceCanvasInativo.Desativar();
                this.ReviverJogadores();
            }
        }
    }

    private void ReviverJogadores()
    {
        this.alguemMorto = false;
        foreach (var jogador in this.jogadores)
        {
            jogador.Ativar();
        }
    }

    public override void ReiniciarJogo()
    {
        base.ReiniciarJogo();
        ReviverJogadores();
    }
}
