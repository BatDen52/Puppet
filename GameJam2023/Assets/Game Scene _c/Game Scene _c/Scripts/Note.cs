using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float bpm;
    public float tempo;
    private void Start()
    {
        tempo = bpm / 60f;
    }
    void Update()
    {
        transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
    }
}
