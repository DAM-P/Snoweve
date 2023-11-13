using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableAudio : StateMachineBehaviour
{
    public AudioClip audioClip, audioClipend;
    private AudioSource audioSource;
    public bool End;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (audioSource == null)
        {
            audioSource = animator.GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = animator.gameObject.AddComponent<AudioSource>();
            }

        }
       // audioSource = animator.GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (End)
        {
            if (audioSource == null)
            {
                audioSource = animator.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    audioSource = animator.gameObject.AddComponent<AudioSource>();
                }

            }
            //audioSource = animator.GetComponent<AudioSource>();
            audioSource.loop = false;
            audioSource.clip = audioClipend;
            audioSource.Play();
        }   
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
