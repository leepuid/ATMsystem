using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public string userName;
    public int userMoney;
    public int userCard;

    public UserData(string name, int usermoney, int cardmoney)
    {
        userName = name;
        userMoney = usermoney;
        userCard = cardmoney;
    }
}

public class DataManager : MonoBehaviour
{
    public UserData userData;

    public void  SaveData(UserData data)
    {
        string jsonData = JsonUtility.ToJson(userData);
        File.WriteAllText(Application.persistentDataPath + "/UserData.json", jsonData);
        Debug.Log("저장되었습니다.");
    }

    public void LoadData()
    {
        string filePath = Application.persistentDataPath + "/UserData.json";

        if(File.Exists(filePath))
        {
            string jsonData  = File.ReadAllText(filePath);
            userData = JsonUtility.FromJson<UserData>(jsonData);
        }
        else
        {
            Debug.LogError("저장된 데이터가 없습니다.");
        }
    }
}
