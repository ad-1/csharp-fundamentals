using System.Text;

namespace Company
{

    public class Meeting
    {

        public Employee appointee;
        public Day day;
        public string location;

        public Meeting(Employee employee, Day day, string location)
        {
            this.appointee = employee;
            this.day = day;
            this.location = location;
        }

    }
}
