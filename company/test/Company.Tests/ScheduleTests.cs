using System;
using Xunit;

namespace Company.Tests
{
    public class ScheduleTests
    {

        private readonly Employee TestEmployee =  new Employee(1, "Jane", "Retail Cashier");
        private readonly Day TestDay =  Day.Wednesday;

        [Fact]
        public void DuplicateMeetingAssignmentTest()
        {
            var schedule = new Schedule();
            var employee1 = new Employee(0, "John", "Business Infastructure Manager");
            var scheduled = schedule.AssignMeeting(new Meeting(employee1, TestDay, "Limerick"));
            Assert.True(scheduled);
            scheduled = schedule.AssignMeeting(new Meeting(TestEmployee, TestDay, "Dublin"));
            Assert.False(scheduled);
        }

        [Fact]
        public void MeetingCountTest()
        {
            var schedule = new Schedule();
            var days = Enum.GetValues(typeof(Day));
            foreach(Day day in days)
            {
                schedule.AssignMeeting(new Meeting(TestEmployee, day, "Limerick"));
            }
            Assert.Equal(5, schedule.MeetingCount);
        }

        [Fact]
        public void CancelMeetingTest()
        {
            var schedule = new Schedule();
            var employee = new Employee(1, "Jane", "Retail Cashier");
            schedule.AssignMeeting(new Meeting(employee, TestDay, "Limerick"));
            schedule.CancelMeeting(TestDay);
            Assert.False(schedule.MeetingSlotOccupied(TestDay));
        }

        [Fact]
        public void CancelNonExistentMeetingTest()
        {
            var schedule = new Schedule();
            Assert.False(schedule.CancelMeeting(Day.Thurs));
        }

        [Fact]
        public void MeetingSlotOccupiedTest()
        {
            var schedule = new Schedule();
            Assert.False(schedule.MeetingSlotOccupied(Day.Monday));
            Assert.False(schedule.MeetingSlotOccupied(Day.Wednesday));
            schedule.AssignMeeting(new Meeting(TestEmployee, TestDay, "Limerick"));
        }

    }
}
