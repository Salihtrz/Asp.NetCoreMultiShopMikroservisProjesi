using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    public class EFCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _context;
        public EFCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            this._context = cargoContext;
        }

        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _context.CargoCustomers.Where(x => x.UserCustomeId == id).FirstOrDefault();
            return values;
        }
    }
}
