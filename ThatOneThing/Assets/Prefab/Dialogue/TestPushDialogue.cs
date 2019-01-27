using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPushDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Dialogue dialogue = GetComponent<Dialogue>();
        DialogueSystem.GetInstance().AddDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
