using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    Dialogue dialogue;
    CounterManager counterManager;
    public Image blackOut;
    public Text ending;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        counterManager = GameObject.Find("[Counter Manager]").GetComponent<CounterManager>();
        dialogue = GameObject.Find("NPC").GetComponent<Dialogue>();
        player = GameObject.Find("NPC");
        //blackOut.canvasRenderer.SetAlpha(0);
        ending.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogue.lose)
        {
            player.GetComponent<MeshRenderer>().enabled = false;
            if (dialogue.isGone && Input.GetKeyDown(KeyCode.E))
            {
                blackOut.canvasRenderer.SetAlpha(1);
                Debug.Log("Lost");
                ending.text = "Imaginate perder que malo que sos";
                ending.enabled = true;
            }
        }
        //if (dialogue.hasCompleted) Si sale, le muestro esto, detecto si sale midiendo el trigger de la puerta.
        //{
        //    //Fade to a victory scene.
        //    blackOut.enabled = true;
        //    Debug.Log("Win");
        //    ending.text = "GG WP";
        //    ending.enabled = true;
        //}
    }
}
