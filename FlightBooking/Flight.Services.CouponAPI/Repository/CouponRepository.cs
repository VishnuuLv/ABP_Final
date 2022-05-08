using AutoMapper;
using Flight.Services.CouponAPI.DbContexts;
using Flight.Services.CouponAPI.Models;
using Flight.Services.CouponAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Flight.Services.CouponAPI.Repository
{
    public class CouponRepository : ICouponRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CouponRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<CouponDto> CreateUpdateCoupon(CouponDto couponDto)
        {
            Coupon coupon = _mapper.Map<CouponDto, Coupon>(couponDto);
            var CreatedDateTemp = await _db.Coupons.Where(u => u.couponId == coupon.couponId).Select(u => u.createdDate).SingleOrDefaultAsync();

            if (coupon.couponId > 0)
            {
                    coupon.isActive = "Y";
                    coupon.updatedDate = DateTime.Now;
                    coupon.createdDate = CreatedDateTemp;
                    _db.Coupons.Update(coupon);
            }
            else
            {
                coupon.isActive = "Y";
                coupon.createdDate = DateTime.Now;
                coupon.updatedDate = DateTime.Now;
                _db.Coupons.Add(coupon);

            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Coupon, CouponDto>(coupon);
        }

        public async Task<bool> DeleteCoupon(int couponId)
        {
            try
            {
                Coupon coupon = await _db.Coupons.FirstOrDefaultAsync(x => x.couponId == couponId);
                if (coupon == null)
                {
                    return false;
                }
                else {
                    // _db.Coupons.Remove(coupon);
                    coupon.isActive = "N";
                    await _db.SaveChangesAsync();
                    return true;
                }

                

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<CouponViewDto>> GetCoupon()
        {
            List<Coupon> couponList = await _db.Coupons.ToListAsync();
            return _mapper.Map<List<CouponViewDto>>(couponList);
        }

        public async Task<CouponViewDto> GetCouponById(int couponId)
        {
            Coupon coupon = await _db.Coupons.Where(x => x.couponId == couponId).FirstOrDefaultAsync();
            return _mapper.Map<CouponViewDto>(coupon);
        }

        public async Task<CouponViewDto> GetCouponByName(string couponCode)
        {
            Coupon coupon = await _db.Coupons.Where(x => x.couponCode == couponCode).FirstOrDefaultAsync();
            return _mapper.Map<CouponViewDto>(coupon);
        }
    }
}
