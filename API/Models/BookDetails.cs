using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public enum Availability {Unknown, Available, Issued, Damaged}
    public class BookDetails
    {
        //         1.	BookID (Auto Increment - BID1000)
        // 2.	BookName
        // 3.	AuthorName
        // 4.	Availability (Enum – Unknown, Available, Issued, Damaged)
        public string BookID { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        
        public Availability Availability { get; set; }
        
        







    }
}