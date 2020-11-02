using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {
	public int goldAmountPerClick = 5;
	public Text goldAmountText;
	const string goldPlayerPrefKey = "Gold";

	public int GoldAmount {
		get => PlayerPrefs.GetInt(goldPlayerPrefKey, 1);
		set {
			PlayerPrefs.SetInt(goldPlayerPrefKey, value);
			UpdateGoldAmountLabel();
		}
	}

	void UpdateGoldAmountLabel() {
		this.goldAmountText.text = this.GoldAmount.ToString("0 Gold");
	}

	void Start() {
		UpdateGoldAmountLabel();
	}

	public void ProduceGold() {
		this.GoldAmount += this.goldAmountPerClick; // this.GoldAmount = this.GoldAmount + this.goldAmountPerClick;
	}
}