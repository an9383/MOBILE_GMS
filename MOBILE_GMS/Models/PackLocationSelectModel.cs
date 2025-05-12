using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class PackLocationSelectModel
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
        /// 지함 바코드
        /// </summary>
        public string box_barcode_no { get; set; }
        
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
        /// 제조번호
        /// </summary>
        public string lot_no { get; set; } 
        /// <summary>
        /// 팩 크기
        /// </summary>
        public string pack_size { get; set; }

        /// <summary>
        /// 팩 크기2
        /// </summary>
        public string item_pack_size { get; set; }

        /// <summary>
        /// 위치
        /// </summary>
        public string location { get; set; }
        

        /// <summary>
        /// 재고
        /// </summary>
        public string stock_qty { get; set; }
        /// <summary>
        /// 단위
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 시험번호
        /// </summary>
        public string test_no { get; set; }
        
    }
}
