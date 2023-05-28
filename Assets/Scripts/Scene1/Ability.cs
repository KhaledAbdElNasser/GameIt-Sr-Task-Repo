using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public new string name;
    // for period Abilities
    public float activeTime;
    public float cooldownTime;
    public float currentActiveTime { get; set; }
    public float currentCooldownTime { get; set; }
    public AbilityState currentState { get; set; }

    public KeyCode key;


    public virtual void Activate(GameObject character)
    {

    }     
    public virtual void Deactivate(GameObject character)
    {

    } 
}
