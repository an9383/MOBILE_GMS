using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class MaterialInOutSelectModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 입고 번호
        /// </summary>
        public string receipt_no { get; set; }

        /// <summary>
        /// 입고id
        /// </summary>
        public string receipt_id { get; set; }

        /// <summary>
        /// 포장번호
        /// </summary>
        public string receipt_pack_seq { get; set; }

        /// <summary>
        /// 품목 코드
        /// </summary>
        public string item_cd { get; set; }

        /// <summary>
        /// 품목명
        /// </summary>
        public string item_nm { get; set; }

        /// <summary>
        /// 입고상태코드
        /// </summary>
        public string receipt_status { get; set; }

        /// <summary>
        /// 시험번호
        /// </summary>
        public string test_no { get; set; }//

        /// <summary>
        /// 입고상태값
        /// </summary>
        public string receipt_status_nm { get; set; }

        /// <summary>
        /// 입고량
        /// </summary>
        public string receipt_pack_qty { get; set; }

        /// <summary>
        /// 재고량
        /// </summary>
        public string receipt_pack_remain_qty { get; set; }

        /// <summary>
        /// 보관단위
        /// </summary>
        public string keeping_unit { get; set; }

        /// <summary>
        /// 바코드
        /// </summary>
        public string receipt_pack_barcode { get; set; }

        /// <summary>
        /// 구분
        /// </summary>
        public string receipt_type_nm { get; set; }

        /// <summary>
        /// 일자
        /// </summary>
        public string receipt_date { get; set; }

        /// <summary>
        /// 수량
        /// </summary>
        public string receipt_qty { get; set; }

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
        /// 페이지
        /// </summary>
        public string page { get; set; }
    }
}
