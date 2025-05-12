using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs.Database;
using mobile_gms.Models;

namespace mobile_gms.Services
{
    public class PDA_ItemStockStatus_ITEMService : Controller
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public PDA_ItemStockStatus_ITEMService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<ProductStockStatusModel> StockStatus_Search(ProductStockStatusModel model)
        {
            _logger.LogInformation("[ logger ] : PDA_ItemStockStatus_ITEMService > StackStandbySearch() Access : " + DateTime.Now);

            List<ProductStockStatusModel> list = new List<ProductStockStatusModel>();

            Console.WriteLine(model);

            string SP_name = "SP_ItemStockStatus";
            string gubun = "T1S";
            string[] param = new string[2];
            param[0] = "@s_item:" + model.item_cd;
            param[1] = "@use_ck:" + model.check;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            Console.WriteLine(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ProductStockStatusModel sm = new ProductStockStatusModel();
                DataRow row = dt.Rows[i];

                sm.item_cd = row["item_cd"].ToString();                     // 코드
                sm.item_nm = row["item_nm"].ToString();                     // 품목명
                sm.item_lot_size = row["item_lot_size"].ToString();         // 포장단위
                sm.prod_qty_sum = row["prod_qty_sum"].ToString();           //생산량
                sm.etc_in_qty_sum = row["etc_in_qty_sum"].ToString();       // 총 기타 입고량
                sm.issue_qty_sum = row["issue_qty_sum"].ToString();         // 총 출고량
                sm.etc_out_qty_sum = row["etc_out_qty_sum"].ToString();     // 총 기타 출고량
                sm.theory_qty = row["theory_qty"].ToString();               // 이론재고량
                sm.stock_qty_sum = row["stock_qty_sum"].ToString();         // 재고량
                sm.stock_qty_chk = row["stock_qty_chk"].ToString();         //
                sm.prod_qty_plan = row["prod_qty_plan"].ToString();         // 입고예정량

                list.Add(sm);
            }

            return list;
        }
    }
}
