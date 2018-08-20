using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Private fields
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    #endregion

    #region Public fields
    public NodeUI nodeUI;
    public GameObject buildEffect;
    
    #endregion

    public static BuildManager Instance;//Singleton

    #region Properties
    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }
    public bool HasEnoughMoney
    {
        get
        {
            return PlayerStats.Money >= turretToBuild.cost;
        }
    }

    #endregion

    #region Unity methods
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    #endregion

    #region Public methods

    #region Work with Turret
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    #endregion

    #region Work with Node
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    #endregion

    #endregion

}
