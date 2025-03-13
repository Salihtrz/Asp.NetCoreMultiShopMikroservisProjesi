using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.CouponDto;

namespace MultiShop.Discount.Services.CouponService
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            // Bu kod Dapper üzerinde ekleme işlemi sağlayacak
            string query = "insert into Coupons(Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            };
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponID = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using var connection = _context.CreateConnection();
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons";
            using var connection = _context.CreateConnection();
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponID = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using var connection = _context.CreateConnection();
            {
                var value = await connection.QueryAsync<GetByIdDiscountCouponDto>(query,parameters);
                return value.FirstOrDefault();
            }
        }

        public async Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "select * from Coupons where Code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("code",code);
            using var connection = _context.CreateConnection();
            {
                var value = await connection.QueryAsync<ResultDiscountCouponDto>(query, parameters);
                return value.FirstOrDefault();
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "select Count(*) from Coupons";
            using var connection = _context.CreateConnection();
            {
                var value = await connection.QueryFirstOrDefaultAsync<int>(query);
                return value;
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponID = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId",updateCouponDto.CouponID);
            parameters.Add("code", updateCouponDto.Code);
            parameters.Add("rate", updateCouponDto.Rate);
            parameters.Add("isActive", updateCouponDto.IsActive);
            parameters.Add("validDate", updateCouponDto.ValidDate);
            using var connection = _context.CreateConnection();
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
