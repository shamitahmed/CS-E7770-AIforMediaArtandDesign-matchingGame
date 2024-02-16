using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenAI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject panelGame;
    public GameObject btnPlay;
    public Button btnRestart;
    public GameObject panelGPT;
    public GameObject panelDalle;

    public Button[] txtNames;
    public Button[] btnImages;

    public int txtID;
    public int imgID;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        panelGame.SetActive(false);
        btnPlay.GetComponent<Button>().onClick.AddListener(() => { BtnPlayCallback(); });  
        btnRestart.onClick.AddListener(() => { BtnRestart(); });
    }
    public void BtnPlayCallback()
    {
        btnPlay.gameObject.SetActive(false );
        GameManager.instance.panelGPT.SetActive(false);
        GameManager.instance.panelDalle.SetActive(false);
        panelGame.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            txtNames[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = NameExtraction.instance.outputNames[i];
            btnImages[i].GetComponent<Image>().sprite = DallE.instance.images[i].sprite;

            txtNames[i].GetComponent<ButtonController>().ID = i;
            btnImages[i].GetComponent<ButtonController>().ID = i;
        }
    }
    public void CheckMatchingSelection(int id1, int id2)
    {
        if(id1== id2)
        {
            //its a match   
            txtNames[id1].gameObject.SetActive(false);
            btnImages[id2].gameObject.SetActive(false);
        }
        else
        {
            //reset buttons
            txtNames[id1].GetComponent<ButtonController>().isSelected= false;
            btnImages[id2].GetComponent<ButtonController>().isSelected=false;
        }
    }
    public void BtnRestart()
    {
        SceneManager.LoadScene("main");
    }
}
