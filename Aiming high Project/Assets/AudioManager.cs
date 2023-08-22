/*using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); 
    }
    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = true;

        }
        Debug.Log("2");
        //Play("Background");
    }

    // Update is called once per frame
    public void Play(String name)
    {
       Sound s= Array.Find(sounds, sound => sound.name == name);
       s.audioSource.Play();

    }

    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Stop();
    }

    public void PlayOneTime(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.loop = false;
        s.audioSource.Play();

    }
    private void Update()
    {

    }
}*/
