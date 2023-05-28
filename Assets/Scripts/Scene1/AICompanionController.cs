using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AICompanionController : MonoBehaviour
{
    public Transform player;
    
    NavMeshAgent agent;
    Animator animator;
    private int animIDSpeed;
    private int animIDMotionSpeed;
    Vector3 destnation;

    public AudioClip LandingAudioClip;
    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        AssignAnimationIDs();
    }

    // Update is called once per frame
    void Update()
    {
        destnation = player.position;
        agent.destination = destnation;
        if(agent != null && !agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetFloat(animIDSpeed, .1f);
                animator.SetFloat(animIDMotionSpeed, 0.1f);
            }
            else
            {
                animator.SetFloat(animIDSpeed, 5f);
                animator.SetFloat(animIDMotionSpeed, 1f);
            }
        }
        
    }

    private void AssignAnimationIDs()
    {
        animIDSpeed = Animator.StringToHash("Speed");
        animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(transform.position), FootstepAudioVolume);
            }
        }
    }
}
