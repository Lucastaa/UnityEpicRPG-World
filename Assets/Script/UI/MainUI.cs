using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("--------- Audio Sources ---------")]
    public AudioManager audio;
    [Header("--------- Master Sound ---------")]
    public GameObject soundOn;
    public GameObject soundOff;
    [Header("--------- Setting Panel ---------")]
    public GameObject musicObjOn;
    public GameObject musicObjOff;
    public GameObject lookOn;
    public GameObject lookOff;
    public GameObject micOn;
    public GameObject micOff;
    public GameObject settingPanel;
    public void MicToggle()
    {
        if (micOn != null && micOff != null)
        {
            if (micOn.activeSelf)
            {
                micOn.SetActive(false);
                micOff.SetActive(true);
            }
            else
            {
                micOn.SetActive(true);
                micOff.SetActive(false);
            }
        }
    }
    public void LockToggel()
    {
        if (lookOn != null && lookOff != null)
        {
            if (lookOn.activeSelf)
            {
                lookOn.SetActive(false);
                lookOff.SetActive(true);
            }
            else
            {
                lookOn.SetActive(true);
                lookOff.SetActive(false);
            }
        }
    }
    public void MusicToggle()
    {
        if (audio != null && audio.musicSource != null && musicObjOn != null && musicObjOff != null)
        {
            if (audio.musicSource.isPlaying)
            {
                audio.musicSource.Pause();
                musicObjOff.SetActive(true);
                musicObjOn.SetActive(false);
            }
            else
            {
                audio.musicSource.Play();
                musicObjOff.SetActive(false);
                musicObjOn.SetActive(true);
            }
        }
    }
    public void Setting()
    {
        if (settingPanel == null)
        {
            settingPanel.SetActive(true);
        } 
        else
        {
            settingPanel.SetActive(!settingPanel.activeSelf);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
    public void SoundToggle()
    {
        if (soundOn != null && soundOff != null)
        {
            if (soundOn.activeSelf)
            {
                soundOn.SetActive(false);
                soundOff.SetActive(true);
                AudioListener.volume = 0f;
            }
            else
            {
                soundOn.SetActive(true);
                soundOff.SetActive(false);
                AudioListener.volume = 1f;
            }
        }
    }
    public void PlayScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}