using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Image npcPicture;
    public Button nextLineBtn;
    public TextMeshProUGUI dialogueText;

    private NPC npcInDial;
    private int dialIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextLineBtn.onClick.AddListener(PrintNextLine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrintNextLine()
    {
        dialIndex++;
        dialogueText.text = npcInDial.NextDialNode(dialIndex);
    }

    public void StartDialogue(NPC npc)
    {
        npcInDial = npc;
        npcPicture.sprite = npc.profilePic;
        dialoguePanel.SetActive(true);
        dialIndex = 0;
        dialogueText.text = npcInDial.NextDialNode(dialIndex);
    }
    
    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
