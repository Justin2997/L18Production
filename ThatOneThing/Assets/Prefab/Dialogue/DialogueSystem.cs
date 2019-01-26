using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    private Queue<Dialogue> m_DialogueQueue = new Queue<Dialogue>();
    private bool m_IsDialoguePlaying;
    private Dialogue m_CurrentDialogue;
    private int m_PhraseIt = 0;

    [SerializeField]
    protected Text m_UIDialogueBoxReference;
    [SerializeField]
    protected Text m_UIDialogueNameReference;
    [SerializeField]
    protected Animator m_UIDialogueBoxAnimator;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsDialoguePlaying)
        {
            if(Input.GetKeyUp("space"))
            {
                NextPhrase();
            }
        }
        else if (m_DialogueQueue.Count != 0)
        {
            StartDialogue();
            m_IsDialoguePlaying = true;
        }
    }

    void StartDialogue()
    {
        m_CurrentDialogue = m_DialogueQueue.Dequeue();
        m_PhraseIt = 0;
        ShowCurrentPhrase();
        m_UIDialogueBoxAnimator.SetBool("IsOpen", true);
    }

    void CloseDialogue()
    {
        m_IsDialoguePlaying = false;
        m_UIDialogueBoxAnimator.SetBool("IsOpen", false);
    }

    private void NextPhrase()
    {
        ++m_PhraseIt;
        int size = m_CurrentDialogue.Sentences.Length;

        if (m_PhraseIt >= size)
        {
            CloseDialogue();
        }
        else
        {
            ShowCurrentPhrase();
        }
    }

    private void ShowCurrentPhrase()
    {
        int size = m_CurrentDialogue.Sentences.Length;

        m_UIDialogueNameReference.text = m_CurrentDialogue.DialogueName;
        m_UIDialogueBoxReference.text = m_CurrentDialogue.Sentences[m_PhraseIt];
    }

    public void AddDialogue(Dialogue dialogueToAdd)
    {
        m_DialogueQueue.Enqueue(dialogueToAdd);
    }
}
