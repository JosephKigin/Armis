using System;
using System.Collections.Generic;

namespace Armis.Data.DatabaseContext.Entities
{
    public partial class OprLoadPrice
    {
        public int OperationId { get; set; }
        public short DepartmentId { get; set; }
        public byte LoadTypeId { get; set; }
        public int CustSeq { get; set; }
        public int? CustId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PricePerUoM { get; set; }
        public int PriceUoM { get; set; }
        public decimal MinLotCharge { get; set; }
        public decimal MinPiecePrice { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual DeptOperation DeptOperation { get; set; }
        public virtual LoadTypeCode LoadType { get; set; }
        public virtual UnitOfMeasure PriceUoMNavigation { get; set; }
    }
}
