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
    }
    [SerializeField] AnimData[] animations;

    public void SetAnim(int animIndex)
    {
        animations[animIndex].animator.Play(animations[animIndex].animation);
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            SetAnim(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetAnim(1);
        }
    }

}
