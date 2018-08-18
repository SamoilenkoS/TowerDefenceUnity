using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {
    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turretGameObject;
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
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if(turretGameObject!=null)
        {

            return;
        }
        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turretGameObject = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        nodeRenderer.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }
}
