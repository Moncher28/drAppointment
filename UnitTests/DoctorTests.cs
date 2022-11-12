using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using domain;

namespace UnitTests
{
    public class DoctorTests
    {
        private readonly DoctorService _doctorService;
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

        public DoctorTests()
        {
            
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
            _doctorService = new DoctorService(_doctorRepositoryMock.Object);
        }

        [Fact]
        public void GetDoctorByID_ShouldFail()
        {
            var res = _doctorService.GetDoctorById(-1);

            Assert.True(res.IsFailure); 
            Assert.Equal("Doctor not found", res.Error);
        }

        [Fact]
        public void GetDoctorBySpec_ShouldFail()
        {
            
            _doctorRepositoryMock.Setup(repository => repository.GetBySpec(It.IsAny<DrSpec>()))
                .Returns(() => null);

            DrSpec drSpec = null;
            var res = _doctorService.GetDoctorBySpec(drSpec); 

            Assert.True(res.IsFailure); 
            Assert.Equal("Doctor not found", res.Error); 
        }

        [Fact]
        public void CreateDoctor_ShouldFail()
        {
            _doctorRepositoryMock.Setup(repository => repository.CreateDoctor(It.IsAny<NewDoctor>()))
        .Returns(() => null);

            NewDoctor newDoctor = null;
            var res = _doctorService.CreateDoctor(newDoctor);

            Assert.True(res.IsFailure);
            Assert.Equal("Doctor not created", res.Error);
        }

        [Fact]
        public void GetAllDoctors_ShouldFail()
        {
            var res = _doctorService.GetAllDoctors();

            Assert.True(res.IsFailure);
            Assert.Equal("Failed when triying to get all doctors", res.Error); 
        }

        [Fact]
        public void DeleteDoctor_ShouldFail()
        {
            var res = _doctorService.DeleteDoctor(-1);

            Assert.True(res.IsFailure); 
            Assert.Equal("Deletion Error", res.Error);
        }
    }
}
