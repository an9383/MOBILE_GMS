using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class Product_StackStandby2Service
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public Product_StackStandby2Service(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<Product_StackStandbyModel> Product_StackStandby2Search(Product_StackStandbyModel model)
        {

            List<Product_StackStandbyModel> list = new List<Product_StackStandbyModel>();

            string SP_name = "SP_PDA_Product_StackStandby2"; //  procedure 명 
            string gubun = model.gubun;             //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@item_cd:" + model.item_cd;
            param[1] = "@item_nm:" + model.item_nm;
            param[2] = "@lot_no:" + model.lot_no;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Product_StackStandbyModel cm = new Product_StackStandbyModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.box_barcode_no = row["box_barcode_no"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                cm.unit= row["UNIT"].ToString();
                list.Add(cm);
            }
            return list;
        }
    }
}
