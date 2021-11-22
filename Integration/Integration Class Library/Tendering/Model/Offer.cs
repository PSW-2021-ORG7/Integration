using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Model
{
    public class Offer
    {
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public Offer(string text, DateTime timestamp)
        {
            this.Text = text;
            this.Timestamp = timestamp;
        }

        public Offer()
        {
        }

        public override string ToString()
        {
            return this.Text + " sent at " + this.Timestamp.ToString();
        }
    }
}
