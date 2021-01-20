using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class JSONDataManager : MonoBehaviour
{
    public TextMeshProUGUI[] NameText;
    public TextMeshProUGUI[] ProductText;
    public TextMeshProUGUI[] coinsCountText;
    public Image[] photosImage;
    public Image[] productImage;
    private int indexofDb;
    string inputString;
    List<UserInfo> users;
    private string file_path;
    public InputField input_name;
    public static JSONDataManager jsonData;

    void Awake()
    {
        jsonData = this;
        //#if UNITY_ANDROID && !UNITY_EDITOR
        file_path = Path.Combine(Application.persistentDataPath, "userInfo.json");
        //#endif
        //   file_path = Path.Combine(Application.dataPath, "DataBase/userInfo.json");
        if (!System.IO.File.Exists(file_path))
            CreateJson();
        Debug.Log(file_path);

    }
    // Start is called before the first frame update
    void Start()
    {

        indexofDb = 6;
        ReadFile();
    }

    public void Refresh()
    {
        inputString = System.IO.File.ReadAllText(file_path);
        users = JsonHelper.FromJson<UserInfo>(inputString);
        indexofDb = 6;
        for (int i = 0; i < 6; i++)
        {
            NameText[i].SetText("");
            ProductText[i].SetText("");
            coinsCountText[i].SetText("");
        }
        ToConsole(users, indexofDb);
        Debug.Log("refreshhhhhh");
    }
    public void ReadFile()
    {
        inputString = System.IO.File.ReadAllText(file_path);
        users = JsonHelper.FromJson<UserInfo>(inputString);

        List<UserInfo> jsonObject = JsonHelper.FromJson<UserInfo>(inputString);
        foreach (var row in jsonObject)
            Debug.Log(row.user_name);
        ToConsole(users, indexofDb);
    }
    public void DeleteUser(string name)
    {
        Debug.Log("Delete start");
        List<UserInfo> jsonObject = JsonHelper.FromJson<UserInfo>(inputString);
        foreach (var row in jsonObject)
        {     
            if (row.user_name == name)
            {
                users.Remove(row);
            }
        }
        
        string newadd = JsonHelper.ToJson(jsonObject);
        System.IO.File.WriteAllText(file_path, newadd);
        Debug.Log("Deleteeeeeeee");
    }
    public void AddUser()
    {      
        Debug.Log(users.Count);

        UserInfo us = new UserInfo();
        us.IdUser = 434433;
        us.user_name = "SPANCH";
        us.user_photo_path = "https://cdn.clipart.email/ccddfec100b66b659165d02fec717ec1_spongebob-squarepants-television-show-meme-female-boi-png-pngwave_910-750.png";
        us.product_name = "Butter";
        us.product_count = 55555;
        us.coins_count = 22222223;

        users.Add(us);
        string newadd = JsonHelper.ToJson(users);
        System.IO.File.WriteAllText(file_path, newadd);
        Debug.Log("add new user");
    }
    void CreateJson()
    {
        List<UserInfo> user_s = new List<UserInfo>{

       new UserInfo {
            IdUser = 1,
            coins_count = 150,
            product_count = 14,
            product_name = "Butter",
            user_name = "Victor",
            user_photo_path = "https://img.pngio.com/kids-cartoon-png-download-900951-free-transparent-avatar-avatar-state-png-900_960.jpg"
        },

       new UserInfo {
            IdUser = 2,
            coins_count = 20,
            product_count = 32,
            product_name = "Corn",
            user_name = "Nick",
            user_photo_path = "https://im0-tub-kz.yandex.net/i?id=e5f23f848dbf4aa8320da674d9ec389a&n=13"
        },
        new UserInfo {
            IdUser = 3,
            coins_count = 32,
            product_count = 20,
            product_name = "Money1",
            user_name = "Veronika",
            user_photo_path = "https://thumbs.dreamstime.com/b/face-expression-woman-%C3%A2%E2%82%AC%E2%80%9C-sad-unhappy-face-expression-woman-%C3%A2%E2%82%AC%E2%80%9C-sad-unhappy-female-emotions-attractive-cartoon-character-103774078.jpg"
        },
        new UserInfo {
            IdUser = 4,
            coins_count = 55,
            product_count = 11,
            product_name = "Mushrooms",
            user_name = "Elise",
            user_photo_path = "https://im0-tub-kz.yandex.net/i?id=bb64ac879acc8b7b8079741e5a2e3af2&n=13"
        },
        new UserInfo {
        IdUser= 5,
        coins_count= 41,
        product_count= 35,
        product_name= "Wheat",
        user_name= "Phil",
        user_photo_path= "https://vk.vkfaces.com/830508/v830508499/96bbd/zLwPllZkF9o.jpg"
    },
    new UserInfo {
         IdUser = 6,
        coins_count= 71,
        product_count= 10,
       product_name= "Money1",
        user_name= "Kate",
        user_photo_path= "https://w7.pngwing.com/pngs/148/706/png-transparent-user-avatar-%D0%90%D0%B2%D0%B0%D1%82%D0%B0%D1%80%D0%B8%D1%8F-official-cat-wiki-others-child-black-hair-sticker.png"
    },
     new UserInfo{
         IdUser = 7,
       coins_count=3,
        product_count= 18,
        product_name= "Money1",
         user_name= "Victory",
        user_photo_path= "https://yt3.ggpht.com/a/AATXAJxhUSPIGuR119kTjmverq3XB8EfPx_S1h6Rsbv7NQ=s900-c-k-c0xffffffff-no-rj-mo"
    },
     new UserInfo{
         IdUser = 8,
         coins_count = 30,
         product_count = 36,
         product_name = "Corn",
         user_name = "John",
         user_photo_path = "https://www.vippng.com/png/detail/134-1343947_png-file-svg-installer-icon.png"
    },
    new UserInfo {
        IdUser = 9,
        coins_count = 10,
        product_count = 21,
        product_name = "Money2",
        user_name = "Magy",
        user_photo_path = "http://cdn.onlinewebfonts.com/svg/download_50978.png"
    },
     new UserInfo{
         IdUser = 10,
         coins_count = 95,
         product_count = 14,
         product_name = "Butter",
         user_name = "Tiffany",
         user_photo_path = "https://im0-tub-ru.yandex.net/i?id=dc90875a913641bd0b05f52fc9cb04a7&ref=rim&n=33&w=188&h=188"
    },
     new UserInfo{
         IdUser = 11,
         coins_count = 26,
         product_count = 23,
         product_name = "Mushrooms",
         user_name = "Mike",
         user_photo_path = "https://thumbs.dreamstime.com/b/icon-male-teacher-flat-style-vector-illustration-school-concept-81008535.jpg"
    },
    new UserInfo {
        IdUser = 12,
        coins_count = 30,
        product_count = 36,
        product_name = "Wheat",
        user_name = "Bred",
        user_photo_path = "https://im0-tub-ru.yandex.net/i?id=4309b46fe042817d74973e78fb9ab07c&ref=rim&n=33&w=161&h=188"
    },
     new UserInfo{
         IdUser = 13,
         coins_count = 71,
         product_count = 10,
         product_name = "Money1",
         user_name = "Kate",
         user_photo_path = "https://w7.pngwing.com/pngs/148/706/png-transparent-user-avatar-%D0%90%D0%B2%D0%B0%D1%82%D0%B0%D1%80%D0%B8%D1%8F-official-cat-wiki-others-child-black-hair-sticker.png"
    },
     new UserInfo{
         IdUser = 14,
         coins_count = 3,
         product_count = 18,
         product_name = "Money1",
         user_name = "Victory",
         user_photo_path = "https://yt3.ggpht.com/a/AATXAJxhUSPIGuR119kTjmverq3XB8EfPx_S1h6Rsbv7NQ=s900-c-k-c0xffffffff-no-rj-mo"
    },
     new UserInfo{
         IdUser = 15,
         coins_count = 30,
         product_count = 36,
         product_name = "Corn",
         user_name = "John",
         user_photo_path = "https://www.vippng.com/png/detail/134-1343947_png-file-svg-installer-icon.png"
    },
     new UserInfo{
         IdUser = 16,
         coins_count = 10,
         product_count = 21,
         product_name = "Money2",
         user_name = "Magy",
         user_photo_path = "http://cdn.onlinewebfonts.com/svg/download_50978.png"
    },
     new UserInfo{
         IdUser = 17,
         coins_count = 95,
         product_count = 14,
         product_name = "Butter",
         user_name = "Tiffany",
         user_photo_path = "https://im0-tub-ru.yandex.net/i?id=dc90875a913641bd0b05f52fc9cb04a7&ref=rim&n=33&w=188&h=188"
    },
     new UserInfo{
         IdUser = 18,
         coins_count = 26,
         product_count = 23,
         product_name = "Mushrooms",
         user_name = "Mike",
         user_photo_path = "https://thumbs.dreamstime.com/b/icon-male-teacher-flat-style-vector-illustration-school-concept-81008535.jpg"
    },
    new UserInfo {
        IdUser = 19,
        coins_count=30,
        product_count = 36,
        product_name="Wheat",
        user_name = "Bred",
        user_photo_path= "https://im0-tub-ru.yandex.net/i?id=4309b46fe042817d74973e78fb9ab07c&ref=rim&n=33&w=161&h=188"
    }
    };

        inputString = JsonHelper.ToJson(user_s);
        System.IO.File.WriteAllText(file_path, inputString);

    }

    private void ToConsole(IEnumerable<UserInfo> users, int countOfUsers)
    {
       
        countOfUsers = indexofDb;
        int i = 0;
        for (int y = countOfUsers - 6; y < countOfUsers; y++)
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
        NameText[index].text += usMsg.user_name;
        ProductText[index].text += usMsg.product_name;
        coinsCountText[index].text += usMsg.coins_count.ToString();
        productImage[index].sprite = Resources.Load(usMsg.product_name, typeof(Sprite)) as Sprite;
        photosImage[index].overrideSprite = null;
       
        StartCoroutine(DownloadImage(usMsg.user_photo_path, photosImage[index]));
        
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
    public void OnNextUsers()
    {
       Debug.Log("On click next"); 
        indexofDb += 6;
        
        for (int i = 0; i < 6; i++)
        {
            NameText[i].SetText("");
            ProductText[i].SetText("");
            coinsCountText[i].SetText("");
        }
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
}
