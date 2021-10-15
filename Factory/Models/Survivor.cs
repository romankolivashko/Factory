using System.Collections.Generic;
using System;

namespace Factory.Models
{
    public class Survivor
    {
        public Survivor()
        {
            this.JoinEntities = new HashSet<MachineSurvivor>();
            this.Completed = false;
        }

        public int SurvivorId { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Arrived {get;set;}

        public virtual ICollection<MachineSurvivor> JoinEntities { get; set; }
    }
}