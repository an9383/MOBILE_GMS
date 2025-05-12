using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class AreaModel
    {
        /// <summary>
        /// 창고 코드
        /// </summary>
        public string workroom_cd { get; set; }
        /// <summary>
        /// 구역 코드
        /// </summary>
        public string zone_cd { get; set; }
        /// <summary>
        /// 셀 코드
        /// </summary>
        public string cell_cd { get; set; }


        /// <summary>
        /// 창고명
        /// </summary>
        public string workroom_nm { get; set; }
        /// <summary>
        /// 구역명
        /// </summary>
        public string zone_nm { get; set; }
        /// <summary>
        /// 셀명
        /// </summary>
        public string cell_nm { get; set; }

        /// <summary>
        /// 바코드
        /// </summary>
        public string barcode { get; set; }
        /// <summary>
        /// 바코드(장소)
        /// </summary>
        public string area_barcode { get; set; }
        
        /// <summary>
        /// s/p의 구분 코드
        /// </summary>
        public string gubun { get; set; }
        /// <summary>
        /// user_cd 
        /// </summary>
        public string user_cd { get; set; }
    }
}
