using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTriggersSound : MonoBehaviour
{

    BoxCollider2D collider;
    public MapZone m_MapZone;

    [SerializeField]
    protected SoundManager m_SoundManager;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_SoundManager.m_CurrentZone = m_MapZone;
    }
}
