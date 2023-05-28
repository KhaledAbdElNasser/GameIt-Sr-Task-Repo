using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/Shield Ability", order = 1)]
public class ShieldAbility : Ability
{
    public override void Activate(GameObject character)
    {
        character.transform.GetComponentInChildren<Shield>().Activate(true);
    }

    public override void Deactivate(GameObject character)
    {
        character.transform.GetComponentInChildren<Shield>().Activate(false);
    }
}