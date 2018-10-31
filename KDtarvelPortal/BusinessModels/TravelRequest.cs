using System;

namespace   BusinessModels
{
    public class TravelRequest
    {
        public int TravelId { get; set; }
        public string TravelRequestName { get; set; }        
        public DateTime StartDate { get; set; }       
        public DateTime EndDate { get; set; }        
        public string Place { get; set; }
        public byte TravelTypeId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public byte StatusId { get; set; }
        public int ProjectId { get; set; }
    }
}
