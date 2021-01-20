using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteUserInfo : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI ProductText;
    public TextMeshProUGUI coinsCountText;
    public Image photosImage;
    public Image productImage;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDelete()
    {
        string name = NameText.text;
        Debug.Log("Nametext = " + NameText.text);
        NameText.SetText("");
        ProductText.SetText("");
        coinsCountText.SetText("");
        JSONDataManager.jsonData.DeleteUser(name);
       
    }
}
