using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    #region Private fields
    private Renderer nodeRenderer;
    private Color startColor;
    private BuildManager buildManager;

    #endregion

    #region Public fields

    #region Hidden
    [HideInInspector]
    public GameObject turretGameObject;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded;

    #endregion

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    #endregion

    #region Private methods

    #region Unity methods
    private void Start()
    {
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
        buildManager = BuildManager.Instance;
        isUpgraded = false;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turretGameObject != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasEnoughMoney)
        {
            nodeRenderer.material.color = hoverColor;
        }
        else
        {
            nodeRenderer.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }

    #endregion

    private void BuildTurret(TurretBlueprint turretBlueprint)
    {
        if (PlayerStats.Money < turretBlueprint.cost)
        {
            return;
        }
        this.turretBlueprint = turretBlueprint;
        PlayerStats.Money -= turretBlueprint.cost;
        GameObject buildEffectGameObject = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectGameObject, 5f);
        GameObject turretGameObject = Instantiate(turretBlueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turretGameObject = turretGameObject;
    }

    #endregion

    #region Public methods

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost || isUpgraded)
        {
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        Destroy(this.turretGameObject);//old
        GameObject turretGameObject = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);//new
        GameObject buildEffectGameObject = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectGameObject, 5f);
        isUpgraded = true;
        this.turretGameObject = turretGameObject;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turretGameObject);
        turretBlueprint = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    #endregion
}
