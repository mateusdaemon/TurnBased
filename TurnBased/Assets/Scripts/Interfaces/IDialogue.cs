using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogue
{
    void StartDialogue(NPC npc);
    string NextDialNode(int index);
    void EndDialogue();
}

