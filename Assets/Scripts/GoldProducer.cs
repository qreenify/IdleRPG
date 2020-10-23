using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
	public GoldProductionData GoldProductionData;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
	float elapsedTime;

	public void SetUp(GoldProductionData goldProductionData) {
		this.GoldProductionData = goldProductionData;
		this.gameObject.name = goldProductionData.name;
		this.purchaseButtonLabel.text = $"Purchase {goldProductionData.name}";
	}
	
	public int GoldPressAmount {
		get => PlayerPrefs.GetInt(this.GoldProductionData.name, 0);
		set {
			PlayerPrefs.SetInt(this.GoldProductionData.name, value);
			UpdateGoldPressAmountLabel();
		}
	}

	void UpdateGoldPressAmountLabel() {
		this.goldAmountText.text = this.GoldPressAmount.ToString($"0 {this.GoldProductionData.name}");
	}

	void Start() {
		UpdateGoldPressAmountLabel();
	}
	
	void Update() {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.GoldProductionData.productionTime) {
			ProduceGold();
			this.elapsedTime -= this.GoldProductionData.productionTime; // DO NOT SET TO ZERO HERE
		}
	}
	// something costs 100ct, and I get 40ct per day:
	// IN CASE WE SET IT TO ZERO:
	// 40ct 80ct [120ct (Buy for 100ct) 0ct] 40ct 80ct // In 5 Days, I can buy something for 100ct once, and I have 80ct
	// IN CASE WE DECREASE IT BY THE COSTS:
	// 40ct 80ct [120ct (Buy for 100ct) 20ct] 60ct [100ct (Buy for 100ct) 0ct] // In 5 Days, I can buy something for 100ct twice

	void ProduceGold() {
		var gold = FindObjectOfType<Gold>();
		gold.GoldAmount += this.GoldProductionData.productionAmount * this.GoldPressAmount;
	}

	public void BuyGoldPress() {
		var gold = FindObjectOfType<Gold>();
		if (gold.GoldAmount >= this.GoldProductionData.costs) {
			gold.GoldAmount -= this.GoldProductionData.costs;
			this.GoldPressAmount += 1;
		}
	}
}