using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHendler : MonoBehaviour
{
    [SerializeField] GameObject SongAarray;
    [SerializeField] GameObject Menu;

    [SerializeField] TextMeshProUGUI songName;
    [SerializeField] TextMeshProUGUI songLevel;
    [SerializeField] Image preview;
    [SerializeField] AudioSource previewPlayer;
    private MenuSongList songList;
    private void Start()
    {
        songList = GetComponent<MenuSongList>();
    }
    public void Exit()
    {
    }
    public void ChooseSong()
    {
        SongAarray.SetActive(true);
        Menu.SetActive(false);

        /*songName.text = songList.songData[0].Name;
        songLevel.text = songList.songData[0].Level;
        preview.sprite = songList.songData[0].preview;*/
        //previewPlayer.Play();
    }

    public void ShowNextSong()
    {

    }

    public void ShowPreviouseSong()
    {

    }

    public void SetSong()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SongAarray.SetActive(false);
        Menu.SetActive(true);
    }

}
