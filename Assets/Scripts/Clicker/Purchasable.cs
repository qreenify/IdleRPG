using System;
using Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker {
	[Serializable]
	public class Purchasable {
		public Text buttonLabel;
		ResourceProductionData resourceProductionData;
		Resource resource;
		string productId;

		bool IsAffordable => this.resource.Amount >= this.resourceProductionData.GetActualCosts(this.Amount);

		public int Amount {
			get => PlayerPrefs.GetInt(this.resourceProductionData.name+"_"+this.productId, 0);
			private set => PlayerPrefs.SetInt(this.resourceProductionData.name+"_"+this.productId, value);
		}

		public void SetUp(ResourceProductionData resourceProductionData, Resource resource, string productId) {
			this.resourceProductionData = resourceProductionData;
			this.resource = resource;
			this.productId = productId;
			this.buttonLabel.text = $"Add {productId} for {resourceProductionData.GetActualCosts(this.Amount)} {resource.name}";
		}

		public void Purchase() {
			if (!this.IsAffordable) 
				return;
			this.resource.Amount -= this.resourceProductionData.GetActualCosts(this.Amount);
			this.Amount += 1;
			this.buttonLabel.text = $"Add {this.productId} for {this.resourceProductionData.GetActualCosts(this.Amount)} {this.resource.name}";
		}

		public void Update() => UpdateTextColor();
		void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
	}
}