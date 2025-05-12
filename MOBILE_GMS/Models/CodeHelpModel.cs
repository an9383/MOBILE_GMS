using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class CodeHelpModel
    {
        /// <summary>
        /// 품목 코드
        /// </summary>
        public string srch_cd1 { get; set; }
        /// <summary>
        /// 품목 명칭
        /// </summary>
        public string srch_nm1 { get; set; }
        /// <summary>
        /// 품목 코드2
        /// </summary>
        public string srch_cd2 { get; set; }
        /// <summary>
        /// 품목 명칭2
        /// </summary>
        public string srch_nm2 { get; set; }
        /// <summary>
        /// 검색창 제목
        /// </summary>
        public string srchTitle { get; set; }
        /// <summary>
        /// s/p 구분값
        /// </summary>
        public string gubun { get; set; }
        /// <summary>
        /// 검색어
        /// </summary>
        public string tb_wherevalue { get; set; }
        /// <summary>
        /// 구분값(sp)
        /// </summary>
        public string gb { get; set; }
        /// <summary>
        /// 구분값2(sp)
        /// </summary>
        public string div { get; set; }
        /// <summary>
        /// 검색어
        /// </summary>
        public string strwhere { get; set; }

        /// <summary>
        /// 키-코드
        /// </summary>
        public string keyfield { get; set; }
        /// <summary>
        /// 키-명칭
        /// </summary>
        public string displayfield { get; set; }

    }
}
