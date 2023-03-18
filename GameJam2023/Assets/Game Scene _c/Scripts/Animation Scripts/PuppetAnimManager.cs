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


    private void SetAnim(int index)
    {
        animations[index].animator.Play(animations[index].animation);
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Q)) 
        {
            SetAnim(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            SetAnim(1);
        }*/
    }

}