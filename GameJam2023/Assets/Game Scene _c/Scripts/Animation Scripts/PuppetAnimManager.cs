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
    [SerializeField] AnimData[] breakAnimations;

    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        score.Broken += SetBreakAnim;
    }

    private void SetBreakAnim(int count)
    {
        Debug.Log("Broken");
        int index = UnityEngine.Random.Range(0, breakAnimations.Length - 1);
        breakAnimations[index].threadAnimator.Play(breakAnimations[index].threadAnimation);
        breakAnimations[index].animator.Play(breakAnimations[index].animation);
        count--;
        if(count<=0)
        {
            //GameOverSequence
        }
    }

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


}
