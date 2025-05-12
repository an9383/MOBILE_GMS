using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class ProductStockStatusModel
    {
        /// <summary>
        /// 코드
        /// </summary>
        public string item_cd { get; set; }

        /// <summary>
        /// 품목명
        /// </summary>
        public string item_nm { get; set; }

        /// <summary>
        /// 포장단위
        /// </summary>
        public string item_lot_size { get; set; }

        /// <summary>
        /// 생산량
        /// </summary>
        public string prod_qty_sum { get; set; }

        /// <summary>
        /// 총 기타 입고량
        /// </summary>
        public string etc_in_qty_sum { get; set; }

        /// <summary>
        /// 총 출고량
        /// </summary>
        public string issue_qty_sum { get; set; }

        /// <summary>
        /// 총 기타 출고량
        /// </summary>
        public string etc_out_qty_sum { get; set; }

        /// <summary>
        /// 이론재고량
        /// </summary>
        public string theory_qty { get; set; }

        /// <summary>
        /// 재고량
        /// </summary>
        public string stock_qty_sum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string stock_qty_chk { get; set; }

        /// <summary>
        /// 입고예정량
        /// </summary>
        public string prod_qty_plan { get; set; }

        /// <summary>
        ///  체크
        /// </summary>
        public string check { get; set; }



        /// <summary>
        ///  ID
        /// </summary>
        public string item_stock_id { get; set; }

        /// <summary>
        ///  제조번호
        /// </summary>
        public string lot_no { get; set; }

        /// <summary>
        ///  제조일자
        /// </summary>
        public string lot_date { get; set; }

        /// <summary>
        ///  출하승인상태
        /// </summary>
        public string ISSUE_STATUS { get; set; }

        /// <summary>
        ///  팔레트
        /// </summary>
        public string item_move { get; set; }

        /// <summary>
        ///  품목 검색명
        /// </summary>
        public string s_item { get; set; }

        /// <summary>
        ///  제조번호 검색명
        /// </summary>
        public string s_lot_no { get; set; }

        /// <summary>
        ///  사용 여부
        /// </summary>
        public string use_ck { get; set; }

    }
}
