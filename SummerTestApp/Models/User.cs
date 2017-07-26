using Java.Sql;
using SQLite;

namespace SummerTestApp.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string CurrentDate { get; set; }
        public string CurrentTime { get; set; }
        public string CigPerDay { get; set; }
        public string PacketPrice { get; set; }
        public int Resin { get; set; }
        public decimal Nicotin { get; set; }  
    }

}