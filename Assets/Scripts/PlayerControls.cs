using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    // BOOL FLAGS
    [SerializeField] Image blackSquare;

    // BOOL FLAGS
    bool fightFlag = true;
    bool bagFlag = false;
    bool pokeFlag = false;
    bool runFlag = false;
    bool menuFlag = false;

    // MENU INSERTS
    [SerializeField] GameObject fightMenu;
    [SerializeField] GameObject bagMenu;
    [SerializeField] GameObject pokeMenu;

    // BUTTON INSERTS
    [SerializeField] GameObject fightButton;
    [SerializeField] GameObject bagButton;
    [SerializeField] GameObject pokeButton;
    [SerializeField] GameObject runButton;

    // SOUND INSERT
    [SerializeField] AudioSource click;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ESCAPE
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // MENUS
        if (!menuFlag)
        {
            if (Input.GetKeyDown(KeyCode.C) && fightFlag == true)
            {

                fightMenu.SetActive(true);
                click.Play();
                menuFlag = true;
            }
            if (Input.GetKeyDown(KeyCode.C) && bagFlag == true)
            {
                StartCoroutine(FadeImage(true));
                bagMenu.SetActive(true);
                click.Play();
                menuFlag = true;

            }
            if (Input.GetKeyDown(KeyCode.C) && pokeFlag == true)
            {
                StartCoroutine(FadeImage(true));
                pokeMenu.SetActive(true);
                click.Play();
                menuFlag = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.X) && menuFlag == true)
        {
            if (!fightFlag)
            {
                StartCoroutine(FadeImage(true));
            }
            fightMenu.SetActive(false);
            bagMenu.SetActive(false);
            pokeMenu.SetActive(false);
            menuFlag = false;

        }

        // FIGHT ARROW KEYS
        if (!menuFlag)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && fightFlag == true)
            {
                FightShift(false);
                PokeShift(true);
                click.Play();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && fightFlag == true)
            {
                FightShift(false);
                BagShift(true);
                click.Play();
            }

            // BAG ARROW KEYS
            if (Input.GetKeyDown(KeyCode.DownArrow) && bagFlag == true)
            {
                BagShift(false);
                RunShift(true);
                click.Play();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && bagFlag == true)
            {
                BagShift(false);
                FightShift(true);
                click.Play();
            }

            // POKE ARROW KEYS
            if (Input.GetKeyDown(KeyCode.UpArrow) && pokeFlag == true)
            {
                PokeShift(false);
                FightShift(true);
                click.Play();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && pokeFlag == true)
            {
                PokeShift(false);
                RunShift(true);
                click.Play();
            }

            // RUN ARROW KEYS
            if (Input.GetKeyDown(KeyCode.UpArrow) && runFlag == true)
            {
                RunShift(false);
                BagShift(true);
                click.Play();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && runFlag == true)
            {
                RunShift(false);
                PokeShift(true);
                click.Play();
            }
        }
        
    }

    void FightShift(bool onOff)
    {
        fightFlag = onOff;
        fightButton.SetActive(onOff);
    }
    void BagShift(bool onOff)
    {
        bagFlag = onOff;
        bagButton.SetActive(onOff);
    }
    void PokeShift(bool onOff)
    {
        pokeFlag = onOff;
        pokeButton.SetActive(onOff);
    }
    void RunShift(bool onOff)
    {
        runFlag = onOff;
        runButton.SetActive(onOff);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                blackSquare.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 1; i <= 1; i += Time.deltaTime)
            {
                blackSquare.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

}