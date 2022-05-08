using Flight.Services.CouponAPI.Models;
using Flight.Services.CouponAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Services.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<IEnumerable<CouponViewDto>> GetCoupon();
        Task<CouponViewDto> GetCouponByName(string couponCode);
        Task<CouponViewDto> GetCouponById(int couponId);
        Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto);
        Task<bool> DeleteCoupon(int couponId);
    }
}
