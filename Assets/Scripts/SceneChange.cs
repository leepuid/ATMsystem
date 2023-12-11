using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Deposit()
    {
        SceneManager.LoadScene("DepositScene");
    }

    public void Withdraw()
    {
        SceneManager.LoadScene("WithdrawScene");
    }
}
