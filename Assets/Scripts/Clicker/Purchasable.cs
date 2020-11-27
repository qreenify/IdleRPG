using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker {
    [Serializable]
    public class Purchasable {
        public StringEvent CostsLabelChanged;
        public ColorEvent CostsLabelColorChanged;
        ResourceProduction.Data data;
        string productId;

        bool IsAffordable => this.data.GetActualCosts(this.Amount).IsAffordable;

        public int Amount {
            get => PlayerPrefs.GetInt(this.data.name + "_" + this.productId, 0);
            private set => PlayerPrefs.SetInt(this.data.name + "_" + this.productId, value);
        }

        public void SetUp(ResourceProduction.Data data, string productId) {
            this.data = data;
            this.productId = productId;
            UpdateCostLabel();
        }

        public void Purchase() {
            if (!this.IsAffordable)
                return;
            this.data.GetActualCosts(this.Amount).Consume();
            this.Amount += 1;
            UpdateCostLabel();
        }

        void UpdateCostLabel() {
            var updatedCosts = this.data.GetActualCosts(this.Amount);
            this.CostsLabelChanged.Invoke($"Add {this.productId} for {updatedCosts}");
        }

        public void Update() => UpdateTextColor();
        void UpdateTextColor() => this.CostsLabelColorChanged.Invoke(this.IsAffordable ? Color.black : Color.red);
    }
}