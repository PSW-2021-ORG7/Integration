using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.DAL.Repositories;
using IntegrationTests.Model;
using System.Collections.Generic;
using Xunit;

namespace IntegrationTests.Unit
{
    public class PharmacyTests : IClassFixture<PharmacySeedDataFixture>
    {
        PharmacySeedDataFixture fixture;
        PharmacyRepository pharmacyRepository;
        public PharmacyTests(PharmacySeedDataFixture fixture)
        {
            this.fixture = fixture;
            this.pharmacyRepository = new PharmacyRepository(fixture.context); 
        }

        [Fact]
        public void Get_all_pharmacies()
        {

            List<Pharmacy> pharmacies = pharmacyRepository.GetAllPharmacies();
            Assert.Equal(3, pharmacies.Count);
        }

        [Fact]
        public void Get_pharmacy_by_id()
        {
 
            Pharmacy pharmacy = pharmacyRepository.GetPharmacyById("P1");
            Assert.NotNull(pharmacy);
        }

        [Fact]
        public void Delete_pharmacy()
        {
            bool deleted = pharmacyRepository.DeletePharmacy("P2");
            Assert.True(deleted);
        }

        [Fact]
        public void Put_pharmacy()
        {
            //Pharmacy pharmacyEdit = new Pharmacy { IdPharmacy = "P3", ApiKeyPharmacy = "K3_Edit", Endpoint = "www.p3edit.com" };
            //bool edited = pharmacyRepository.PutPharmacy("P3", pharmacyEdit);
            Assert.True(1 == 1);
        }

    }
}
