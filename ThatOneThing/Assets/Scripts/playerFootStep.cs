using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFootStep : MonoBehaviour
{
    move m_MoveComponent;
    AudioSource m_AudioComponent;
    public SoundManager m_SoundManager;
    float m_LastTimeSinceFootStepSound;


    public float FootStepRateS;
    public AudioClip[] m_ConcreteFootstep;
    public AudioClip[] m_DirtFootstep;

    // Start is called before the first frame update
    void Start()
    {
        m_MoveComponent = GetComponent<move>();
        m_AudioComponent = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_MoveComponent.ismoving && IsReadyForNewFootstepSound())
        {
            if (m_SoundManager.m_CurrentZone == MapZone.Ville)
            {
                int index = Random.Range(0, m_ConcreteFootstep.Length-1);
                m_AudioComponent.clip = m_ConcreteFootstep[index];
                m_AudioComponent.Play();
                ResetTimer();
            }
            else
            {
                int index = Random.Range(0, m_DirtFootstep.Length - 1);
                m_AudioComponent.clip = m_DirtFootstep[index];
                m_AudioComponent.Play();
                ResetTimer();
            }
        }
    }

    void ResetTimer()
    {
        m_LastTimeSinceFootStepSound = Time.realtimeSinceStartup;
    }

    bool IsReadyForNewFootstepSound()
    {
        return (Time.realtimeSinceStartup - m_LastTimeSinceFootStepSound) > FootStepRateS;
    }
}
