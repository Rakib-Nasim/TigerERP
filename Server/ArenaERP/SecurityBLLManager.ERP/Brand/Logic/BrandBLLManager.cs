using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.ERP.UtilityManagement;
using Infrustracture.ERP.UnitOfWorkSetup.ForBrand;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.BrandBLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductBrand.Logic;

public class BrandBLLManager : IBrandBLLManager
{
    private readonly IBrandUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public BrandBLLManager(IBrandUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<(bool success, int brandId)> AddBrand(BrandViewModel model)
    {
        try
        {
            Brand brand;
            bool success = false;
            int brandId = 0;
            var existModel = CustomValidation.IsExistForTwoCondition<Brand>("Brand", "BrandName", model.BrandName, "CompId", model.CompId);
            if (existModel.Any() && (existModel.Any(c => c.Id != model.Id) || model.Id == null || model.Id == 0))
            {
                throw new DuplicateWaitObjectException($"{model.BrandName} already exist");
            }
            brand = new Brand();
            brand.CreatedBy = "Bappy";
            brand.CreatedDate = DateTime.UtcNow;
            brand.Status = (int)Common.ERP.Enum.AvailableStatus.Active;
            await _unitOfWork.Brand.AddAsync(brand);
            brand = _mapper.Map((BrandViewModel)model, brand);
            success = await _unitOfWork.SaveAsync();
            brandId = brand.Id;
            return (success, brandId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<BrandViewModel>> GetAllBrandByComp(int compId)
    {
        IEnumerable<BrandViewModel> result = new BrandViewModel[] { };
        result = CustomValidation.GetAllActiveByCompId<BrandViewModel>("Brand", "CompId", compId, "Status", 1);
        return result;
    }

    public async Task<(bool success, int brandId)> UpdateBrand(BrandViewModel model)
    {
        try
        {
            Brand brand;
            bool success = false;
            var existModel = CustomValidation.IsExistForTwoCondition<Brand>("Brand", "BrandName", model.BrandName, "CompId", model.CompId);
            if (existModel.Any() && (existModel.Any(c => c.Id != model.Id) || model.Id == null || model.Id == 0))
            {
                throw new DuplicateWaitObjectException($"{model.BrandName} already exist");
            }
            brand = CustomValidation.GetById<Brand>("Brand", "Id", model.Id);
            await _unitOfWork.Brand.EditAsync(brand);
            brand.UpdatedBy = "Bappy";
            brand.UpdatedDate = DateTime.UtcNow;
            brand = _mapper.Map((BrandViewModel)model, brand);
            success = await _unitOfWork.SaveAsync();
            return (success, model.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteBrand(int deleteId)
    {
        try
        {
            Brand brand;
            brand = CustomValidation.GetById<Brand>("Brand", "Id", deleteId);
            brand = await _unitOfWork.Brand.GetByIdAsync(deleteId);
            brand.UpdatedBy = "Bappy";
            brand.UpdatedDate = DateTime.UtcNow;
            brand.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
            var result = await _unitOfWork.SaveAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<BrandViewModel> GetBrandById(int Id)
    {
        try
        {
            BrandViewModel model = new BrandViewModel();
            model = CustomValidation.GetById<BrandViewModel>("Brand", "Id", Id);
            return model;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}

