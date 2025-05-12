using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class MaterialModel
    {
        /// <summary>
        /// 재고량(팩 수량)
        /// </summary>
        public string receipt_pack_remain_qty { get; set; }
        /// <summary>
        /// 입고상태코드
        /// </summary>
        public string receipt_status { get; set; }
        /// <summary>
        /// 입고상태값
        /// </summary>
        public string receipt_status_nm { get; set; }
        /// <summary>
        /// 시험번호
        /// </summary>
        public string test_no { get; set; }
        /// <summary>
        /// 입고 팩 순서
        /// </summary>
        public string receipt_pack_seq { get; set; }
        /// <summary>
        /// 입고 id
        /// </summary>
        public string receipt_id { get; set; }


        /// <summary>
        /// 입고 번호
        /// </summary>
        public string receipt_no { get; set; }


        /// <summary>
        /// 바코드
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 품목 코드
        /// </summary>
        public string item_cd { get; set; }

        /// <summary>
        /// 품목 명
        /// </summary>
        public string item_nm { get; set; }



        /// <summary>
        /// 단위
        /// </summary>
        public string keeping_unit { get; set; }

        /// <summary>
        /// 사용자 코드
        /// </summary>
        public string user_cd { get; set; }
        /// <summary>
        /// 입고 타입 코드
        /// </summary>
        public string in_type { get; set; }
        /// <summary>
        /// 출고 타입 코드
        /// </summary>
        public string out_type { get; set; }

        /// <summary>
        /// 입고 수량
        /// </summary>
        public string in_qty { get; set; }

        /// <summary>
        /// 출고 수량
        /// </summary>
        public string out_qty { get; set; }
        /// <summary>
        /// 입고 일자
        /// </summary>
        public string in_date { get; set; }
        /// <summary>
        /// 출고 일자
        /// </summary>
        public string out_date { get; set; }
        /// <summary>
        /// 비고(메모)
        /// </summary>
        public string in_remark { get; set; }


    }
}
