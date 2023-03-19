using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimHendler : MonoBehaviour
{
    [System.Serializable]
    public struct UIAnim
    {
        public Animator animator;
        public string animation;
    }


    public UIAnim[] anims;
    public void FinalAnim()
    {
        anims[2].animator.enabled = true;
        foreach (UIAnim anim in anims) 
        {
            anim.animator.Play(anim.animation);
        }
    }

    [SerializeField] List<Sprite> sheetSprites;
    [SerializeField] Image sheetSprite;
    private int count = 0;
    public void UpdateUI()
    {
        if(count<=sheetSprites.Count)
        {
            sheetSprite.sprite = sheetSprites[count];
            count++;
        }

    }

}
