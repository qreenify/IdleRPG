using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
	public GoldProductionData GoldProductionData;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
	public ProductionPopUp popupPrefab;
	public Gold gold;
	float elapsedTime;

	int Amount {
		get => PlayerPrefs.GetInt(this.GoldProductionData.name, 0);
		set {
			PlayerPrefs.SetInt(this.GoldProductionData.name, value);
			UpdateAmountLabel();
		}
	}

	bool IsAffordable => this.gold.GoldAmount >= this.GoldProductionData.GetActualCosts(this.Amount);

	public void SetUp(GoldProductionData goldProductionData) {
		this.GoldProductionData = goldProductionData;
		this.gameObject.name = goldProductionData.name;
		this.purchaseButtonLabel.text = $"Purchase for {this.GoldProductionData.GetActualCosts(this.Amount)}";
	}

	public void Purchase() {
		if (this.IsAffordable) {
			this.gold.GoldAmount -= this.GoldProductionData.GetActualCosts(this.Amount);
			this.Amount += 1;
			this.purchaseButtonLabel.text = $"Purchase for {this.GoldProductionData.GetActualCosts(this.Amount)}";
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
		if (this.Amount == 0)
			return;
		this.gold.GoldAmount += this.GoldProductionData.ProductionAmount * this.Amount;
		var instance = Instantiate(this.popupPrefab, this.transform);
		instance.GetComponent<Text>().text = $"+{this.GoldProductionData.ProductionAmount * this.Amount}";
	}
}