using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace mobile_gms.Services
{
    internal class PDA_StockStatus2_P_itemService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public PDA_StockStatus2_P_itemService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        internal List<StockStatusModel> StockStatus_Search(StockStatusModel model)
        {
            _logger.LogInformation("[ logger ] : PDA_StockStatus2_M_itemService > StackStandbySearch() Access : " + DateTime.Now);

            List<StockStatusModel> list = new List<StockStatusModel>();

            string SP_name = "SP_StockStatus2";  // Procedure명
            string gubun = "Select4";  // Gubun명
            string[] param = new string[4];
            param[0] = "@item:" + model.item_cd;
            param[1] = "s_gubun:" + model.s_gubun;
            param[2] = "s_gubun2:" + model.s_gubun2;
            param[3] = "use_ck:" + model.check;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StockStatusModel sm = new StockStatusModel();
                DataRow row = dt.Rows[i];
                sm.item_cd = row["item_cd"].ToString();                         // 코드
                sm.item_nm = row["item_nm"].ToString();                         // 품목명
                sm.item_unit = row["item_unit"].ToString();                     // 단위
                sm.receipt_ye_qty = row["receipt_ye_qty"].ToString();           // 입고예정수량
                sm.receipt_remain_qty = row["receipt_remain_qty"].ToString();   // 재고량
                sm.receipt_reserve_qty = row["receipt_reserve_qty"].ToString(); // 출고예정량
                sm.available_inventory = row["available_inventory"].ToString(); // 가용재고량
                sm.theory_qty = row["theory_qty"].ToString();                   // 이론재고량
                sm.check = row["check"].ToString();                             // 체크

                list.Add(sm);
            }
            return list;
        }
    }
}