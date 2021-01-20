using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Linq;
using System.Runtime.CompilerServices;

public class DataManager : MonoBehaviour
{

	public TextMeshProUGUI[] NameText;
	public TextMeshProUGUI[] ProductText;
	public TextMeshProUGUI[] coinsCountText;
	public Image[] photosImage;
	public Image[] productImage;
	private int indexofDb;
	IEnumerable<UserInfo> users;

	// Use this for initialization
	void Start()
	{
		
		var ds = new DataService("dbUser.db");
		indexofDb = 6;

	ds.CreateDB ();
		
			users = ds.GetUserInfo();
		ToConsole(users, indexofDb);

	}

	private void ToConsole(IEnumerable<UserInfo> users, int countOfUsers)
	{
		countOfUsers = indexofDb;
		int i= 0;
		for(int y=countOfUsers-6;y<countOfUsers;y++)
		{
			
			ToConsole(users.ElementAt(y), i);
			if (i < 5)
				i++;
			else
				break;
		}
	}

	private void ToConsole(UserInfo usMsg, int index)
	{
		NameText[index].text+=usMsg.user_name;
    ProductText[index].text += usMsg.product_name;
    coinsCountText[index].text += usMsg.coins_count.ToString();
		productImage[index].sprite= Resources.Load(usMsg.product_name, typeof(Sprite)) as Sprite;
		photosImage[index].overrideSprite = null;
		Debug.Log(usMsg.user_name);
		StartCoroutine(DownloadImage(usMsg.user_photo_path, photosImage[index]));
		
	}
	
	public void OnNextUsers()
    {
		Debug.Log("On click next");
		for(int i = 0; i < 6; i++)
        {
			NameText[i].SetText("");
			ProductText[i].SetText("");
			coinsCountText[i].SetText("");
			
		}
		indexofDb += 6;
		ToConsole(users, indexofDb);
	}
	public void OnPrevUsers()
	{
		Debug.Log("On click preview");
		for (int i = 0; i < 6; i++)
		{
			NameText[i].SetText("");
			ProductText[i].SetText("");
			coinsCountText[i].SetText("");

		}
		indexofDb -= 6;
		ToConsole(users, indexofDb);
	}

	IEnumerator DownloadImage(string MediaUrl, Image img)
{
	UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
		
	yield return request.SendWebRequest();
		Texture2D tex = ((DownloadHandlerTexture)request.downloadHandler).texture;
		if (request.isNetworkError || request.isHttpError)
			Debug.Log(request.error);
		else
			
		img.sprite = Sprite.Create((Texture2D)tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
		
	}



private void ToConsole(string msg)
	{

		//DebugText.text += System.Environment.NewLine + msg;
		Debug.Log(msg);


	}

}
