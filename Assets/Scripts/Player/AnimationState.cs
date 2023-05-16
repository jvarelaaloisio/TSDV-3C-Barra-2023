using System;
using UnityEngine;

namespace Player
{
    public class AnimationState : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void PlayerWalking()
        {
            animator.SetBool("isWalking", true);
        }

        public void PlayerIdle()
        {
            animator.SetBool("isWalking", false);
        }
    }
}