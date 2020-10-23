using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class GoldProductionData : ScriptableObject {
	public string name = "GoldProducer";
	public int productionAmount = 1;
	public int costs = 100;
	public float productionTime = 1f;
}

