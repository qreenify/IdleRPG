using UnityEngine;
using UnityEngine.UI;

public class Purchasable {
	public Text purchaseButtonLabel;
	GoldProductionData goldProductionData;
	Gold gold;
	bool IsAffordable => this.gold.GoldAmount >= this.goldProductionData.GetActualCosts(this.Amount);

	public int Amount {
		get => PlayerPrefs.GetInt(this.goldProductionData.name, 0);
		private set {
			PlayerPrefs.SetInt(this.goldProductionData.name, value);
		}
	}

	public void SetUp(GoldProductionData goldProductionData, Gold gold) {
		this.goldProductionData = goldProductionData;
		this.gold = gold;
		this.purchaseButtonLabel.text = $"Purchase for {goldProductionData.GetActualCosts(this.Amount)}";
	}

	public void Purchase() {
		if (this.IsAffordable) {
			this.gold.GoldAmount -= this.goldProductionData.GetActualCosts(this.Amount);
			this.Amount += 1;
			this.purchaseButtonLabel.text = $"Purchase for {this.goldProductionData.GetActualCosts(this.Amount)}";
		}
	}

	void Update() {
		UpdateTextColor();
	}

	void UpdateTextColor() {
		this.purchaseButtonLabel.color = this.IsAffordable ? Color.black : Color.red;
	}
}