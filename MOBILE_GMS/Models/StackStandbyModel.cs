using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class StackStandbyModel
    {
        /// <summary>
        /// 바코드 정보
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 팩 바코드
        /// </summary>
        public string receipt_pack_barcode { get; set; }

        /// <summary>
        /// 품목 코드 
        /// </summary>
        public string item_cd { get; set; }
        /// <summary>
        /// 품목명 
        /// </summary>
        public string item_nm { get; set; }
        /// <summary>
        /// s/p 구분값
        /// </summary>
        public string gubun { get; set; }
        /// <summary>
        /// s/p 구분값
        /// </summary>
        public string standby_gubun { get; set; }
        /// <summary>
        /// 시험번호
        /// </summary>
        public string test_no { get; set; }
        /// <summary>
        /// 팩 순서
        /// </summary>
        public string receipt_pack_seq { get; set; }
        /// <summary>
        /// 입고상태( 시험 상태 )
        /// </summary>
        public string receipt_status { get; set; }

        /// <summary>
        /// 창고
        /// </summary>
        public string workroom_nm { get; set; }
        /// <summary>
        /// 구역
        /// </summary>
        public string zone_nm { get; set; }
        /// <summary>
        /// 셀
        /// </summary>
        public string cell_nm { get; set; }
        /// <summary>
        /// 재고
        /// </summary>
        public string remain_qty { get; set; }
        
    }
}
