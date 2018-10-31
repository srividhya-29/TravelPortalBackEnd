

namespace Entities
{
    
    class WorkFlow
    {
       
        public int WorkFlowId { get; set; }

        
        public string Role { get; set; }



        public byte CurrentStatusId { get; set; }

        public byte NextStatusId { get; set; }

    }
}
