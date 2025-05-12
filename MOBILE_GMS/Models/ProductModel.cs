using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class ProductModel
    {
        /// <summary>
        /// 바코드
        public string barcode { get; set; }

        /// <summary>
        /// 바코드
        /// </summary>
        public string item_cd { get; set; }

        /// <summary>
        /// 바코드
        /// </summary>
        public string item_nm { get; set; }


        /// <summary>
        /// 제조번호
        /// </summary>
        public string lot_no { get; set; }


        /// <summary>
        /// 출하상태-명칭
        /// </summary>
        public string issue_status_nm { get; set; }

        /// <summary>
        /// 출하상태-코드
        /// </summary>
        public string issue_status { get; set; }

        /// <summary>
        /// 재고량
        /// </summary>
        public string stock_qty { get; set; }

        /// <summary>
        /// 단위
        /// </summary>
        public string keeping_unit { get; set; }

        /// <summary>
        /// 입고구분
        /// </summary>
        public string in_type { get; set; }
        /// <summary>
        /// 출고구분
        /// </summary>
        public string out_type { get; set; }

        /// <summary>
        /// 입고량
        /// </summary>
        public string in_qty { get; set; }
        /// <summary>
        /// 입고일자
        /// </summary>
        public string in_date { get; set; }
        /// <summary>
        /// 출고량
        /// </summary>
        public string out_qty { get; set; }
        /// <summary>
        /// 출고일자
        /// </summary>
        public string out_date { get; set; }
        /// <summary>
        /// 비고(메모)
        /// </summary>
        public string in_remark { get; set; }
        /// <summary>
        /// 사용자 코드
        /// </summary>
        public string user_cd { get; set; }

        
    }
}
