using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
	public GoldProductionData GoldProductionData;
	public Text goldAmountText;
	public Text upgradeButtonLabel;
	public ProductionPopUp popupPrefab;
	public Gold gold;
	float elapsedTime;
	Purchasable amount;

	string UpgradeAmountPlayerPrefKey => $"{this.GoldProductionData.name}_Upgrade";

	int UpgradeAmount {
		get => PlayerPrefs.GetInt(this.UpgradeAmountPlayerPrefKey, 0);
		set {
			PlayerPrefs.SetInt(this.UpgradeAmountPlayerPrefKey, value);
			UpdateTitleLabel();
		}
	}

	bool IsUpgradeAffordable => this.gold.GoldAmount >= this.GoldProductionData.GetActualCosts(this.UpgradeAmount);

	public void SetUp(GoldProductionData goldProductionData) {
		this.GoldProductionData = goldProductionData;
		this.gameObject.name = goldProductionData.name;
		this.upgradeButtonLabel.text = $"Upgrade for {this.GoldProductionData.GetActualCosts(this.UpgradeAmount)}";
	}

	public void Upgrade() {
		if (this.IsUpgradeAffordable) {
			this.gold.GoldAmount -= this.GoldProductionData.GetActualCosts(this.UpgradeAmount);
			this.UpgradeAmount += 1;
			this.upgradeButtonLabel.text = $"Upgrade for {this.GoldProductionData.GetActualCosts(this.UpgradeAmount)}";
		}
	}

	void Update() {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.GoldProductionData.productionTime) {
			ProduceGold();
			this.elapsedTime -= this.GoldProductionData.productionTime; // DO NOT SET TO ZERO HERE
		}

		UpdateTextColor();
		UpdateTitleLabel();
	}

	void UpdateTextColor() {
		this.upgradeButtonLabel.color = this.IsUpgradeAffordable ? Color.black : Color.red;
	}

	void UpdateTitleLabel() {
		this.goldAmountText.text = $"{this.amount.Amount}x {this.GoldProductionData.name} Level {this.UpgradeAmount}";
	}

	void ProduceGold() {
		if (this.amount.Amount == 0)
			return;
		this.gold.GoldAmount += Mathf.RoundToInt(CalculateProductionAmount());
		var instance = Instantiate(this.popupPrefab, this.transform);
		instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()}";
	}

	float CalculateProductionAmount() {
		return this.GoldProductionData.GetProductionAmount(this.UpgradeAmount) * this.amount.Amount;
	}
}