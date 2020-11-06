using UnityEngine;
using UnityEngine.Serialization;

namespace Clicker {
	public class ResourceProductionSetup : MonoBehaviour {

		[FormerlySerializedAs("goldProductionUnits")] public ResourceProductionData[] resourceProductionUnits;
		[FormerlySerializedAs("goldProductionUnitPrefab")] public ResourceProducer ResourceProductionUnitPrefab;

		void Start() {
			foreach (var productionUnit in this.resourceProductionUnits) {
				var instance = Instantiate(this.ResourceProductionUnitPrefab, this.transform);
				instance.SetUp(productionUnit);
			}
		}
	}
}