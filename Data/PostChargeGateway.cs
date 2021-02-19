using System.Collections.Generic;
using System.Linq;
using _2106Proj.Models;

namespace _2106Proj.Data
{
    public class PostChargeGateway
    {
        private readonly HotelContext _context;

        public PostChargeGateway(HotelContext context)
        {
            _context = context;
        }

        public IEnumerable<PostCharge> retrieveAllCharges()
        {
            var Charges = from i in _context.PostCharge
                           select i;

            return Charges.ToList();
        }

        public IEnumerable<PostCharge> findByRoomID(int id)
        {
            var Charges = from i in _context.PostCharge
                           where i.RoomId.Equals(id)
                           select i;

            return Charges.ToList();
        }

        public PostCharge findByID(int id)
        {
            var PostCharge = _context.PostCharge
                .FirstOrDefault(i => i.Id == id);

            return PostCharge;
        }

        public void insert(PostCharge PostCharge)
        {
            _context.Add(PostCharge);
            _context.SaveChanges();
        }

        public void update(PostCharge PostCharge)
        {
            _context.Update(PostCharge);
            _context.SaveChanges();
        }

        public void delete(PostCharge PostCharge)
        {
            _context.PostCharge.Remove(PostCharge);
            _context.SaveChanges();
        }
    }
}
