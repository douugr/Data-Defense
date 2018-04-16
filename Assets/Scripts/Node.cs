using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
	public Color hoverColor;
	private Renderer rend;
	private Color startColor;
	private GameObject turret;
	public Vector3 offset;
	BuildManager buildManager;
	
	void Start()
	{
		rend = 	GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	void OnMouseDown()
	{
		if(buildManager.GetTurretToBuild() == null)
			return;

		if(turret != null)
		{
			Debug.Log("There's a Turret Here!");
			return;
		}
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = (GameObject)Instantiate(turretToBuild, transform.position+offset, transform.rotation);

	}

	void OnMouseEnter()
	{	
		if(EventSystem.current.IsPointerOverGameObject())
			return;

		if(buildManager.GetTurretToBuild() == null)
			return;
		rend.material.color = hoverColor;
	}
	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
