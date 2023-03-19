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
    [SerializeField] List<SpriteRenderer> UIBack; 
    public void FinalAnim()
    {
        StartCoroutine(LoadWinscreen(3.48f));
        anims[2].animator.enabled = true;
        foreach (UIAnim anim in anims) 
        {
            anim.animator.Play(anim.animation);
        }
        foreach(var i in UIBack)
        {
            StartCoroutine(UIFade(i));
        }
    }

    public void WinSequence()
    {
        StartCoroutine(LoadWinscreen(0));
    }

    [SerializeField] GameObject winscreen;

    private IEnumerator LoadWinscreen( float time)
    {
        yield return new WaitForSeconds(time);
        winscreen.SetActive(true);
        winscreen.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        winscreen.transform.GetChild(1).gameObject.SetActive(true);
    }

    private IEnumerator UIFade(SpriteRenderer img)
    {
        float alpha = 1f;
        while(alpha> 0f) 
        {
            alpha -= .1f;
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
            yield return new WaitForSeconds(.1f);
        }
    }

    [SerializeField] List<Sprite> sheetSprites;
    [SerializeField] Image sheetSprite;
    private int count = 0;
    public void UpdateUI()
    {
        if(count<sheetSprites.Count)
        {
            sheetSprite.sprite = sheetSprites[count];
            count++;
        }

    }



}
