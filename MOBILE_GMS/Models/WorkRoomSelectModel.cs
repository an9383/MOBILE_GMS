using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class WorkRoomSelectModel
    {
        /// <summary>
        /// 바코드 정보1
        /// </summary>
        public string barcode { get; set; }

        /// <summary>
        /// 창고코드
        /// </summary>
        public string workroom_cd { get; set; }

        /// <summary>
        /// 창고명
        /// </summary>
        public string workroom_nm { get; set; }

        /// <summary>
        /// 청정도 등급
        /// </summary>
        public string cleanness_cd { get; set; }

        /// <summary>
        /// 창고 종류 코드
        /// </summary>
        public string workroom_type { get; set; }

        /// <summary>
        /// 창고 종류
        /// </summary>
        public string workroom_type_nm { get; set; }

        /// <summary>
        /// 창고 구분 코드
        /// </summary>
        public string warehouse_type { get; set; }

        /// <summary>
        /// 창고 구분
        /// </summary>
        public string warehouse_type_nm { get; set; }

        /// <summary>
        /// 창고 상태 코드
        /// </summary>
        public string workroom_status { get; set; }

        /// <summary>
        /// 창고 상태
        /// </summary>
        public string workroom_status_nm { get; set; }

        /// <summary>
        /// dispaly 순서
        /// </summary>
        public string display_seq { get; set; }

        /// <summary>
        /// 허용 온도
        /// </summary>
        public string permit_temp { get; set; }

        /// <summary>
        /// 허용 습도
        /// </summary>
        public string permit_hum { get; set; }

        /// <summary>
        /// 구역 수
        /// </summary>
        public string zone_cnt { get; set; }

        /// <summary>
        /// 적치한계
        /// </summary>
        public string cell_cnt { get; set; }

        /// <summary>
        /// 적치수
        /// </summary>
        public string use_cell { get; set; }

    }
}
