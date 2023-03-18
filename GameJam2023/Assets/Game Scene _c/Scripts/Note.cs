using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public IReadOnlyCollection<string> AllKeys = new List<string> { "q", "w", "e", "r", "p", "o", "i", "u" };

    public float bit;
    public string key;
    public Transform targetPos;
    public bool isActive = false;
    public Image backgroundImage;
    public Image keyImage;
    public Sprite[] keys;
    public Color32[] colors;

    private float tempo;
    private bool inTriggerArea = false;
    private bool isAlredyExit = false;

    public event Action<float> Missed;
    public event Action<float> Hiting;

    private void Start()
    {
        tempo = (transform.position.x - targetPos.position.x) / (8 * (60f / 126)) / 60;
    }

    private void Update()
    {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);

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
        tempo = (transform.position.x - targetPos.position.x) / (8 * (60f / 126)) / 60;
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
            isActive = false;
            inTriggerArea = false;
            isAlredyExit = true;
            Missed?.Invoke(bit);
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

    private bool IsRightKeyDown(List<string> keys)
    {
        return AllKeys.All(i => Input.GetKey(i) && keys.Contains(i));
    }
}
