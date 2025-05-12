using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class CellStackModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 셀 코드
        /// </summary>
        public string cell_cd { get; set; }
        /// <summary>
        /// 셀 명
        /// </summary>
        public string cell_nm { get; set; }
        /// <summary>
        /// 창고 코드
        /// </summary>
        public string workroom_cd { get; set; }
        /// <summary>
        /// 창고 명
        /// </summary>
        public string workroom_nm { get; set; }
        /// <summary>
        /// 구역 코드
        /// </summary>
        public string zone_cd { get; set; }
        /// <summary>
        /// 구역 명
        /// </summary>
        public string zone_nm { get; set; }
        /// <summary>
        /// 팔레트 코드
        /// </summary>
        public string pallet_cd { get; set; }
        /// <summary>
        /// 팔레트 명
        /// </summary>
        public string pallet_nm { get; set; }
        /// <summary>
        /// 적치 체크여부
        /// </summary>
        public string ck { get; set; }
        /// <summary>
        /// 바코드
        /// </summary>
        public string receipt_pack_barcode { get; set; }
        /// <summary>
        /// 제품 코드
        /// </summary>
        public string item_cd { get; set; }
        /// <summary>
        /// 제품 명(품목명)
        /// </summary>
        public string item_nm { get; set; }
        /// <summary>
        /// 시험번호
        /// </summary>
        public string test_no { get; set; }
        /// <summary>
        /// 재고량
        /// </summary>
        public string receipt_pack_remain_qty { get; set; }
        /// <summary>
        /// 단위
        /// </summary>
        public string item_unit { get; set; }
        public string gubun { get; internal set; }
        public string user_id { get; internal set; }

    }
}
