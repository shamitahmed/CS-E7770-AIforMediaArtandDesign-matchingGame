using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject panelGame;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

}
