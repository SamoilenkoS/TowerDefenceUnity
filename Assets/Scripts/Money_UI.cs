using UnityEngine;
using UnityEngine.UI;

public class Money_UI : MonoBehaviour {
    public Text moneyText;
    void Update()
    {
        moneyText.text = PlayerStats.Money.ToString()+"$";
    }
}
