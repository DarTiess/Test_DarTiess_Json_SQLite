using SQLite4Unity3d;
using UnityEngine;
#if !UNITY_EDITOR
using System.Collections;
using System.IO;
#endif
using System.Collections.Generic;

public class DataService 
{
   public SQLiteConnection _connection;

    public DataService (string DatabaseName)
    {
       
#if UNITY_EDITOR
        string dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        string filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if(!File.Exists(filepath)){
		Debug.Log("Database not in Persistent path");
#if UNITY_ANDROID
            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);

            while (!loadDb.isDone) { }

            File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
			var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  
			File.Copy(loadDb, filepath);
#elif UNITY_WP8
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  
			File.Copy(loadDb, filepath);
#elif UNITY_WINRT
			var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName; 
			File.Copy(loadDb, filepath);
#endif
			Debug.Log("Database written");
		}
		var dbPath = filepath;
#endif
		_connection = new SQLiteConnection(dbPath, openFlags: SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
		Debug.Log("Final PATH: " + dbPath);
	}
	public void CreateDB()
	{
		_connection.DropTable<UserInfo>();
		_connection.CreateTable<UserInfo>();

		_connection.InsertAll(new[]{
			new UserInfo{
				IdUser=12,
				user_name="Victor",
				user_photo_path="https://img.pngio.com/kids-cartoon-png-download-900951-free-transparent-avatar-avatar-state-png-900_960.jpg",
				product_name="Butter",
				product_count=14,
				coins_count=150
			},
			new UserInfo{
				IdUser=43,
				user_name="Nick",
				user_photo_path="https://im0-tub-kz.yandex.net/i?id=e5f23f848dbf4aa8320da674d9ec389a&n=13",
				product_name="Corn",
				product_count=2,
				coins_count=33
			},
			new UserInfo{
				IdUser=26,
				user_name="Veronika",
				user_photo_path="https://thumbs.dreamstime.com/b/face-expression-woman-%C3%A2%E2%82%AC%E2%80%9C-sad-unhappy-face-expression-woman-%C3%A2%E2%82%AC%E2%80%9C-sad-unhappy-female-emotions-attractive-cartoon-character-103774078.jpg",
				product_name="Money1",
				product_count=2,
				coins_count=55
			},
			new UserInfo{
				IdUser=16,
				user_name="Elise",
				user_photo_path="https://im0-tub-kz.yandex.net/i?id=bb64ac879acc8b7b8079741e5a2e3af2&n=13",
				product_name="Mushrooms",
				product_count=2,
				coins_count=55
			},
			new UserInfo{
				IdUser=4,
				user_name="Phil",
				user_photo_path="https://vk.vkfaces.com/830508/v830508499/96bbd/zLwPllZkF9o.jpg",
				product_name="Wheat",
				product_count=2,
				coins_count=55
			},
			new UserInfo{
				IdUser=64,
				user_name="Kate",
				user_photo_path="https://w7.pngwing.com/pngs/148/706/png-transparent-user-avatar-%D0%90%D0%B2%D0%B0%D1%82%D0%B0%D1%80%D0%B8%D1%8F-official-cat-wiki-others-child-black-hair-sticker.png",
				product_name="Money1",
				product_count=2,
				coins_count=55
			},
			new UserInfo{
				IdUser=12,
				user_name="Victory",
				user_photo_path="https://yt3.ggpht.com/a/AATXAJxhUSPIGuR119kTjmverq3XB8EfPx_S1h6Rsbv7NQ=s900-c-k-c0xffffffff-no-rj-mo",
				product_name="Butter",
				product_count=14,
				coins_count=150
			},
			new UserInfo{
				IdUser=43,
				user_name="John",
				user_photo_path="https://www.vippng.com/png/detail/134-1343947_png-file-svg-installer-icon.png",
				product_name="Corn",
				product_count=2,
				coins_count=33
			},
			new UserInfo{
				IdUser=26,
				user_name="Magy",
				user_photo_path="http://cdn.onlinewebfonts.com/svg/download_50978.png",
				product_name="Money2",
				product_count=2,
				coins_count=55
			},
			new UserInfo{
				IdUser=16,
				user_name="Tiffany",
				user_photo_path="https://im0-tub-ru.yandex.net/i?id=dc90875a913641bd0b05f52fc9cb04a7&ref=rim&n=33&w=188&h=188",
				product_name="Butter",
				product_count=2,
				coins_count=55
			},
			new UserInfo{
				IdUser=4,
				user_name="Mike",
				user_photo_path="https://thumbs.dreamstime.com/b/icon-male-teacher-flat-style-vector-illustration-school-concept-81008535.jpg",
				product_name="Mushrooms",
				product_count=2,
				coins_count=55
			},new UserInfo{
				IdUser=4,
				user_name="Bred",
				user_photo_path="https://im0-tub-ru.yandex.net/i?id=4309b46fe042817d74973e78fb9ab07c&ref=rim&n=33&w=161&h=188",
				product_name="Wheat",
				product_count=2,
				coins_count=55
			}

		});
		
	}
	public IEnumerable<UserInfo> GetUserInfo()
	{
		return _connection.Table<UserInfo>();
	}

	public UserInfo Getfirst()
	{
		return _connection.Table<UserInfo>().Where(x => x.IdUser == 111).FirstOrDefault();
	}

}
