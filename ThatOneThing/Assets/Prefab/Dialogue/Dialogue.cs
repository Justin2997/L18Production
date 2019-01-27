using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [TextArea(1, 10)]
    public string[] Sentences;
    public string DialogueName;
    public Sprite DialogueImage;
    public AudioClip DialogueAudio;
}
