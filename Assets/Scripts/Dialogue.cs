using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField] string[] dialogue;
    public TextMeshProUGUI text;
    [SerializeField] int counter = 0;
    bool isTalking = false;
    bool hasCompleted = false;
    public bool hasTalked = false;
    public Text timeLeft;
    public float clock = 60f;
    public bool lose = false;
    CounterManager counterManager;
    public bool hasKey = false;
    public bool isGone = false;
    public AudioSource source;
    public AudioClip gameOver;

    // Start is called before the first frame update
    void Start()
    {
        counterManager = GameObject.Find("[Counter Manager]").GetComponent<CounterManager>();
        text.enabled = false;
        timeLeft.enabled = false;
        hasTalked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isTalking && counter < dialogue.Length-1)
        {
            counter++;
            ShowDialogue();
        }
        if (counter == 6 && clock > 0)
        {
            timeLeft.enabled = true;
            clock -= Time.deltaTime;
            timeLeft.text = clock.ToString("F2");
            hasTalked = true;
        }
        if (clock <= 0)
        {
            lose = true;
        }
        if (counterManager.counter == 3)
        {
            hasCompleted = true;
        }
        if (isTalking && hasCompleted)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasKey = true;
            }
        }
        if (isTalking && lose)
        {
            isGone = true;
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player" && !hasCompleted)
        {
            ShowDialogue();
        }
        if (col.gameObject.tag == "Player" && hasCompleted)
        {
            text.text = "Gracias, tomá la llave para salir" + Environment.NewLine + "(presioná E para obtener)";
            isTalking = true;
            text.enabled = true;
        }
        if (col.gameObject.tag == "Player" && lose)
        {
            text.text = "Apretá E...";
            isTalking = true;
            text.enabled = true;
        }
    }

    void OnTriggerExit (Collider col)
    {
        text.enabled = false;
        isTalking = false;
    }

    void ShowDialogue()
    {
        text.text = dialogue[counter];
        text.enabled = true;
        isTalking = true;
    }
}