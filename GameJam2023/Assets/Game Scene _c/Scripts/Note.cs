using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float bpm;
    private float tempo;
    public Transform targetPos;
    public KeyCode key;
    private bool inTriggerArea = false;
    [SerializeField] CircleCollider2D extraCollider;
    private void Start()
    {
        tempo = (transform.position.x-targetPos.position.x) / (8 * (60f / 126))/60;
        print(tempo);
    }
    void Update()
    {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
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
    }

    public void AdjustPos()
    {
        int k = 0;
        switch (key)
        {
            case KeyCode.Q:
                k = 0;
                break;
            case KeyCode.W:
                k = 1;
                break;
            case KeyCode.E:
                k = 2;
                break;
            case KeyCode.R:
                k = 3;
                break;
        }
        Debug.Log(k);
        GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x,
                    GetComponent<RectTransform>().localPosition.y - k * 50f, 0);
        tempo = (transform.position.x - targetPos.position.x) / (8 * (60f / 126)) / 60;
        print(tempo);
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
            inTriggerArea = false;
        }
    }


    private void Hit()
    {
        Debug.Log("Hit");
    }

    private void Miss()
    {
        Debug.Log("Miss");
    }
}
