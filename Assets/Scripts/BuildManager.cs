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
    public GameObject buildEffect;
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
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject buildEffectGameObject = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffectGameObject, 5f);
        GameObject turretGameObject = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turretGameObject = turretGameObject;
    }
}
