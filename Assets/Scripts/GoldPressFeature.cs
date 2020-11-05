using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GoldPressFeature {
	public Text purchaseButtonLabel;
	GoldProductionData goldProductionData;
	Resource gold;
	
	bool IsAffordable => this.gold.GoldAmount >= this.goldProductionData.GetActualCosts(this.Amount);
	
	public int Amount {
		get => PlayerPrefs.GetInt(this.goldProductionData.name, 0);
		private set => PlayerPrefs.SetInt(this.goldProductionData.name, value);
	}
	
	public void SetUp(GoldProductionData goldProductionData, Resource gold) {
		this.gold = gold;
		this.goldProductionData = goldProductionData;
		this.purchaseButtonLabel.text = $"Purchase for {this.goldProductionData.GetActualCosts(this.Amount)}";
	}
	
	public void Purchase() {
		if (this.IsAffordable) {
			this.gold.GoldAmount -= this.goldProductionData.GetActualCosts(this.Amount);
			this.Amount += 1;
			this.purchaseButtonLabel.text = $"Purchase for {this.goldProductionData.GetActualCosts(this.Amount)}";
		}
	}
	
	void UpdateTextColor() {
		this.purchaseButtonLabel.color = this.IsAffordable ? Color.black : Color.red;
	}
}