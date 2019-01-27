using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    MapZone m_AncientZone;
    public MapZone m_CurrentZone;

    AudioSource m_AudioSource;
    AudioSource m_AMBAudioSource;

    public AudioClip m_MusicVille;
    public AudioClip m_MusicParc;
    public AudioClip m_MusicPlage;

    public AudioClip m_AMBVille;
    public AudioClip m_AMBParc;
    public AudioClip m_AMBPlage;

    // Start is called before the first frame update
    void Start()
    {
        foreach (AudioSource aSource in GetComponents<AudioSource>())
        {
            if (aSource.clip.name.Equals("Music_City (online-audio-converter.com)"))
            {
                m_AudioSource = aSource;

            }
            else
            {
                m_AMBAudioSource = aSource;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_AncientZone != m_CurrentZone)
        {
            m_AncientZone = m_CurrentZone;

            if (m_CurrentZone == MapZone.Ville)
            {
                m_AudioSource.clip = m_MusicVille;
                m_AMBAudioSource.clip = m_AMBVille;
            }
            else if(m_CurrentZone == MapZone.Plage)
            {
                m_AudioSource.clip = m_MusicPlage;
                m_AMBAudioSource.clip = m_AMBPlage;
            }
            else if (m_CurrentZone == MapZone.Parc)
            {
                m_AudioSource.clip = m_MusicParc;
                m_AMBAudioSource.clip = m_AMBParc;
            }

            m_AudioSource.Play();
            m_AMBAudioSource.Play();
        }
    }
}
