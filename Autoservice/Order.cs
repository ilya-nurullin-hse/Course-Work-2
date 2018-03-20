//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autoservice
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string SpareVendorcode { get; set; }
        public int ProviderId { get; set; }
        public int ClientId { get; set; }
        public int AutoModelId { get; set; }
        public int SparePrice { get; set; }
        public string Status { get; set; }
        public int TotalPrice { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public int WorkerId { get; set; }
    
        public virtual AutoModel AutoModelSet { get; set; }
        public virtual Client ClientSet { get; set; }
        public virtual Manufacturer ManufacturerSet { get; set; }
        public virtual Provider ProviderSet { get; set; }
        public virtual Spare SpareSet { get; set; }
        public virtual Worker Worker { get; set; }
    }
}