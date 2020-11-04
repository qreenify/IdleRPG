using UnityEngine;

[CreateAssetMenu]
public class GoldProductionData : ScriptableObject { 
	// private to make sure that people not accidentally use 'costs' instead of 'actualCosts'
	[SerializeField] int costs = 100;
	// this variable is not needed by any other class anyways, hide anything that's not needed, keep the public API 'clean'
	[SerializeField] float costMultiplier = 1.1f;
	// (EXCLUSIVE ARGUMENT) least amount of code / easier to use
	public float productionTime = 1f;
	// (EXCLUSIVE ARGUMENT) make sure that people do not set / write this value on a scriptable object
	[SerializeField] int productionAmount = 1;
	public int ProductionAmount => this.productionAmount;
	public Item item;
	
	public int GetActualCosts(int amount) {
		var result = this.costs * Mathf.Pow(this.costMultiplier, amount);
		return Mathf.RoundToInt(result);
	}
}

