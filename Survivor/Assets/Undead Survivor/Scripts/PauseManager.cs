using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject ExitMenu;
    public GameObject mainMenu;
    public GameObject guideMenu;

    public void guide_btn_clicked()
    {
        mainMenu.SetActive(false);
        guideMenu.SetActive(true);

    }
    public void guide_back_clicked()
    {
        guideMenu.SetActive(false);
        mainMenu.SetActive(true);

    }
    public void ExitMenu_btn_clicked()
    {
        mainMenu.SetActive(false);
        ExitMenu.SetActive(true);
    }
    public void ExitMenu_back_clicked()
    {
        ExitMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void option_btn_clicked()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void option_back_clicked()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
