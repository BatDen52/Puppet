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

    public void SetAnim(string key, bool Break)
    {
        int index = 0;
        switch (key)
        {
            case "q":
            case "p":
                index = 2;
                break;
            case "w":
            case "o":
                index = 4;
                break;
            case "e":
            case "i":
                index = 5;
                break;
            case "r":
            case "u":
                index = 7;
                break;
        }

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
