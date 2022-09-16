using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneManager : MonoBehaviour
{
    Dialogue dialogue;
    CounterManager counterManager;
    public Image blackOut;
    public Text ending;
    GameObject player;
    ApagarDispositivo apagarDispositivo;
    public bool disappearText = false;

    // Start is called before the first frame update
    void Start()
    {
        counterManager = GameObject.Find("[Counter Manager]").GetComponent<CounterManager>();
        dialogue = GameObject.Find("NPC").GetComponent<Dialogue>();
        player = GameObject.Find("NPC");
        blackOut.canvasRenderer.SetAlpha(0);
        ending.enabled = false;
        apagarDispositivo = GameObject.Find("PuertaCajaElectrica.001").GetComponent<ApagarDispositivo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.lose)
        {
            player.GetComponent<MeshRenderer>().enabled = false;
            if (dialogue.isGone && Input.GetKeyDown(KeyCode.E))
            {
                disappearText = true;
                blackOut.canvasRenderer.SetAlpha(1);
                Debug.Log("Lost");
                ending.text = "Escuchas a los chicos jugar afuera..." + Environment.NewLine + "Sabes que nunca vas a poder salir..." + Environment.NewLine + "Te quedaste encerrado en TIC para siempre..." + Environment.NewLine + "Nunca fuiste encontrado...";
                ending.enabled = true;
                dialogue.source.PlayOneShot(dialogue.gameOver);
                dialogue.text.enabled = false;
                dialogue.timeLeft.enabled = false;
                apagarDispositivo.objetosEncontrados.enabled = false;
            }
        }
    }
}
