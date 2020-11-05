using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable {
	public Text buttonLabel;
	GoldProductionData goldProductionData;
	Gold gold;
	string playerPrefSuffix;
	string purchaseTerm;

	bool IsAffordable => this.gold.GoldAmount >= this.goldProductionData.GetActualCosts(this.Amount);

	public int Amount {
		get => PlayerPrefs.GetInt(this.goldProductionData.name+this.playerPrefSuffix, 0);
		private set => PlayerPrefs.SetInt(this.goldProductionData.name+this.playerPrefSuffix, value);
	}

	public void SetUp(GoldProductionData goldProductionData, Gold gold, string playerPrefSuffix, string purchaseTerm) {
		this.goldProductionData = goldProductionData;
		this.gold = gold;
		this.playerPrefSuffix = playerPrefSuffix;
		this.purchaseTerm = purchaseTerm;
		this.buttonLabel.text = $"{purchaseTerm} for {goldProductionData.GetActualCosts(this.Amount)}";
	}

	public void Purchase() {
		if (!this.IsAffordable) 
			return;
		this.gold.GoldAmount -= this.goldProductionData.GetActualCosts(this.Amount);
		this.Amount += 1;
		this.buttonLabel.text = $"{this.purchaseTerm} for {this.goldProductionData.GetActualCosts(this.Amount)}";
	}

	public void Update() => UpdateTextColor();
	void UpdateTextColor() => this.buttonLabel.color = this.IsAffordable ? Color.black : Color.red;
}