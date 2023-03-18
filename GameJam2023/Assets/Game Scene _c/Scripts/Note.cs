using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float bpm;
    public float tempo;
    public Transform targetPos;
    private void Start()
    {
        tempo = (transform.position.x-targetPos.position.x) / (8 * (60f / 126))/60;
        print(tempo);
    }
    void Update()
    {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
    }
}
