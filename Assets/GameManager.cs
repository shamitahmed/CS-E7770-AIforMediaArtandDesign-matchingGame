using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using OpenAI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject panelGame;
    public GameObject btnPlay;
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
            Debug.LogError("match");
        }
        else
        {
            Debug.LogError("wrong");
        }
    }
}
