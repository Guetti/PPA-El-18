using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BottonMain : MonoBehaviour
{
  public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
    public void QuitApk() {
        Application.Quit();
    }
}            