using System;

namespace Currencies {
    public class SEK : Money
    {
        public static int dollar;
        public SEK(int amount)
        {
            this.amount = amount * dollar;
        }
        
    }
}