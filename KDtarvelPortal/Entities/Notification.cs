

using System;

namespace Entities
{
  
    
    public class Notification
    {
        
        public int NotificationId { get; set; }

       
        public string Message { get; set; }
        
        public DateTime RecievedAt { get; set; }

        public int TravelId { get; set; }
        
    }
}
