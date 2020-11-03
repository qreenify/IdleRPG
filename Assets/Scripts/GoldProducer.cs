using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
	public GoldProductionData GoldProductionData;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
	float elapsedTime;

	int Amount {
		get => PlayerPrefs.GetInt(this.GoldProductionData.name, 0);
		set {
			PlayerPrefs.SetInt(this.GoldProductionData.name, value);
			UpdateAmountLabel();
		}
	}

	bool IsAffordable => FindObjectOfType<Gold>().GoldAmount >= this.GoldProductionData.costs;

	public void SetUp(GoldProductionData goldProductionData) {
		this.GoldProductionData = goldProductionData;
		this.gameObject.name = goldProductionData.name;
		this.purchaseButtonLabel.text = $"Purchase for {goldProductionData.costs}";
	}

	public void Purchase() {
		if (this.IsAffordable) {
			var gold = FindObjectOfType<Gold>();
			gold.GoldAmount -= this.GoldProductionData.costs;
			this.Amount += 1;
		}
	}

	void Start() {
		UpdateAmountLabel();
	}
	
	void Update() {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.GoldProductionData.productionTime) {
			ProduceGold();
			this.elapsedTime -= this.GoldProductionData.productionTime; // DO NOT SET TO ZERO HERE
		}

		UpdateTextColor();
	}

	void UpdateTextColor() {
		this.purchaseButtonLabel.color = this.IsAffordable ? Color.black : Color.red;
	}

	void UpdateAmountLabel() {
		this.goldAmountText.text = this.Amount.ToString($"0 {this.GoldProductionData.name}");
	}

	void ProduceGold() {
		var gold = FindObjectOfType<Gold>();
		gold.GoldAmount += this.GoldProductionData.productionAmount * this.Amount;
	}
}