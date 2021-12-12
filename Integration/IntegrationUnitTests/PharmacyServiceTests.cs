using Integration_Class_Library.Models;
using Integration_Class_Library.PharmacyEntity.Interfaces;
using Integration_Class_Library.PharmacyEntity.Services;
using Moq;
using Xunit;

namespace IntegrationTests.Unit
{
    public class PharmacyServiceTests 
    {

        private readonly PharmacyService _sut;
        private readonly Mock<IPharmacyRepository> _pharmacyRepoMoq = new Mock<IPharmacyRepository>();

        public PharmacyServiceTests()
        {
            _sut = new PharmacyService(_pharmacyRepoMoq.Object);
        }

        [Fact]
        public void Get_by_id()
        {
            // Arrange
            var pharmacyId = 1;
            var pharmacyDTO = new Pharmacy
            {
                IdPharmacy = pharmacyId,

            };

            _pharmacyRepoMoq.Setup(x => x.GetPharmacyById(pharmacyId)).Returns(pharmacyDTO);

            // Act
            var pharmacy = _sut.GetPharmacyById(pharmacyId);

            // Assert
            Assert.Equal(pharmacyId, pharmacy.IdPharmacy);
        }

    }
}
