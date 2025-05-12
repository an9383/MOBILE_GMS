using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class PackModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 바코드 정보2
        /// </summary>
        public string pack_barcode { get; set; }

        /// <summary>
        /// 품목 코드 정보
        /// </summary>
        public string item_cd { get; set; }
        /// <summary>
        /// 품목명 정보
        /// </summary>
        public string item_nm { get; set; }
        /// <summary>
        /// 시험No. 정보
        /// </summary>
        public string test_no { get; set; }
        /// <summary>
        /// 재고량(+ 단위 포함 )
        /// </summary>
        public string receipt_pack_remain_qty { get; set; }
        /// <summary>
        /// 적치 위치 정보
        /// </summary>
        public string workroom_cd { get; set; }

        /// <summary>
        /// 입고 상태명
        /// </summary>
        public string receipt_status_nm { get; set; }
        /// <summary>
        /// 입고 상태코드
        /// </summary>
        public string receipt_status { get; set; }


        /// <summary>
        /// 재고 상태명
        /// </summary>
        public string issue_status_nm { get; set; }
        /// <summary>
        /// 재고 상태코드
        /// </summary>
        public string issue_status { get; set; }



        /// <summary>
        /// 입고/출고 구분
        /// </summary>
        public string inout_type { get; set; }
        /// <summary>
        /// 입고/출고 수량
        /// </summary>
        public string inout_qty { get; set; }
        /// <summary>
        /// 입고/출고 일자
        /// </summary>
        public string receipt_date { get; set; }
        /// <summary>
        /// s/p 구분
        /// </summary>
        public string gubun { get; set; }
        /// <summary>
        /// user_cd
        /// </summary>
        public string user_cd { get; set; }
        
    }
}
