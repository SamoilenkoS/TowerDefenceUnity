using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    private TurretBlueprint turretToBuild;
    public static BuildManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }
    public GameObject standartTurretPrefab;
    public GameObject missileLauncherPrefab;
    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    internal void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        //GameObject turretToBuild = Instance.GetTurretToBuild();
       GameObject turretGameObject = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turretGameObject = turretGameObject;
    }
}
