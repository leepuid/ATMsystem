using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class atmManager : MonoBehaviour
{
    public static atmManager _instance;

    public TextMeshProUGUI userMoney;
    public TextMeshProUGUI cardMoney;
    public TextMeshProUGUI userName;
    [SerializeField] private GameObject insufficient;
    [SerializeField] private GameObject _inputField;
    int money = 0;
    int card = 0;
    int moveMoney = 0;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        insufficient.SetActive(false);

        userName.text = SceneChange.instance.userName.text;
        money = int.Parse(SceneChange.instance.userMoney.text);
        card = int.Parse(SceneChange.instance.cardMoney.text);

        userMoney.text = money.ToString();
        cardMoney.text = card.ToString();
    }

    // 버튼 입출금
    public void deposit_withdraw()
    {
        moveMoney = 0;
        GameObject clickobject = EventSystem.current.currentSelectedGameObject;
        moveMoney = int.Parse(clickobject.GetComponentInChildren<TextMeshProUGUI>().text);

        if (SceneManager.GetActiveScene().name == "DepositScene")
        {
            if (moveMoney > money)
            {
                // 선택한 금액보다 현금이 적기 때문
                insufficient.SetActive(true);
            }
            else if (money >= moveMoney)
            {
                money -= moveMoney;
                card += moveMoney;
            }
        }
        else if(SceneManager.GetActiveScene().name == "WithdrawScene")
        {
            if (moveMoney > card)
            {
                // 선택한 금액보다 카드 금액이 적기 때문
                insufficient.SetActive(true);
            }
            else if (moveMoney <= card)
            {
                money += moveMoney;
                card -= moveMoney;
            }
        }
        userMoney.text = money.ToString();
        cardMoney.text = card.ToString();
    }

    // 입력 입출금
    public void Input_deposit_withdraw()
    {
        moveMoney = 0;
        if (_inputField != null && _inputField.GetComponent<TMP_InputField>() != null)
        {
            moveMoney = int.Parse(_inputField.GetComponent<TMP_InputField>().text);
        }
        else
        {
            print("실행되지 않음");
        }

        if (SceneManager.GetActiveScene().name == "DepositScene")
        {
            if (moveMoney > money)
            {
                // 선택한 금액보다 현금이 적기 때문
                insufficient.SetActive(true);
            }
            else if (money >= moveMoney)
            {
                money -= moveMoney;
                card += moveMoney;
            }
        }
        else if (SceneManager.GetActiveScene().name == "WithdrawScene")
        {
            if (moveMoney > card)
            {
                // 선택한 금액보다 카드 금액이 적기 때문
                insufficient.SetActive(true);
            }
            else if (moveMoney <= card)
            {
                money += moveMoney;
                card -= moveMoney;
            }
        }
        _inputField.GetComponent<TMP_InputField>().text = "";
        userMoney.text = money.ToString();
        cardMoney.text = card.ToString();
    }

    public void SceneBack()
    {
        SceneChange.instance.SaveData(userName.text, money, card);
        SceneManager.LoadScene("StartScene");
    }
    public void InsufficientBalance()
    {
        insufficient.SetActive(false);
    }
}
