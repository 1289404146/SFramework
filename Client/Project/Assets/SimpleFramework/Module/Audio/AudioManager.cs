using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseMono, IManager
{
    private GameObject AudioObject;
    private AudioSource audioSource; 
    void Awake()
    {
        AudioObject= new GameObject("AudioObject");
        AudioObject.transform.SetParent(this.transform);
    }
    /// <summary>
    /// ������
    /// </summary>
    AudioSource bgmAudio;
    /// <summary>
    /// ��Ч���б�
    /// </summary>
    private List<AudioSource> effectList = new List<AudioSource>();
    /// <summary>
    /// ·��
    /// </summary>
    private string audioPath = "Source/";

    /// <summary>
    /// ���ű�������
    /// </summary>
    public void PlayBgm(string bgmName)
    {
        if (MusicSwitch)
        {
            if (bgmAudio == null)
            {
                bgmAudio = AudioObject.AddComponent<AudioSource>();
            }

            bgmAudio.loop = true;
            bgmAudio.volume = Sound;
            AudioClip clip = Main.ResourcesManager.Load<AudioClip>(audioPath + bgmName);
            bgmAudio.clip = clip;
            bgmAudio.Play();
        }
    }

    /// <summary>
    /// ��ͣ��������
    /// </summary>
    public void BGMPause()
    {
        if (bgmAudio != null)
        {
            bgmAudio.Pause();
        }
    }

    /// <summary>
    /// ֹͣ��������
    /// </summary>
    public void BGMStop()
    {
        if (bgmAudio != null)
        {
            bgmAudio.Stop();
        }
    }

    /// <summary>
    /// �����������²���
    /// </summary>
    public void BGMReplay()
    {
        if (MusicSwitch)
        {
            if (bgmAudio != null)
            {
                bgmAudio.Play();
            }
        }
    }

    /// <summary>
    /// ���ñ���������
    /// </summary>
    public void SetBgmVolume(float valume)
    {
        if (bgmAudio != null)
        {
            bgmAudio.volume = valume;
        }
    }

    /// <summary>
    /// ������Ϸ��ս��Ч
    /// </summary>
    public void PlayEffect(string name, bool loop = false, float volume = -1)
    {
        if (!SoundSwitch) return;

        AudioSource source = GetAudio();
        AudioClip clip =Main.ResourcesManager.Load<AudioClip>(audioPath + name);
        if (clip != null)
        {
            if (volume == -1)
                source.volume = Sound;
            else
                source.volume = volume;
            source.loop = loop;
            source.clip = clip;
            source.Play();
        }
        else
        {
            Debug.LogError("PlayGameEffect is null:" + name);
        }
    }

    /// <summary>
    /// �ӻ����л�ȡ������ϵ�Audio
    /// </summary>
    AudioSource GetAudio()
    {
        AudioSource source = null;
        foreach (var item in effectList)
        {
            if (!item.isPlaying)
            {
                source = item;
                break;
            }
        }

        if (source == null)
        {
            source = AudioObject.AddComponent<AudioSource>();
            effectList.Add(source);
        }
        return source;
    }

    /// <summary>
    /// ָֹͣ����Ч
    /// </summary>
    public void StopGameEffect(string name)
    {
        foreach (var item in effectList)
        {
            if (item.clip.name == name)
            {
                item.Stop();
            }
        }
    }

    /// <summary>
    /// ��ͣ��Ч
    /// </summary>
    public void PauseEffect(string name)
    {
        foreach (var item in effectList)
        {
            if (item.clip.name == name)
            {
                item.Pause();
            }
        }
    }

    /// <summary>
    /// ��ͣ������Ч
    /// </summary>
    public void PauseAll()
    {
        foreach (var item in effectList)
        {
            item.Pause();
        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    public void SetVolumeAll(float volume)
    {
        SetBgmVolume(volume);
        foreach (var item in effectList)
        {
            item.volume = volume;
        }
    }

    public void Initilize()
    {
        Debug.Log("AudioManager------Initilize");
    }

    public void DeInitilize()
    {
        Debug.Log("AudioManager------DeInitilize");
    }

    /// <summary>
    /// �������ֿ���
    /// </summary>
    public bool MusicSwitch
    {
        get
        {
            string swi = PlayerPrefs.GetString("musicswitch", "true");
            return bool.Parse(swi);
        }
        set
        {
            PlayerPrefs.SetString("musicswitch", value.ToString());
            if (!value)
            {
                BGMStop();
            }
            else
            {
                BGMReplay();
            }
        }
    }

    /// <summary>
    /// ��Ч�������� ��Ч
    /// </summary>
    public bool SoundSwitch
    {
        get
        {
            string swi = PlayerPrefs.GetString("SoundSwitch", "true");
            return bool.Parse(swi);
        }
        set
        {
            PlayerPrefs.SetString("SoundSwitch", value.ToString());
            if (!value)
            {
                PauseAll();
            }
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    public float Sound
    {
        get
        {
            return PlayerPrefs.GetFloat("sound", 1);
        }
        set
        {
            PlayerPrefs.SetFloat("sound", value);
            SetVolumeAll(value);
        }
    }
}

