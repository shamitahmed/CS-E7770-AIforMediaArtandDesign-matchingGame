using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public int ID;
    public bool isImage;
    public bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => { SelectedCallback(); });
    }
    public void SelectedCallback()
    {
        if (!isSelected)
        {
            isSelected = true;

            if (!isImage)
            {
                GameManager.instance.txtID = ID;
            }
            if (isImage)
            {
                GameManager.instance.imgID = ID;
                GameManager.instance.CheckMatchingSelection(GameManager.instance.txtID,ID);
            }
        }
        else if(isSelected)
        {
            isSelected = false;

        }

    }
}
