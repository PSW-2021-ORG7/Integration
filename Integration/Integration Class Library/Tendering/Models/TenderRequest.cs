using System;
using System.Collections.Generic;
using System.Text;

namespace Integration_Class_Library.Tendering.Models
{
    public class TenderRequest
    {
        public String TenderKey { get; set; }
        public List<TenderRequestItem> requestedItems { get; set; }
        public TenderRequest()
        {
            this.requestedItems = new List<TenderRequestItem>();
        }
    }
}
