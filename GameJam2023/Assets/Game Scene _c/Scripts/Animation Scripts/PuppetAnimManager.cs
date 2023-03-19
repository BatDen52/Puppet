using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuppetAnimManager : MonoBehaviour
{
    [System.Serializable]
    public struct AnimData
    {
        public Animator animator;
        public string animation;
        public Animator threadAnimator;
        public string threadAnimation;
        public bool broken;
    }
    [SerializeField] AnimData[] animations;
    [SerializeField] AnimData[] breakAnimations;


    private Score score;
    private int[] breakOrder = new int[4] { 0, 1, 2, 3 };
    private int currentIndex = 0;
    private void Start()
    {
        score = FindObjectOfType<Score>();
        score.Broken += SetBreakAnim;
        System.Random random = new System.Random();
        breakOrder = breakOrder.OrderBy(x => random.Next()).ToArray();
    }

    private void SetBreakAnim(int count)
    {
        Debug.Log("Broken");
        int index = currentIndex;
        breakAnimations[index].threadAnimator.Play(breakAnimations[index].threadAnimation);
        breakAnimations[index].animator.Play(breakAnimations[index].animation);
        animations[index].broken = true;
        count++;
        currentIndex++;
        if(count==6)
        {
            Debug.Log("GameOverSequence");
        }
    }

    public void SetAnim(string key, bool Break)
    {
        int index = 0;
        switch (key)
        {
            case "q":
            case "p":
                index = 0;
                break;
            case "w":
            case "o":
                index = 1;
                break;
            case "e":
            case "i":
                index = 2;
                break;
            case "r":
            case "u":
                index = 3;
                break;
        }
        if(!animations[index].broken)
        {
            animations[index].threadAnimator.Play(animations[index].threadAnimation);
            animations[index].animator.Play(animations[index].animation);
        }

    }


}
