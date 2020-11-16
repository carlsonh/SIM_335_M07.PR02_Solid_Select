using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class CheckerboardSelectionResponse : MonoBehaviour, ISelectionResponse
{    
	[SerializeField] public Material highlightMaterial;
	[SerializeField] public Material defaultMaterial;
	[SerializeField] private GameObject nameTag;

	private GameObject nameTagInstance;
	public void OnSelect(Transform selection)
	{
		
		var selectionRenderer = selection.GetComponent<Renderer>();
		if (selectionRenderer != null)
		{
			selectionRenderer.material = this.highlightMaterial;
			nameTagInstance = GameObject.Instantiate(nameTag, (selection.position + Vector3.up*1.5f), Quaternion.identity);
			nameTagInstance.GetComponentInChildren<TextMeshProUGUI>().text = selection.gameObject.name;
			nameTagInstance.GetComponentInChildren<LookAtConstraint>().AddSource(new ConstraintSource{sourceTransform = Camera.main.transform, weight = 1});
		}
	}

	public void OnDeselect(Transform selection)
	{
		var selectionRenderer = selection.GetComponent<Renderer>();
		if (selectionRenderer != null)
		{
			selectionRenderer.material = this.defaultMaterial;
			Destroy(nameTagInstance);
		}
	}
}