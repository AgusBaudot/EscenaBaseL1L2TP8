using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string[] nombresEscenas;
    [SerializeField] int index;

    public void CambioEscena()
    {
        if (index >= nombresEscenas.Length)
        {
            index = 0;
        }

        SceneManager.LoadScene(nombresEscenas[index]);
        index++;
    }
}
