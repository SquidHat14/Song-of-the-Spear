using UnityEngine;
using System.Collections;


[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.7f;
    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    [HideInInspector]
    private AudioSource source;

    public bool loop;
    public bool PlayOnAwake;
    public bool backgroundSong;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.playOnAwake = PlayOnAwake;
    }

    public void Play()
    {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    Sound[] soundEffects;  //Played on triggers within scene

    void Awake()  //Set as singleton
    {
        if (instance != null)
        {
            Debug.LogError("More than one AudioManager in the scene.");
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + instance.soundEffects[i].name);
            _go.transform.SetParent(this.transform);
            instance.soundEffects[i].SetSource(_go.AddComponent<AudioSource>());
        }

        PlayStartingSounds();
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].name == _name)
            {
                instance.soundEffects[i].Play();
                return;
            }
        }
        // no sound with _name
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }

    public void PlayStartingSounds()
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].PlayOnAwake == true)
            {
                instance.soundEffects[i].Play();
            }
        }
    }

    public void StopSound(string _name)
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].name == _name)
            {
                instance.soundEffects[i].Stop();
                return;
            }
        }

        // no sound with _name
        Debug.LogWarning("AudioManager: Sound not found in list, " + _name);
    }

    public void ChangeBackgroundSong(string _name)
    {
        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].backgroundSong == true)
            {
                instance.soundEffects[i].Stop();
                if (instance.soundEffects[i].name == _name)
                {
                    instance.soundEffects[i].Play();
                }
            }
        }
    }


    public static IEnumerator FadeOut(string _name, float FadeTime)
    {
        Sound sound = null;

        for (int i = 0; i < instance.soundEffects.Length; i++)
        {
            if (instance.soundEffects[i].name == _name)
            {
               sound = instance.soundEffects[i];
            }
        }

        if (sound != null)
        {
            float startVolume = sound.volume;



            while (sound.volume > 0)
            {
                sound.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            sound.Stop();
            sound.volume = startVolume;
        }
        else
        {
            Debug.Log("No sound with that name");
        }
    }
}
