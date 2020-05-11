using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PeerToPeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace PeerToPeer.Repositories.Interface.Implementations
{
    public class DonationRepository : IDonationRepository
    {
        private PeerToPeerContext context;
        public DonationRepository(PeerToPeerContext context)
        {
            this.context = context;
        }
        public Donation createDonation(Donation donation)
        {
            Student student = context.Students.Find(donation.StudentId);
            Donor donor = context.Donors.Find(donation.DonorId);

            if(student != null && donor != null)
            {
                context.Donations.Add(donation);
                context.SaveChanges();
            }

            allocateDonation(donation.StudentId, donation.DonorId);
            return donation;
        
        }
        public IEnumerable<Donation> getAllDonations() 
        {
            IEnumerable<Donation> donations = context.Donations;
            return donations;
        }
        public Donation getDonation(int id)
        {
            
            Donation donation = context.Donations.Where(x => x.Id == id).FirstOrDefault();
            return donation;
        }

        private void allocateDonation(int studentId, int donorId)
        {

            Student student = context.Students.Find(studentId);
            Donor donor = context.Donors.Find(donorId);

            if (student.isGoalReached == false)
            {
                foreach (Donation donation in student.StudentDonations)
                {
                    
                    donor.TotalAmountDonated += donation.Amount;
                    student.AmountReceived += donation.Amount;
                    student.AmountLeft = student.AmountNeeded - student.AmountReceived;
                }
                if (student.AmountReceived >= student.AmountNeeded)
                    student.isGoalReached = true;
                Console.WriteLine("Student has reached Goal Reached");
            }
           
            context.SaveChanges();

        }
    }
}
