using Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Clicker {
	public class ResourceProducer : MonoBehaviour {
		[FormerlySerializedAs("GoldProductionData")] public ResourceProductionData ResourceProductionData;
		public Text goldAmountText;
		public FloatingText popupPrefab;
		public Purchasable amount;
		public Purchasable upgrade;
		float elapsedTime;

		public void SetUp(ResourceProductionData resourceProductionData) {
			this.ResourceProductionData = resourceProductionData;
			this.gameObject.name = resourceProductionData.name;
			this.amount.SetUp(resourceProductionData, resourceProductionData.costsResource, "Count");
			this.upgrade.SetUp(resourceProductionData, resourceProductionData.costsResource, "Level");
		}

		public void Purchase() => this.amount.Purchase();
		public void Upgrade() => this.upgrade.Purchase();

		void Update() {
			UpdateProduction();
			UpdateTitleLabel();
			this.amount.Update();
			this.upgrade.Update();
		}

		void UpdateProduction() {
			this.elapsedTime += Time.deltaTime;
			if (this.elapsedTime >= this.ResourceProductionData.productionTime) {
				Produce();
				this.elapsedTime -= this.ResourceProductionData.productionTime; // DO NOT SET TO ZERO HERE
			}
		}

		void UpdateTitleLabel() {
			this.goldAmountText.text = $"{this.amount.Amount}x {this.ResourceProductionData.name} Level {this.upgrade.Amount}";
		}

		void Produce() {
			if (this.amount.Amount == 0)
				return;
			this.ResourceProductionData.productionResource.Amount += Mathf.RoundToInt(CalculateProductionAmount());
			var instance = Instantiate(this.popupPrefab, this.transform);
			instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()} {this.ResourceProductionData.productionResource.name}";
		}

		float CalculateProductionAmount() {
			return this.ResourceProductionData.GetProductionAmount(this.upgrade.Amount) * this.amount.Amount;
		}
	}
}