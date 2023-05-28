using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesHolder : MonoBehaviour
{
    //public Ability ability;
    public List<Ability> abilities;

    // Update is called once per frame
    void Update()
    {
        foreach (var ability in abilities)
        {
            switch (ability.currentState)
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(ability.key))
                    {
                        ability.Activate(gameObject);
                        ability.currentState = AbilityState.active;
                        ability.currentActiveTime = ability.activeTime;
                    }
                    break;
                case AbilityState.active:
                    if (ability.currentActiveTime > 0)
                    {
                        ability.currentActiveTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.Deactivate(gameObject);
                        ability.currentState = AbilityState.cooldown;
                        ability.currentCooldownTime = ability.cooldownTime;
                    }
                    break;
                case AbilityState.cooldown:
                    if (ability.currentCooldownTime > 0)
                    {
                        ability.currentCooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.currentState = AbilityState.ready;
                    }
                    break;
                default:
                    break;
            }
        }
        


    }
}
public enum AbilityState
{
    ready,
    active,
    cooldown
}