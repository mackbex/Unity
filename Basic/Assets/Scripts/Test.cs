using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    [SerializeField] private Text txt_money;
    [SerializeField] private InputField input_money;


    private int account;

    public void deposit()
    {
        account += int.Parse(input_money.text);

        txt_money.text = account.ToString();
    }

    public void withdraw()
    {
        account -= int.Parse(input_money.text);

        txt_money.text = account.ToString();
    }

}
