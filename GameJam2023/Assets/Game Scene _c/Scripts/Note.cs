using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public float bit;
    public string key;
    public Transform targetPos;
    public bool isActive = false;
    public Image backgroundImage;
    public Image keyImage;
    public Sprite[] keys;
    public Color32[] colors;
    public float speed = 4;

    private bool inTriggerArea = false;

    public event Action<float> Missed;
    public event Action<float> Hiting;

    private void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("bit_trigger").GetComponent<Transform>();
        StartCoroutine(DoMove(speed, Vector2.zero));
    }

    private IEnumerator DoMove(float time, Vector2 targetPosition)
    {
        var rectTransform = GetComponent<RectTransform>();
        var targetPosX = targetPos.localPosition.x;
        Vector2 startPosition = rectTransform.anchoredPosition;

        targetPosX = startPosition.x + (targetPosX - startPosition.x) * 1.15f;
        time *= 1.2f;

        double startTime = AudioSettings.dspTime;
        float fraction = 0f;

        while (fraction < 1f)
        {
            fraction = Mathf.Clamp01((float)((AudioSettings.dspTime - startTime) / time));
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, new Vector2(targetPosX, startPosition.y), fraction);
            yield return null;
        }
    }

    private void Update()
    {
        if (bit == SongManager.curretnBit)
            if (Input.GetKeyDown(key))
            {
                if (inTriggerArea)
                {
                    Hit();
                }
                else
                {
                    Miss();
                }
            }

        //if (AllKeys.Any(i => Input.GetKeyDown(i)))
        //    if (IsRightKeyDown(_notes[nextNoteIndex].Keys))
        //        if (Mathf.Abs((float)currentPos - _notes[Mathf.Max(nextNoteIndex - 1, 0)].Bit) <= offset)
        //        {
        //        }
        //        else
        //        {
        //        }
    }

    public void AdjustPos()
    {
        int k = 0;

        switch (key)
        {
            case "q":
            case "p":
                k = 0;
                break;
            case "w":
            case "o":
                k = 1;
                break;
            case "e":
            case "i":
                k = 2;
                break;
            case "r":
            case "u":
                k = 3;
                break;
        }

        backgroundImage.color = colors[k];
        keyImage.sprite = keys[k];

        GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x,
                    GetComponent<RectTransform>().localPosition.y - k * 50f, 0);
        //speed = (transform.position.x - targetPos.position.x) / (8 * (60f / 126)) / 60;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bit_trigger")
        {
            inTriggerArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "bit_trigger")
        {
            if(isActive==false)
                Missed?.Invoke(bit);
            isActive = false;
            inTriggerArea = false;
        }
    }

    private void Hit()
    {
        isActive = true;
        Hiting?.Invoke(bit);
        Debug.Log("Hit");
    }

    private void Miss()
    {
        isActive = false;
        Missed?.Invoke(bit);
        Debug.Log("Miss");
    }
}
