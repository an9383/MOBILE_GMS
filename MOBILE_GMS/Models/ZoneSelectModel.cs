using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class ZoneSelectModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 구역코드
        /// </summary>
        public string zone_cd { get; set; }

        /// <summary>
        /// 구역명
        /// </summary>
        public string zone_nm { get; set; }

        /// <summary>
        /// 구역타입 값
        /// </summary>
        public string zone_type { get; set; }

        /// <summary>
        /// 구역타입
        /// </summary>
        public string zone_type_nm { get; set; }

        /// <summary>
        /// 우선순위
        /// </summary>
        public string zone_priority { get; set; }

        /// <summary>
        /// 구역상태 값
        /// </summary>
        public string zone_status { get; set; }

        /// <summary>
        /// 구역상태
        /// </summary>
        public string zone_status_nm { get; set; }

        /// <summary>
        /// 허용온도
        /// </summary>
        public string permit_temp { get; set; }

        /// <summary>
        /// 허용습도
        /// </summary>
        public string permit_hum { get; set; }

        /// <summary>
        /// 창고코드
        /// </summary>
        public string workroom_cd { get; set; }

        /// <summary>
        /// 창고명
        /// </summary>
        public string workroom_nm { get; set; }

        /// <summary>
        /// 총셀수
        /// </summary>
        public string cell_cnt { get; set; }

        /// <summary>
        /// 사용셀
        /// </summary>
        public string use_cell { get; set; }

        /// <summary>
        /// 빈셀
        /// </summary>
        public string empty_cell { get; set; }

        /// <summary>
        /// 비고
        /// </summary>
        public string zone_remark { get; set; }

    }
}
