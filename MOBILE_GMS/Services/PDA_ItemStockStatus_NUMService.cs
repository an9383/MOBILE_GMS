using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class PDA_ItemStockStatus_NUMService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public PDA_ItemStockStatus_NUMService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<ProductStockStatusModel> ItemStockStatus_Search(ProductStockStatusModel model)
        {
            _logger.LogInformation(" [ logger ] :  PDA_ItemStockStatus_NUMService > ItemStockStatus_Search() Access : " + DateTime.Now);

            List<ProductStockStatusModel> list = new List<ProductStockStatusModel>();

            string SP_name = "SP_ItemStockStatus"; //  procedure 명 
            string gubun = "T3S";             //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@s_item:" + model.s_item;
            param[1] = "@s_lot_no:" + model.s_lot_no;
            param[2] = "@use_ck:" + model.use_ck;            

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductStockStatusModel pm = new ProductStockStatusModel();
                DataRow row = dt.Rows[i];
                pm.item_cd = row["item_cd"].ToString();                 // 코드
                pm.item_nm = row["item_nm"].ToString();                 // 품목명
                pm.item_lot_size = row["item_lot_size"].ToString();     // 포장단위
                pm.lot_no = row["lot_no"].ToString();                   // 제조번호
                pm.lot_date = row["lot_date"].ToString();               // 제조일자
                pm.prod_qty_sum = row["prod_qty_sum"].ToString();       // 생산량
                pm.etc_in_qty_sum = row["etc_in_qty_sum"].ToString();   // 기타 입고량
                pm.issue_qty_sum = row["issue_qty_sum"].ToString();     // 출고량
                pm.etc_out_qty_sum = row["etc_out_qty_sum"].ToString(); // 기타 출고량
                pm.prod_qty_plan = row["prod_qty_plan"].ToString();     // 입고예정량
                pm.stock_qty_sum = row["stock_qty_sum"].ToString();     // 재고량

                list.Add(pm);
            }
            return list;
        }
    }
}
