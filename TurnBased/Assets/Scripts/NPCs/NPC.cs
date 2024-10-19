using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IDialogue
{
    private DialogueManager dialogueManager;
    public Sprite profilePic;
    public string npcName;
    [TextArea(4, 10)]
    public string[] npcTexts;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndDialogue()
    {
        dialogueManager.EndDialogue();
    }

    public string NextDialNode(int index)
    {
        string nextText = null;

        if (index == npcTexts.Length)
        {
            EndDialogue();
        } else
        {
            nextText = npcTexts[index];
        }

        return nextText;
    }

    public void StartDialogue(NPC npc)
    {
        dialogueManager.StartDialogue(npc);
    }
}
