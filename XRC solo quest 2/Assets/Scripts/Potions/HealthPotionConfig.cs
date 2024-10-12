using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Health Potion Config", fileName = "HealthPotionConfig")]
public class HealthPotionConfig : ScriptableObject
{
    public string Name;
    [TextArea] public string Description;
    public Sprite uiSprite;

    public int HealAmount = 2;
}
