using System;
using System.Collections.Generic;

namespace Company
{
    public class Schedule
    {

        private readonly Dictionary<Day, Meeting> meetings;

        public int MeetingCount
        {
            get
            {
                return meetings.Count;
            }
        }

        public Schedule()
        {
            meetings = new Dictionary<Day, Meeting>();
        }

        public bool AssignMeeting(Meeting newMeeting)
        {
            var day = newMeeting.day;
            if (MeetingSlotOccupied(day))
            {
                Console.WriteLine($"Can't assign meeting for {newMeeting.appointee.Name}!" +
                    $"\n{meetings[day].appointee.Name} has a meeting on {day}");
                return false;
            }
            meetings[day] = newMeeting;
            Console.WriteLine($"{day} meeting successfully assigned to {newMeeting.appointee.Name}");
            return true;
        }

        public void ShowMeetings()
        {
            if (MeetingCount == 0)
            {
                Console.WriteLine("No meetings have been scheduled yet");
                return;
            }
            Console.WriteLine($"\nMeeting List");
            foreach (Meeting meeting in meetings.Values)
            {
                Console.WriteLine($"{meeting.appointee.Name, -10} :" +
                    $" {meeting.day, 10} " +
                    $": {meeting.location, 10}");
            }
        }

        public bool CancelMeeting(Day day)
        {
            Console.WriteLine($"Cancelling meeting on {day}");
            return meetings.Remove(day);
        }

        public bool MeetingSlotOccupied(Day day)
        {
            return meetings.ContainsKey(day);
        }

    }
}
