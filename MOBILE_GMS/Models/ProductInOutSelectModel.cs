using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class ProductInOutSelectModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 대표번호
        /// </summary>
        public string order_no { get; set; }

        /// <summary>
        /// 입고공정일련번호
        /// </summary>
        public string order_proc_id { get; set; }

        /// <summary>
        /// 포장실적일련번호
        /// </summary>
        public string packing_result_id { get; set; }

        /// <summary>
        /// 바코드 (박스 바코드)
        /// </summary>
        public string box_barcode_no { get; set; }

        /// <summary>
        /// 제조번호
        /// </summary>
        public string lot_no { get; set; }

        /// <summary>
        /// 품목코드
        /// </summary>
        public string item_cd { get; set; }

        /// <summary>
        /// 포장단위
        /// </summary>
        public string keeping_unit { get; set; }

        /// <summary>
        /// 품목명
        /// </summary>
        public string item_nm { get; set; }

        /// <summary>
        /// 입고량
        /// </summary>
        public string receipt_qty { get; set; }

        /// <summary>
        /// 재고량
        /// </summary>
        public string stock_qty { get; set; }

        /// <summary>
        /// 상태코드
        /// </summary>
        public string test_status { get; set; }

        /// <summary>
        /// 시험상태
        /// </summary>
        public string test_status_nm { get; set; }

        /**
         * Grid 영역
         */
        /// <summary>
        /// 페이지
        /// </summary>
        public string page { get; set; }

        /// <summary>
        /// 순번
        /// </summary>
        public string seq { get; set; }

        /// <summary>
        /// COUNT
        /// </summary>
        public string COUNT { get; set; }

        /// <summary>
        /// 총 페이지
        /// </summary>
        public string tot_page { get; set; }

        /// <summary>
        /// 일련번호
        /// </summary>
        public string item_issue_id { get; set; }

        /// <summary>
        /// 구분
        /// </summary>
        public string inout_type { get; set; }

        /// <summary>
        /// 일자
        /// </summary>
        public string issue_date { get; set; }

        /// <summary>
        /// 수량
        /// </summary>
        public string issue_qty { get; set; }

        public string first_page { get; set; }

    }

}
