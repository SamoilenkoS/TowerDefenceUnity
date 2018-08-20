using UnityEngine;
//TODO Add borders to axis X and Z
//TODO Make to methods from Update
public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    #region Public fields
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    #endregion
	
	private void Update ()
    {
        if(GameManager.GameIsOver)
        {
            enabled = false;
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if(!doMovement)
        {
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * scrollSpeed * Time.deltaTime * 400;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
