using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    #region Public fields
    public Text upgradeCost;
    public Text sellAmount;
    public GameObject UI;
    public Button upgradeButton;

    #endregion

    #region Public methods
    public void SetTarget(Node target)
    {
        this.target = target;
        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost.ToString() + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        sellAmount.text = target.turretBlueprint.GetSellAmount() + "$";
        transform.position = target.GetBuildPosition();
        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.Instance.DeselectNode();
    }

    #endregion

}
