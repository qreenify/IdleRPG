using Common;
using Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.ResourceProduction {
	public class ResourceProducer : MonoBehaviour {
		public Data Data;
		public Text goldAmountText;
		public FloatingText popupPrefab;
		public Purchasable amount;
		public Purchasable upgrade;
		float elapsedTime;

		public void SetUp(Data data) {
			this.Data = data;
			this.gameObject.name = data.name;
			this.amount.SetUp(data, "Count");
			this.upgrade.SetUp(data, "Level");
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
			if (this.elapsedTime >= this.Data.productionTime) {
				Produce();
				this.elapsedTime -= this.Data.productionTime; // DO NOT SET TO ZERO HERE
			}
		}

		void UpdateTitleLabel() {
			this.goldAmountText.text = $"{this.amount.Amount}x {this.Data.name} Level {this.upgrade.Amount}";
		}

		void Produce() {
			if (this.amount.Amount == 0)
				return;
			var productionAmount = CalculateProductionAmount();
			productionAmount.resource.Amount += productionAmount.amount;
			var instance = Instantiate(this.popupPrefab, this.transform);
			instance.GetComponent<Text>().text = $"+{productionAmount.amount} {productionAmount.resource.name}";
		}

		ResourceAmount CalculateProductionAmount() {
			var result = new ResourceAmount();
			var productionAmount = this.Data.GetProductionAmount(this.upgrade.Amount);
			result.amount = productionAmount.amount * this.amount.Amount;
			result.resource = productionAmount.resource;
			return result;
		}
	}
}