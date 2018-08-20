using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    #region Public fields
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    #endregion

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    #region Public methods
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    #endregion

}
