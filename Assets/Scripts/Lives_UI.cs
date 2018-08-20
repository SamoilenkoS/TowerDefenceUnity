using UnityEngine;
using UnityEngine.UI;

public class Lives_UI : MonoBehaviour
{
    public Text livesText;
	
	private void Update ()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";	
	}
}
