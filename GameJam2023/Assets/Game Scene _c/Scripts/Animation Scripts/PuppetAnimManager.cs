using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetAnimManager : MonoBehaviour
{
    [System.Serializable]
    public struct AnimData
    {
        public Animator animator;
        public string animation;
        public Animator threadAnimator;
        public string threadAnimation;
    }
    [SerializeField] AnimData[] animations;


    private void SetAnim(int index)
    {
        animations[index].threadAnimator.Play(animations[index].threadAnimation);
        animations[index].animator.Play(animations[index].animation);
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Q)) 
        {
            SetAnim(8);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetAnim(6);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SetAnim(3);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SetAnim(1);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            SetAnim(0);
        }*/
    }

}
