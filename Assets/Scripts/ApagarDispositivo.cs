using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApagarDispositivo : MonoBehaviour
{
    public Text text;
    #region Lights
    [SerializeField] GameObject[] GreenLights;
    [SerializeField] GameObject[] RedLights;
    BoxCollider colliderLights;
    #endregion
    #region Speakers
    MeshRenderer mesh;
    BoxCollider colliderSpeakers;
    #endregion
    #region Gabinete
    BoxCollider colliderCabinet;
    #endregion
    Dialogue dialogue;
    GameObject NPC;
    public Text objetosEncontrados;
    [SerializeField] int counter = 0;
    [SerializeField] bool isInside = false;
    CounterManager counterManager;
    SceneManager sceneManager;
    public AudioClip song;
    public AudioSource source;

// Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Gabinete")
        {
            //lo que quiero cambiar del gabinete
        }
        if (gameObject.name == "PuertaCajaElectrica.001")
        {
            mesh = gameObject.GetComponent<MeshRenderer>();
            source.PlayOneShot(song);
        }
        if (gameObject.name == "Impresora")
        {
            GreenLights = GameObject.FindGameObjectsWithTag("Green Lights");
            RedLights = GameObject.FindGameObjectsWithTag("Red Lights");
            for (int i = 0; i<RedLights.Length; i++)
            {
                RedLights[i].GetComponent<Light>().enabled = false;
            }
        }
        NPC = GameObject.Find("NPC");
        dialogue = NPC.GetComponent<Dialogue>();
        counterManager = GameObject.Find("[Counter Manager]").GetComponent<CounterManager>();
        text.enabled = false;
        objetosEncontrados.enabled = false;
        sceneManager = GameObject.Find("[Scene Manager]").GetComponent<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && dialogue.hasTalked && isInside)
        {
            if (gameObject.name == "Impresora")
            {
                counterManager.SumarAlCounter();
                for (int i = 0; i < GreenLights.Length; i++)
                {
                    GreenLights[i].GetComponent<Light>().enabled = false;
                    RedLights[i].GetComponent<Light>().enabled = true;
                }
                colliderLights = gameObject.GetComponent<BoxCollider>();
                colliderLights.enabled = false;
                isInside = false;
                text.enabled = false;
            }
            if (gameObject.name == "PuertaCajaElectrica.001")
            {
                counterManager.SumarAlCounter();
                mesh.enabled = false;
                colliderSpeakers = gameObject.GetComponent<BoxCollider>();
                colliderSpeakers.enabled = false;
                isInside = false;
                text.enabled = false;
                source.Stop();
            }
            if(gameObject.name == "Gabinete")
            {
                counterManager.SumarAlCounter();
                gameObject.SetActive(false);
                colliderCabinet = gameObject.GetComponent<BoxCollider>();
                colliderCabinet.enabled = false;
                isInside = false;
                text.enabled = false;
            }
        }
        if (dialogue.hasTalked && !sceneManager.disappearText)
        {
            if(counterManager.counter != 1)
            {
                objetosEncontrados.text = "Encontraste " + counterManager.counter + " objetos de los 3.";
                objetosEncontrados.enabled = true;
            }
            if (counterManager.counter == 1)
            {
                objetosEncontrados.text = "Encontraste " + counterManager.counter + " objeto de los 3.";
                objetosEncontrados.enabled = true;
            }
        }
        if (dialogue.hasKey)
        {
            objetosEncontrados.text = "Tenes la llave! Apurate a salir antes que el colegio cierre!";
            objetosEncontrados.enabled = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isInside = true;
            if (dialogue.hasTalked)
            {
                if (gameObject.name == "Impresora")
                {
                    text.text = "Presiona F para apagar las impresoras.";
                    text.enabled = true;
                }
                if (gameObject.name == "PuertaCajaElectrica.001")
                {
                    text.text = "Presiona F para apagar los parlantes.";
                    text.enabled = true;
                }
                if (gameObject.name == "Gabinete")
                {
                    text.text = "Presiona F para apagar el Gabinete.";
                    text.enabled = true;
                }
            }
            if (!dialogue.hasTalked)
            {
                text.text = "Debes terminar de hablar con el NPC primero.";
                text.enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        isInside = false;
        if(col.gameObject.tag == "Player")
        {
            text.enabled = false;
        }
    }
}
