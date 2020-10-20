using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {
	public int goldAmount;
	public Text goldAmountText;

	void Update() {
		this.goldAmountText.text = this.goldAmount.ToString("0 Gold");
	}
}