using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject panelMainMenu, panelAlmanac, panelInfo, panelCustomize;
    
    [SerializeField] private GameObject tutorial, player, camera, back;

    // Start is called before the first frame update
    void Start()
    {
        ManagePanel(false, false, true,false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void Play()
    {
        ManagePanel(false,false,false,true);
    }

    public void Almanac()
    {
        ManagePanel(true, false, false, false);
    }

    public void Info()
    {
        ManagePanel(false, true, false,false);
    }

    public void BackMainMenu()
    {
        ManagePanel(false, false, true,false);
    }
    
    public void LetsGo()
    {
        back.SetActive(false);
        if (PlayerPrefs.GetString(Constant.TUTORIAL, "") != "")
        {
            
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(camera);
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(camera);
            tutorial.SetActive(true);
            ManagePanel(false,false,false,false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void ManagePanel(bool almanac, bool info, bool mainmenu, bool customize)
    {
        panelAlmanac.SetActive(almanac);
        panelInfo.SetActive(info);
        panelMainMenu.SetActive(mainmenu);
        panelCustomize.SetActive(customize);
    }
}