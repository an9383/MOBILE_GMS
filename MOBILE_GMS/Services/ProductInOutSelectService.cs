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
    public class ProductInOutSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public ProductInOutSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public ProductInOutSelectModel ProductInfo(ProductInOutSelectModel productModel)
        {
            string SP_name = "SP_PDA_ProductInOutSelect"; // procedure 명 
            string gubun = "Select"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_cd:" + productModel.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);
            
            ProductInOutSelectModel pm = new ProductInOutSelectModel();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                pm.order_no = row["order_no"].ToString();
                pm.order_proc_id = row["order_proc_id"].ToString();
                pm.packing_result_id = row["packing_result_id"].ToString();
                pm.box_barcode_no = row["box_barcode_no"].ToString();
                pm.lot_no = row["lot_no"].ToString();
                pm.item_cd = row["item_cd"].ToString();
                pm.item_nm = row["item_nm"].ToString();
                pm.keeping_unit = row["keeping_unit"].ToString();
                pm.receipt_qty = row["receipt_qty"].ToString();
                pm.stock_qty = row["stock_qty"].ToString();
                pm.test_status = row["test_status"].ToString();
                pm.test_status_nm = row["test_status_nm"].ToString();
            }

            return pm;
        }

        public List<ProductInOutSelectModel> GridSelect(ProductInOutSelectModel productModel)
        {
            _logger.LogInformation(" [ logger ] :  ProductInOutSelectService > GridSelect() Access : " + DateTime.Now);

            List<ProductInOutSelectModel> ProductList = new List<ProductInOutSelectModel>();

            string SP_name = "SP_PDA_ProductInOutSelect"; // procedure 명 
            string gubun = "GridSelect"; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@barcode_cd:" + productModel.box_barcode_no;
            param[1] = "@page:" + productModel.page;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductInOutSelectModel pm = new ProductInOutSelectModel();
                DataRow row = dt.Rows[i];
                
                pm.item_issue_id = row["item_issue_id"].ToString();
                pm.inout_type = row["inout_type"].ToString();
                pm.issue_date = row["issue_date"].ToString();
                pm.issue_qty = row["issue_qty"].ToString();
                pm.seq = row["seq"].ToString();
                //pm.COUNT = row["COUNT"].ToString();
                //pm.page = row["page"].ToString();
                //pm.tot_page = row["tot_page"].ToString();
                //							

                ProductList.Add(pm);
            }

            return ProductList;
        }
    }
}
