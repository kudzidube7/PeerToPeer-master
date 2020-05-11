using Microsoft.EntityFrameworkCore;
using PeerToPeer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace PeerToPeer.Repositories.Interface.Implementations
{
    public class DonorRepository : IDonorRepository
    {
        private PeerToPeerContext context;
        public DonorRepository(PeerToPeerContext context)
        {
            this.context = context;
        }

        public Donor createDonor(Donor donor)
        {
           
            context.Donors.Add(donor);
            context.SaveChanges();
            return donor;
        }
        public IEnumerable<Donor> getAllDonors()
        {
            IEnumerable<Donor> donors = context.Donors.Include(navigationPropertyPath: p => p.DonorDonations);
            return donors;
        }
        public Donor getDonor(int id)
        {
            Donor donor;
            IEnumerable<Donor> donors = context.Donors
                .Where(x => x.Id == id)
                .Include(navigationPropertyPath: p => p.DonorDonations);
          donor =   donors.FirstOrDefault();

            return donor;
        
        }

        public Donor updateDonor(Donor donor)
        {
            context.Entry(donor).State = EntityState.Modified;
            context.SaveChanges();
            return donor;
        }

        public Donor deleteDonor(int id)
        {
            Donor donor;
           donor = context.Donors.Where(x => x.Id == id).FirstOrDefault();
            donor.isDeleted = true;
            context.SaveChanges();

            return donor;
            
        }
      
    }
}
