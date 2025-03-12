namespace Hospital.Entites
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        // Icollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}   
