using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.ERP.UtilityManagement;
using DatabaseContext;
using Infrustracture.ERP.UnitOfWorkSetup.ForProductColor;
using Microsoft.EntityFrameworkCore;
using ModelClass.ERP.DTO;
using ModelClass.ERP.ViewModel;
using SecurityBLLManager.ERP.ProductColorBLLMana.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ProductColorBLL.Logic
{
    public class ProductColorBLLManager : IProductColorBLLManager
    {
        private readonly IProductColorUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductColorBLLManager(IProductColorUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddProductColor(ColorViewModel model)
        {
            try
            {
                Color color;
                int colorId = 0;
                var existModel = CustomValidation.IsExistForTwoCondition<Color>("Color", "ColorName", model.ColorName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.ColorId != model.ColorId) || model.ColorId == null || model.ColorId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.ColorName} already exist");
                }
                await _unitOfWork.BeginTransactionAsync();
                color = new Color();
                colorId = CustomValidation.MaxNumber<int>("Color", "ColorId", "CompId", model.CompId);

                color.CreatedBy = "Bappy";
                color.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.ProductColor.AddAsync(color);
                color = _mapper.Map((ColorViewModel)model, color);
                var result = await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                return result;
            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateProductColor(ColorViewModel model)
        {
            try
            {
                Color color;
                var existModel = CustomValidation.IsExistForTwoCondition<Color>("Color", "ColorName", model.ColorName, "CompId", model.CompId);
                if (existModel.Any() && (existModel.Any(c => c.ColorId != model.ColorId) || model.ColorId == null || model.ColorId == 0))
                {
                    throw new DuplicateWaitObjectException($"{model.ColorName} already exist");
                }
                await _unitOfWork.BeginTransactionAsync();
                color = new Color();
                color=CustomValidation.GetById<Color>("Color", "Id", model.Id);
                color.UpdatedBy = "Bappy";
                color.UpdatedDate = DateTime.UtcNow;
                await _unitOfWork.ProductColor.EditAsync(color);
                color = _mapper.Map((ColorViewModel)model, color);
                var result = await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();
                return result;
            }

            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw new Exception(ex.Message);
            }
        }
        public async Task<IEnumerable<ColorViewModel>> GetAllColorByComp(int compId)
        {
            IEnumerable<ColorViewModel> result = new ColorViewModel[] { };
            result = CustomValidation.GetAllActiveByCompId<ColorViewModel>("Colors", "CompId",compId, "Status", 1);
            return result;
        }

        public async Task<bool> DeleteColor(int deleteId)
        {
            try
            {
                Color color;
                color = CustomValidation.GetById<Color>("Color","Id",deleteId);
                color.UpdatedBy = "Bappy";
                color.UpdatedDate = DateTime.UtcNow;
                color.Status = (int)Common.ERP.Enum.AvailableStatus.Delete;
                var result = await _unitOfWork.SaveAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<ColorViewModel> GetColorById(int Id)
        {
            ColorViewModel model = new ColorViewModel();
            model = CustomValidation.GetById<ColorViewModel>("Color", "Id", Id);
            return model;
        }
    }
}
