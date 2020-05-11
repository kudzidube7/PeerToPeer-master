using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeerToPeer.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DonorId { get; set; }
        public string DonationName { get; set; }
        public double Amount { get; set; }
    }
}
