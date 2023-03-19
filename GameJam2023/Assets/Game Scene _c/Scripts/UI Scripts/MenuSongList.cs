using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSongList : MonoBehaviour
{
    [System.Serializable]
    public struct MenuSongData
    {
        public string Name;
        public string Level;
        public Sprite preview;
        public int SceneIndex;
    }
    
    public MenuSongData[] songData;

    

}
