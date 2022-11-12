using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using domain;

namespace UnitTests
{
    public class ScheduleTests
    {
        private readonly ScheduleService _scheduleService;
        private readonly Mock<IScheduleRepository> _scheduleRepositoryMock;

        public ScheduleTests()
        {

            _scheduleRepositoryMock = new Mock<IScheduleRepository>();
            _scheduleService = new ScheduleService(_scheduleRepositoryMock.Object);
        }

        [Fact]
        public void GetScheduleOnSelectedDateSpecificDoctor_ShouldFail()
        {
            var res = _scheduleService.GetScheduleOnSelectedDateSpecificDoctor(DateTime.Now, -1);

            Assert.True(res.IsFailure); 
            Assert.Equal("Schedule not found", res.Error); 
        }

        [Fact]
        public void CreateSchedule_ShouldFail()
        {
           
            _scheduleRepositoryMock.Setup(repository => repository.CreateSchedule(It.IsAny<NewSchedule>()))
                .Returns(() => null);

            NewSchedule newSchedule = null;
            var res = _scheduleService.CreateSchedule(newSchedule); 

            Assert.True(res.IsFailure); 
            Assert.Equal("Schedule not created", res.Error); 
        }

        [Fact]
        public void UpdateSchedule_ShouldFail()
        {
            _scheduleRepositoryMock.Setup(repository => repository.UpdateSchedule(-1 ,It.IsAny<Schedule>()))
        .Returns(() => null);

            Schedule schedule = null;
            var res = _scheduleService.UpdateSchedule(-1, schedule);

            Assert.True(res.IsFailure);
            Assert.Equal("Schedule not updated", res.Error);
        }

        [Fact]
        public void DeleteSchedule_ShouldFail()
        {
            var res = _scheduleService.DeleteSchedule(-1);

            Assert.True(res.IsFailure);
            Assert.Equal("Deletion Error", res.Error); 
        }
    }
}
