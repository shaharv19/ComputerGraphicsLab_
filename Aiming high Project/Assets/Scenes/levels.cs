using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levels : MonoBehaviour
{
    public Text lvlText;
    public int level = 1;
    public Slider slider;
    public Text volume;
    public int volumeValue;
    public void Hard()
    {
        level = 3;
        lvlText.text = "Hard";
    }

    private void Start()
    {
        slider.onValueChanged.AddListener((v)=>{ volume.text = v.ToString("0"); });
        //FindObjectOfType<AudioManagerMainMenu>().Play("a");
    }

    void Update()
    {
        volumeValue = int.Parse(volume.text);
        StateNameController.volume = volumeValue;
        StateNameController.level = level;
    }

    public void Easy()
    {
        level = 1;
        lvlText.text = "Easy";
    }

    public void Medium()
    {
        level = 2;
        lvlText.text = "Medium";
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }


}
