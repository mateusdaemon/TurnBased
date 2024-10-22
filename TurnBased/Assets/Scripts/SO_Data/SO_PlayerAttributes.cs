using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_PlayerAttribute", menuName = "ScriptableObjects/SO_PlayerAttribute")]
public class SO_PlayerAttributes : ScriptableObject, ISerializationCallbackReceiver
{
    public int available;
    public int loyalty;
    public int wisdom;
    public int spirit;
    public int expertise;

    public void OnAfterDeserialize()
    {
        loyalty = 1;
        wisdom = 1;
        spirit = 1;
        expertise = 1;
        available = 1;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
