using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.canvasRenderer.SetAlpha(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            image.CrossFadeAlpha(1, 3, false);
        }
    }
}
