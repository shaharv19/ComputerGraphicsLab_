using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManagerMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = true;
        }
        Play("main");
    }
    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s==null)
        {
            Debug.Log("not found!");
            return;
        }

        s.audioSource.Play();
    }

    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Stop();
    }

    public void Pause(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Pause();
    }

    public void UnPause(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.UnPause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
