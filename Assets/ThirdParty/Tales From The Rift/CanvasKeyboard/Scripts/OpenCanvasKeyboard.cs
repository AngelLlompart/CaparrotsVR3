using UnityEngine;
using System.Collections;
using TMPro;

namespace TalesFromTheRift
{
	public class OpenCanvasKeyboard : MonoBehaviour 
	{
		// Canvas to open keyboard under
		public Canvas CanvasKeyboardObject;

		// Optional: Input Object to receive text 
		public GameObject inputObject;

		public void OpenKeyboard()
		{
			inputObject.GetComponent<TextMeshProUGUI>().text = "";
			CanvasKeyboard.Open(CanvasKeyboardObject, inputObject != null ? inputObject : gameObject);
		}

		public void CloseKeyboard() 
		{		
			CanvasKeyboard.Close ();
		}
	}
}