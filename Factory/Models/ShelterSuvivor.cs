namespace Factory.Models
{
  public class MachineSurvivor
  {       
    public int MachineSurvivorId { get; set; }
    public int SurvivorId { get; set; }
    public int MachineId { get; set; }
    public virtual Survivor Survivor { get; set; }
    public virtual Machine Machine { get; set; }
  }
}