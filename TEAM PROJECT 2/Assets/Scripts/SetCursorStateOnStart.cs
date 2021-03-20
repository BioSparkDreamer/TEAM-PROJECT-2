using UnityEngine;
/// <summary>
/// Place this on an empty object in scenes that do not contain <see cref="MouseLook"/>
/// This will set the initial cursor lockstate to <see cref="_cursorModeOnStart"/>
/// </summary>
public class SetCursorStateOnStart : MonoBehaviour 
{
	public CursorLockMode _cursorModeOnStart;

	public void Start()
	{
		Cursor.lockState = _cursorModeOnStart;
	}
}
