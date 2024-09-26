using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = 0.1f;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }
     void Update()
    {
        float speedPersent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPersent", speedPersent, locomotionAnimationSmoothTime, Time.deltaTime);
    }

}
