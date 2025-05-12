using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mobile_gms.Controllers;
using mobile_gms.DataContext;
using mobile_gms.Libs;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class PackSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();  

        public PackSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public PackModel SelectPack(PackModel packModel)
        {

            string SP_name = "SP_PDA_PackSelect"; // procedure 명 
            string gubun = "Select_Pack"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_cd:" + packModel.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);


            PackModel pm = new PackModel();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                pm.barcode = packModel.barcode;
                pm.item_cd = row["item_cd"].ToString();
                pm.item_nm = row["item_nm"].ToString();
                pm.test_no = row["test_no"].ToString();
                pm.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();
                pm.workroom_cd = row["workroom_cd"].ToString();
                pm.receipt_status = row["receipt_status"].ToString();
                pm.receipt_status_nm = row["receipt_status_nm"].ToString();
                pm.issue_status = row["issue_status"].ToString();
                pm.issue_status_nm = row["issue_status_nm"].ToString();

            }


            return pm;
        }

        public List<PackModel> GridSelectPack(PackModel packModel)
        {

            _logger.LogInformation(" [ logger ] :  MenuService > ListMenu() Access : " + DateTime.Now);

            List<PackModel> menuList = new List<PackModel>();

            string SP_name = "SP_PDA_PackSelect"; // procedure 명 
            string gubun = "GridSelect_Pack"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_cd:" + packModel.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for(int i=0;i<dt.Rows.Count; i++)
            {
                PackModel mm = new PackModel();
                DataRow row = dt.Rows[i];
                mm.inout_type = row["inout_type"].ToString();
                mm.inout_qty = row["inout_qty"].ToString();
                mm.receipt_date = row["receipt_date"].ToString();

                menuList.Add(mm); 
            }

            return menuList;

        }
         
        public string PickSelectPack(PackModel model)
        {

            string SP_name = "SP_PDA_PackSelect"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_cd:" + model.barcode;

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }

        public string PickSelectBox(PackModel model)
        {

            string SP_name = "SP_PDA_PackSelect"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@barcode_cd:" + model.barcode;
            param[1] = "@user_cd:" + model.user_cd;

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }
    }
}
