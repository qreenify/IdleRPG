using System;
using Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker {
	[Serializable]
	public class Purchasable {
		public Text buttonLabel;
		ResourceProduction.Data data;
		string productId;

		bool IsAffordable {
			get {
				var costs = this.data.GetActualCosts(this.Amount);
				return costs.resource.Amount >= costs.amount;
			}
		}

		public int Amount {
			get => PlayerPrefs.GetInt(this.data.name+"_"+this.productId, 0);
			private set => PlayerPrefs.SetInt(this.data.name+"_"+this.productId, value);
		}

		public void SetUp(ResourceProduction.Data data, string productId) {
			this.data = data;
			this.productId = productId;
			UpdateCostLabel();
		}

		public void Purchase() {
			if (!this.IsAffordable) 
				return;
			var costsResourceAmount = this.data.GetActualCosts(this.Amount);
			costsResourceAmount.resource.Amount -= costsResourceAmount.amount;
			this.Amount += 1;
			UpdateCostLabel();
		}

		void UpdateCostLabel() {
			var updatedCosts = this.data.GetActualCosts(this.Amount);
			this.buttonLabel.text = $"Add {this.productId} for {updatedCosts.amount} {updatedCosts.resource.name}";
		}

		public void Update() => UpdateTextColor();
		void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
	}
}