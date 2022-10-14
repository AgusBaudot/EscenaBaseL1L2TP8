using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Salida : MonoBehaviour
{
    Dialogue dialogue;
    public Text salida;
    public Text ending;
    [SerializeField] bool isClose = false;
    SceneManagerScript sceneManager;
    ApagarDispositivo apagarDispositivo;
    public AudioSource source;
    public AudioClip gameWon;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = dialogue = GameObject.Find("NPC").GetComponent<Dialogue>();
        salida.enabled = false;
        sceneManager = GameObject.Find("[Scene Manager]").GetComponent<SceneManagerScript>();
        sceneManager.blackOut.canvasRenderer.SetAlpha(0);
        apagarDispositivo = GameObject.Find("PuertaCajaElectrica.001").GetComponent<ApagarDispositivo>();
        ending.canvasRenderer.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isClose && dialogue.hasKey)
        {
            gameObject.SetActive(false);
            salida.enabled = false;
            ending.text = "YOU WON..." + Environment.NewLine + "Congratulations!";
            ending.enabled = true;
            sceneManager.blackOut.CrossFadeAlpha(1, 3, false);
            dialogue.timeLeft.CrossFadeAlpha(0, 3, false);
            apagarDispositivo.objetosEncontrados.CrossFadeAlpha(0, 3, false);
            ending.CrossFadeAlpha(1, 10, false);
            source.PlayOneShot(gameWon);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isClose = true;
            if (dialogue.hasKey && isClose)
            {
                salida.text = "Presiona F para salir.";
                salida.enabled = true;
            
            }
            if (!dialogue.hasKey && isClose)
            {
                salida.text = "Debes conseguir la llave primero.";
                salida.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isClose = false;
            salida.enabled = false;
        }
    }
}
