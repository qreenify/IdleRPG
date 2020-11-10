using UnityEngine;
using UnityEngine.UI;

namespace Resources {
	public class ResourceUI : MonoBehaviour {
		public Text amountText;
		public Text resourceNameText;
		public Resource resource;

		void Update() {
			this.amountText.text = this.resource.Owned.ToString();
			this.resourceNameText.text = this.resource.name;
			this.amountText.color = this.resource.color;
			this.resourceNameText.color = this.resource.color;
		}

		public void SetUp(Resource resource) {
			this.resource = resource;
		}

		public void Produce() {
			this.resource.Produce();
		}
	}
}
