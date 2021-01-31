using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Response", menuName = "ScriptableObjects/PlayerResponse", order = 1)]
public class PlayerResponses : ScriptableObject
{
    public string Choice1;
    public string choice2;
    
    public bool isSingleResponse;
}
