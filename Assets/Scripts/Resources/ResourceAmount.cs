namespace Resources {
	[System.Serializable]
	public class ResourceAmount {
		public int amount;
		public Resource resource;

		public override string ToString() {
			return $"{this.amount} {this.resource.name}";
		}
	}
}