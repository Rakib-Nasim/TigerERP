using ModelClass.ERP.UnitOfWorkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClass.ERP.DTO
{
    public class Product:IEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int UnitId { get; set; }
        public int CompId { get; set; }
        public int? CategoryId { get; set; }
        public decimal? CostPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? ProductType { get; set; }
        public int? BrandId { get; set; }
        public int? ModuelId { get; set; }
        public int? OriginId { get; set; }
        public int? BillUnitId { get; set; }
        public int? ModuleId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeofProduct { get; set; }
        public string? Image { get; set; }
        public decimal? Vatrate { get; set; }
        public decimal? BoxConv { get; set; }
        public decimal? Factor { get; set; }
        public decimal? Factor2 { get; set; }
        public string? ProductBarCode { get; set; }
        public int? BillType { get; set; }
        public int? PParentId { get; set; }
        public int? SortOrder { get; set; }
        public string? ShortCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; }
        public  ICollection<ProductSupplier> ProductSupplier { get; set; }

    }
}
