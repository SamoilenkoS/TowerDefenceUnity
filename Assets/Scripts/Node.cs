using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("Optional")]
    public GameObject turretGameObject;

    private Renderer nodeRenderer;
    private Color startColor;
    BuildManager buildManager;
    void Start()
    {
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
        buildManager = BuildManager.Instance;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if(turretGameObject!=null)
        {

            return;
        }
        buildManager.BuildTurretOn(this);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        nodeRenderer.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
