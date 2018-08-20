using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    #region Public fields
    public int cost;
    public int upgradeCost;
    public GameObject prefab;
    public GameObject upgradedPrefab;

    #endregion

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
