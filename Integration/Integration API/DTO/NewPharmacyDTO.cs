using System;

namespace Integration_API.DTO
{
    public class NewPharmacyDTO
    {
        public String NamePharmacy { get; set; }
        public String ApiKeyPharmacy { get; set; }
        public String Endpoint { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
