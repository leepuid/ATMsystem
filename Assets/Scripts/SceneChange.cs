using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;

    public TextMeshProUGUI userMoney;
    public TextMeshProUGUI cardMoney;
    public TextMeshProUGUI userName;

    // 기본값
    int userMoney_start = 100000;
    int cardMoney_start = 50000;
    string user_name = "Lee";

    // 저장값
    int save_userMoney;
    int save_cardMoney;
    string save_userName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
            LoadData();
    }
    public void Deposit()
    {
        SaveData(save_userName, save_userMoney, save_cardMoney);
        SceneManager.LoadScene("DepositScene");
    }

    public void Withdraw()
    {
        SaveData(save_userName, save_userMoney, save_cardMoney);
        SceneManager.LoadScene("WithdrawScene");
    }

    public void SaveData(string name, int user, int card)
    {
        save_userName = name;
        save_userMoney = user;
        save_cardMoney = card;

        PlayerPrefs.SetString("user_name", save_userName);
        PlayerPrefs.SetInt("userMoney", save_userMoney);
        PlayerPrefs.SetInt("cardMoney", save_cardMoney);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        save_userName = PlayerPrefs.GetString("user_name");
        save_userMoney = PlayerPrefs.GetInt("userMoney");
        save_cardMoney = PlayerPrefs.GetInt("cardMoney");

        if (save_userMoney == 0)
        {
            userName.text = user_name;
            userMoney.text = userMoney_start.ToString();
            cardMoney.text = cardMoney_start.ToString();
            SaveData(user_name, userMoney_start, cardMoney_start);
            print("시작저장!!");
        }
        else
        {
            userName.text = save_userName;
            userMoney.text = save_userMoney.ToString();
            cardMoney.text = save_cardMoney.ToString();
        }
    }
}
