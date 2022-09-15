using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Salida : MonoBehaviour
{
    Dialogue dialogue;
    public Text salida;
    [SerializeField] bool isClose = false;
    SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = dialogue = GameObject.Find("NPC").GetComponent<Dialogue>();
        salida.enabled = false;
        sceneManager = GameObject.Find("[Scene Manager]").GetComponent<SceneManager>();
        sceneManager.blackOut.canvasRenderer.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isClose && dialogue.hasKey)
        {
            gameObject.SetActive(false);
            salida.enabled = false;
            sceneManager.blackOut.CrossFadeAlpha(1, 1, false);
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
