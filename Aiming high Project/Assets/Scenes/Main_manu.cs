using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_manu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //FindObjectOfType<AudioManagerMainMenu>().Stop("main");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void Options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
       
    }




}
