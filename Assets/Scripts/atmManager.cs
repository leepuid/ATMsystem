using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class atmManager : MonoBehaviour
{
    public TextMeshProUGUI userMoney;
    public TextMeshProUGUI cardMoney;
    [SerializeField] private GameObject _inputField;
    int money;
    int card;
    int moveMoney;

    // Start is called before the first frame update
    void Start()
    {
        money = int.Parse(userMoney.text);
        card = int.Parse(cardMoney.text);
    }

    public void deposit()
    {
        moveMoney = 0;
        GameObject clickobject = EventSystem.current.currentSelectedGameObject;
        moveMoney = int.Parse(clickobject.GetComponentInChildren<TextMeshProUGUI>().text);

        if (moveMoney > money)
        {
            // 선택한 금액보다 현금이 적기 때문
        }
        else if (money >= moveMoney)
        {
            money -= moveMoney;
            card += moveMoney;
        }

        userMoney.text = money.ToString();
        cardMoney.text = card.ToString();
    }

    public void InputDeposit()
    {
        moveMoney = 0;
        moveMoney = int.Parse(_inputField.GetComponent<TMP_InputField>().text);

        if (moveMoney > money)
        {
            // 선택한 금액보다 현금이 적기 때문
        }
        else if (money >= moveMoney)
        {
            money -= moveMoney;
            card += moveMoney;
        }

        userMoney.text = money.ToString();
        cardMoney.text = card.ToString();
    }
}
