using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    MapZone m_AncientZone;
    public MapZone m_CurrentZone;

    AudioSource m_AudioSource;

    public AudioClip m_MusicVille;
    public AudioClip m_MusicParc;
    public AudioClip m_MusicPlage;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
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
            }
            else if(m_CurrentZone == MapZone.Plage)
            {
                m_AudioSource.clip = m_MusicPlage;
            }
            else if (m_CurrentZone == MapZone.Parc)
            {
                m_AudioSource.clip = m_MusicParc;
            }

            m_AudioSource.Play();
        }
    }
}
