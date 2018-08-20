using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Public fields

    #region Static fields
    public static int Money;
    public static int Lives;
    public static int Rounds;

    #endregion

    public int startLives = 10;
    public int startMoney = 400;

    #endregion

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }

}
