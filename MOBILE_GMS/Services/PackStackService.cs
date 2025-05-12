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
    public class PackStackService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();  

        public PackStackService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public AreaModel SelectArea(AreaModel model)
        {

            string SP_name = "SP_PDA_AreaInfo"; // procedure 명 
            string gubun = "Area"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);
            AreaModel pm = new AreaModel();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                pm.barcode = model.barcode;
                pm.workroom_cd = row["workroom_cd"].ToString();
                pm.workroom_nm = row["workroom_nm"].ToString();
                pm.zone_cd = row["zone_cd"].ToString();
                pm.zone_nm = row["zone_nm"].ToString();
                pm.cell_cd = row["cell_cd"].ToString();
                pm.cell_nm = row["cell_nm"].ToString();

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

        public string StackPack(AreaModel model)
        {

            string SP_name = "SP_PDA_PackStack"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[4];
            param[0] = "@workroom_cd:" + model.workroom_cd;
            param[1] = "@zone_cd:" + model.zone_cd;
            param[2] = "@cell_cd:" + model.cell_cd;
            param[3] = "@receipt_pack_barcode:" + model.barcode;

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);
             
            return dt;
        }
         
        public string StackBox(AreaModel model)
        {

            string SP_name = "SP_PDA_PackStack"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[5];
            param[0] = "@workroom_cd:" + model.workroom_cd;
            param[1] = "@zone_cd:" + model.zone_cd;
            param[2] = "@cell_cd:" + model.cell_cd;
            param[3] = "@receipt_pack_barcode:" + model.barcode;
            param[4] = "@user_cd:" + model.user_cd;
            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }

    }
}
