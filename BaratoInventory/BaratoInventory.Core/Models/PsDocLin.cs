using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaratoInventory.Core.Models
{
    [Table("PS_DOC_LIN", Schema = "dbo")]
    public class PsDocLin
    {
        // Primary/Required Keys
        [Column("DOC_ID")]
        public long DOC_ID { get; set; }

        [Column("LIN_SEQ_NO")]
        public int LIN_SEQ_NO { get; set; }

        // Required Character/Code Fields (Non-nullable)
        [Column("STR_ID"), StringLength(10)]
        public string STR_ID { get; set; } = null!;

        [Column("STA_ID"), StringLength(10)]
        public string STA_ID { get; set; } = null!;

        [Column("TKT_NO"), StringLength(15)]
        public string TKT_NO { get; set; } = null!;

        [Column("ITEM_NO"), StringLength(20)]
        public string ITEM_NO { get; set; } = null!;

        [Column("LIN_TYP"), StringLength(1)]
        public string LIN_TYP { get; set; } = "L";

        [Column("QTY_SOLD")]
        public decimal QTY_SOLD { get; set; }

        [Column("QTY_NUMER")]
        public decimal QTY_NUMER { get; set; } = 1;

        [Column("QTY_DENOM")]
        public decimal QTY_DENOM { get; set; } = 1;

        [Column("SELL_UNIT"), StringLength(1)]
        public string SELL_UNIT { get; set; } = "0";

        [Column("EXT_PRC")]
        public decimal EXT_PRC { get; set; }

        [Column("IS_TXBL"), StringLength(1)]
        public string IS_TXBL { get; set; } = "Y";

        [Column("ITEM_TYP"), StringLength(1)]
        public string ITEM_TYP { get; set; } = "I";

        [Column("TRK_METH"), StringLength(1)]
        public string TRK_METH { get; set; } = "N";

        [Column("LIN_GUID")]
        public Guid LIN_GUID { get; set; } = Guid.NewGuid();

        [Column("QTY_RET")]
        public decimal QTY_RET { get; set; } = 0;

        [Column("GROSS_EXT_PRC")]
        public decimal GROSS_EXT_PRC { get; set; }

        [Column("HAS_PRC_OVRD"), StringLength(1)]
        public string HAS_PRC_OVRD { get; set; } = "N";

        [Column("USR_ENTD_PRC"), StringLength(1)]
        public string USR_ENTD_PRC { get; set; } = "N";

        [Column("IS_DISCNTBL"), StringLength(1)]
        public string IS_DISCNTBL { get; set; } = "Y";

        [Column("CALC_EXT_PRC")]
        public decimal CALC_EXT_PRC { get; set; }

        [Column("IS_WEIGHED"), StringLength(1)]
        public string IS_WEIGHED { get; set; } = "N";

        [Column("TAX_AMT_ALLOC")]
        public decimal TAX_AMT_ALLOC { get; set; } = 0;

        [Column("NORM_TAX_AMT_ALLOC")]
        public decimal NORM_TAX_AMT_ALLOC { get; set; } = 0;

        // Nullable Fields (Included for completeness but marked as optional)
        [Column("PRC")]
        public decimal? PRC { get; set; }

        [Column("DESCR"), StringLength(50)]
        public string? DESCR { get; set; }

        [Column("UNIT_COST")]
        public decimal? UNIT_COST { get; set; }

        [Column("EXT_COST")]
        public decimal? EXT_COST { get; set; }
    }
}
