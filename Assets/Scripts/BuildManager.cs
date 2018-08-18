using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    private GameObject turretToBuild;
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
    public GameObject anotherTurretPrefab;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }
}
