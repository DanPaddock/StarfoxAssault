using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void ButtonPressed()
    {
        Invoke("LoadFirstScene", 0.2f);
    }


    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
