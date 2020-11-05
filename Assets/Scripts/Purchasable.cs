using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable {
	public Text buttonLabel;
	GoldProductionData goldProductionData;
	Gold gold;
	string productId;

	bool IsAffordable => this.gold.GoldAmount >= this.goldProductionData.GetActualCosts(this.Amount);

	public int Amount {
		get => PlayerPrefs.GetInt(this.goldProductionData.name+"_"+this.productId, 0);
		private set => PlayerPrefs.SetInt(this.goldProductionData.name+"_"+this.productId, value);
	}

	public void SetUp(GoldProductionData goldProductionData, Gold gold, string productId) {
		this.goldProductionData = goldProductionData;
		this.gold = gold;
		this.productId = productId;
		this.buttonLabel.text = $"Add {productId} for {goldProductionData.GetActualCosts(this.Amount)}";
	}

	public void Purchase() {
		if (!this.IsAffordable) 
			return;
		this.gold.GoldAmount -= this.goldProductionData.GetActualCosts(this.Amount);
		this.Amount += 1;
		this.buttonLabel.text = $"Add {this.productId} for {this.goldProductionData.GetActualCosts(this.Amount)}";
	}

	public void Update() => UpdateTextColor();
	void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
}