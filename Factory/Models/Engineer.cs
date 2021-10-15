using System.Collections.Generic;
using System;

namespace Factory.Models
{
    public class Engineer
    {
        public Engineer()
        {
            this.JoinEntities = new HashSet<MachineEngineer>();
            //this.Completed = false;
        }

        public int EngineerId { get; set; }
        public string Description { get; set; }
        //public bool Completed { get; set; }
        public DateTime Hired {get;set;}

        public virtual ICollection<MachineEngineer> JoinEntities { get; set; }
    }
}