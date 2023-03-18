using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class MenuUIHendler : MonoBehaviour
{
    [SerializeField] GameObject SongAarray;
    [SerializeField] GameObject Menu;
    public void Exit()
    {
    }
    public void ChooseSong()
    {
        SongAarray.SetActive(true);
        Menu.SetActive(false);
    }

    public void ShowNextSong()
    {

    }

    public void ShowPreviouseSong()
    {

    }

    public void SetSong()
    {

    }

    public void BackToMenu()
    {
        SongAarray.SetActive(false);
        Menu.SetActive(true);
    }

}
