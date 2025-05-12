using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class CellSelectModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }
        
        /// <summary>
        /// location
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 셀 코드
        /// </summary>
        public string cell_cd { get; set; }
        /// <summary>
        /// 셀 명
        /// </summary>
        public string cell_nm { get; set; }
        /// <summary>
        /// 셀 타입
        /// </summary>
        public string cell_type { get; set; }
        /// <summary>
        /// 셀 타입 명
        /// </summary>
        public string cell_type_nm { get; set; }
        /// <summary>
        /// 우선순위
        /// </summary>
        public string cell_priority { get; set; }
        /// <summary>
        /// 위치통로
        /// </summary>
        public string cell_isle { get; set; }
        public string cell_height { get; set; }
        public string cell_column { get; set; }
        /// <summary>
        /// 셀 상태
        /// </summary>
        public string cell_status { get; set; }
        /// <summary>
        /// 비고
        /// </summary>
        public string cell_remark { get; set; }
        /// <summary>
        /// 셀 상태 명
        /// </summary>
        public string cell_status_nm { get; set; }

        /// <summary>
        /// 팩 바코드
        /// </summary>
        public string pack_barcode { get; set; }
        /// <summary>
        /// 품목명
        /// </summary>
        public string item_nm { get; set; }
        /// <summary>
        /// 제조(시험번호)
        /// </summary>
        public string lot_no { get; set; }
        /// <summary>
        /// 재고량
        /// </summary>
        public string receipt_pack_remain_qty { get; set; }


        


    }
}
