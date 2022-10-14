using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistator : MonoBehaviour
{
    public static Persistator instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
