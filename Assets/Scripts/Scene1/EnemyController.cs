using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    private int animIDSpeed;
    private int animIDMotionSpeed;
    Vector3 destnation;

    public List<Transform> points;
    public float baseIdleTime = 3;
    float idleTime;


    public AudioClip LandingAudioClip;
    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;


    public enum EnemyState
    {
        idle,
        patrol,
    }

    EnemyState state;
                        

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        AssignAnimationIDs();
    }

    private void Start()
    {
        state = EnemyState.patrol;
        destnation = points[Random.Range(0, points.Count)].position;
        agent.destination = destnation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.idle:
                if (idleTime > 0)
                {
                    idleTime -= Time.deltaTime;
                }
                else
                {
                    state = EnemyState.patrol;
                    destnation = points[Random.Range(0, points.Count)].position;
                    agent.destination = destnation;
                }
                break;
            case EnemyState.patrol:
                if (agent != null)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        animator.SetFloat(animIDSpeed, .1f);
                        animator.SetFloat(animIDMotionSpeed, 0.1f);
                        state = EnemyState.idle;
                        idleTime = baseIdleTime;
                    }
                    else
                    {
                        animator.SetFloat(animIDSpeed, 4f);
                        animator.SetFloat(animIDMotionSpeed, 1f);
                    }
                }
                break;
            default:
                break;
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
