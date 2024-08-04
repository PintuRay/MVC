﻿namespace FMS.Db.DbEntity
{
    public class Stock
    {
        public Guid StockId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_FinancialYear { get; set; }
        public int MinQty { get; set; }
        public int MaxQty { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal AvilableStock { get; set; }
        public Branch Branch { get; set; }
        public Product Product { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
}
