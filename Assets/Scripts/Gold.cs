using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {
	public int goldAmountPerClick = 5;
	public Text goldAmountText;

	int _goldAmount;
	public int GoldAmount {
		get => this._goldAmount;
		set {
			this._goldAmount = value;
			this.goldAmountText.text = value.ToString("0 Gold");
		} 
	}
	
	void Start() {
		this.GoldAmount = PlayerPrefs.GetInt("Gold", 1);
	}

	void OnDestroy() {
		PlayerPrefs.SetInt("Gold", this.GoldAmount);
	}
	
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			ProduceGold();
		}
	}

	public void ProduceGold() {
		this.GoldAmount += this.goldAmountPerClick; // this.goldAmount = this.goldAmount + goldAmountPerClick;
	}
}