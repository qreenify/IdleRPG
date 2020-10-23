using UnityEngine;

public class Enemy : MonoBehaviour {
	bool HasTarget => GetComponent<Target>() != null;
	void Update() {
		if (!this.HasTarget) {
			var hero = FindObjectOfType<Hero>();
			if (hero != null) {
				var target = this.gameObject.AddComponent<Target>();
				target.value = hero.gameObject;
			}
		}
	}
}