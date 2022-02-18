using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu_Back()
    {
        Menuwindow menu = GameObject.Find("Dark").GetComponent<Menuwindow>();
        SoundManager.Instance.Play("Button_Click");
        Time.timeScale = 1;
        menu.num = 0;
    }
    public void Sound_Back()
    {
        SoundWindow Sound = GameObject.Find("SoundWindow").GetComponent<SoundWindow>();
        SoundManager.Instance.Play("Button_Click");
        Sound.num = 0;
    }
    public void Creator_Back()
    {
        CreatorWindow Creator = GameObject.Find("CreatorWindow").GetComponent<CreatorWindow>();
        SoundManager.Instance.Play("Button_Click");
        Creator.num = 0;
    }
    public void Title_Back()
    {
        TitleWindow Title = GameObject.Find("Title_Dark").GetComponent<TitleWindow>();
        SoundManager.Instance.Play("Button_Click");
        Title.num = 0;
    }
    public void Title_Yes()
    {
        Time.timeScale = 1;
        SoundManager.Instance.Play("Button_Click");
        SceneManager.LoadScene("Title");
    }
    public void Quit_Back()
    {
        QuitWindow Main = GameObject.Find("Quit_Dark").GetComponent<QuitWindow>();
        SoundManager.Instance.Play("Button_Click");
        Time.timeScale = 1;
        Main.num = 0;
    }

    public void Quit_Yes()
    {
        Application.Quit();
    }

    public void Sound()
    {
        SoundWindow Sound = GameObject.Find("SoundWindow").GetComponent<SoundWindow>();
        SoundManager.Instance.Play("Button_Click");
        Sound.num = 1;
    }
    public void Creator()
    {
        CreatorWindow Creator = GameObject.Find("CreatorWindow").GetComponent<CreatorWindow>();
        SoundManager.Instance.Play("Button_Click");
        Creator.num = 1;
    }
    public void Title()
    {
        TitleWindow Title = GameObject.Find("Title_Dark").GetComponent<TitleWindow>();
        SoundManager.Instance.Play("Button_Click");
        Title.num = 1;
    }
    public void Quit()
    {
        TitleWindow Title = GameObject.Find("Title_Dark").GetComponent<TitleWindow>();
        if (Title.num == 0)
        {
            SoundManager.Instance.Play("Button_Click");
            QuitWindow Main = GameObject.Find("Quit_Dark").GetComponent<QuitWindow>();
            Main.num = 1;
        }
    }
}
