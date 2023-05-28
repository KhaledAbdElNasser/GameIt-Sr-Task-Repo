using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

[CreateAssetMenu(menuName = "Abilities/Dash Ability", order = 0)]
public class DashAbility : Ability
{
    public float dashAmount;

    public override void Activate(GameObject character)
    {
        ThirdPersonController controller = character.GetComponent<ThirdPersonController>();
        controller.Dash(dashAmount);       
    }
}
