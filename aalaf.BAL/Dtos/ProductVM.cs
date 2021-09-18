using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace aalaf.BAL.Dtos
{
    public class ProductVM : IVM
    {
        public string Title { get; set; }
        public string ArTitle { get; set; }
        public string Description { get; set; }
        public string ArDescription { get; set; }
        public string NutritionalInformation { get; set; }
        public string ArNutritionalInformation { get; set; }
        public string ProductType { get; set; }
        public string ArProductType { get; set; }
        public string DietNeeds { get; set; }
        public string ArDietNeeds { get; set; }
        public string Specialty { get; set; }
        public string ArSpecialty { get; set; }
        public string PackageDimensions { get; set; }
        public string ArPackageDimensions { get; set; }
        public string PackageWeight { get; set; }
        public string ArPackageWeight { get; set; }
        public string StorageRequirements { get; set; }
        public string ArStorageRequirements { get; set; }
        public string OriginCountry { get; set; }
        public string ArOriginCountry { get; set; }
        public decimal? Price { get; set; }
        public bool? Active { get; set; }
        public string Currency { get; set; }
        public string Photo { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? CategoryId { get; set; }
    }
}
