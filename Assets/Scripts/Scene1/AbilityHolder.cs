using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float activeTime;
    float cooldownTime;

    private StarterAssetsInputs _input;

    public KeyCode key;

    enum AbilityState
    {
        ready, 
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                break;
            case AbilityState.active:
                if(activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    ability.Deactivate(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
            default:
                break;
        }


    }
}
