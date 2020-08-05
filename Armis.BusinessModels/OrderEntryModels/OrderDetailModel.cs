using Armis.BusinessModels.ARModels;
using Armis.BusinessModels.PartModels;
using Armis.BusinessModels.ShopFloorModels.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armis.BusinessModels.OrderEntryModels
{
    public class OrderDetailModel
    {
        public int OrderId { get; set; }
        public byte OrderLine { get; set; }
        public int Quantity { get; set; }
        public int? PartId { get; set; }
        public int? PartRevId { get; set; }
        public decimal Poprice { get; set; }
        public decimal CalcPrice { get; set; }
        public decimal AssignPrice { get; set; }
        public byte PriceCodeId { get; set; }
        public decimal LotCharge { get; set; }
        public string Description { get; set; }

        public PartModel Part { get; set; }
        public PriceCodeModel PriceCode { get; set; }
        public OrderDetailCommentModel OrderDetailComment { get; set; }
        public IEnumerable<OrderLocationModel> OrderLocation { get; set; }
    }
}
