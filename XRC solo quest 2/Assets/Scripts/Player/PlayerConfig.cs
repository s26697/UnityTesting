using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerConfig", fileName = "Player Config")]

public class PlayerConfig : ScriptableObject
{
    public int BaseHealth = 2;
    public int MaxHealth = 5;
}
