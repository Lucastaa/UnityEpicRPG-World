using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [Header("--------- First Selected Options ---------")]
    public GameObject _mainMenuFirst;
    public GameObject _settingsMenuFirst;
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
    public GameObject pause;
    public GameObject resume;
    public GameObject settingPanel;

    [Header("--------- Player Stop ---------")]
    public Bandit _playerMove;
    public BanditCombat _playerCombat;
    public void PauseToggle()
    {
        if (pause != null && resume != null)
        {
            if (pause.activeSelf)
            {
                pause.SetActive(false);
                resume.SetActive(true);
                Time.timeScale = 0f;

                _playerMove.enabled = false;
                _playerCombat.enabled = false;
            }
            else
            {
                pause.SetActive(true);
                resume.SetActive(false);
                Time.timeScale = 1f;

                _playerMove.enabled = true;
                _playerCombat.enabled = true;
            }
        }
    }
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

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirst);
    }
    public void Setting()
    {
        if (settingPanel == null)
        {
            settingPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
        } 
        else
        {
            settingPanel.SetActive(!settingPanel.activeSelf);

            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }

            EventSystem.current.SetSelectedGameObject(null);
        }
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
    public void Update()
    {
        if (InteractUI.instance != null && InteractUI.instance.MenuOpenCloseInput)
        {
            Setting();
        }

        if (InteractUI.instance != null && InteractUI.instance.PauseGameInput)
        {
            PauseToggle();
        }
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}