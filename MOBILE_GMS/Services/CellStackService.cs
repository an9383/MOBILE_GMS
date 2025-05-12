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
    public class CellStackService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        

        public CellStackService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public CellStackModel fncCellDataSearch(CellStackModel cellStackModel)
        {
            string _strSP_Name = "SP_PDA_CellStack";
            string gubun = "";
            string[] strParameter = new string[1];
            strParameter[0] = "@cell_cd:" + cellStackModel.barcode;

            //셀정보 조회
            gubun = "cell_Select";
            strParameter[0] = "@cell_cd:" + cellStackModel.cell_cd;

            DataTable dt = _bllSpExecute.SpExecuteTable(_strSP_Name, gubun, strParameter);
            
            CellStackModel cs = new CellStackModel();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cs.barcode = cellStackModel.barcode;
                cs.workroom_cd = row["workroom_cd"].ToString();
                cs.workroom_nm = row["workroom_nm"].ToString();
                cs.zone_cd = row["zone_cd"].ToString();
                cs.zone_nm = row["zone_nm"].ToString();
                cs.cell_cd = row["cell_cd"].ToString();
                cs.cell_nm = row["cell_nm"].ToString();
                cs.pallet_cd = row["pallet_cd"].ToString();
                cs.pallet_nm = row["pallet_nm"].ToString();
                cs.barcode = cellStackModel.barcode;
            }

            return cs;
        }

        public CellStackModel fncAreaDataSearch(CellStackModel cellStackModel)
        {
            string _strSP_Name = "SP_PDA_CellStack";
            string gubun = "";
            string[] strParameter = new string[1];

            //구역정보 조회
            if (cellStackModel.barcode != "" && cellStackModel.barcode.Contains("W"))
            {
                gubun = "workroom_Select";
                strParameter[0] = "@area_cd:" + cellStackModel.barcode;
            }
            else
            {
                gubun = "zone_Select";
                strParameter[0] = "@area_cd:" + cellStackModel.barcode;

            }

            //정보 조회
            DataTable dt = _bllSpExecute.SpExecuteTable(_strSP_Name, gubun, strParameter);
            
            CellStackModel cs = new CellStackModel();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cs.workroom_cd = row["workroom_cd"].ToString();
                cs.workroom_nm = row["workroom_nm"].ToString();
                cs.zone_cd = row["zone_cd"].ToString();
                cs.zone_nm = row["zone_nm"].ToString();
                cs.cell_cd = row["cell_cd"].ToString();
                cs.cell_nm = row["cell_nm"].ToString();
                cs.pallet_cd = row["pallet_cd"].ToString();
                cs.pallet_nm = row["pallet_nm"].ToString();
            }

            return cs;
        }

        public List<CellStackModel> fn_callPack_Select(CellStackModel cellStackModel)
        {
            // 적치 및 바코드
            _logger.LogInformation(" [ logger ] :  CellStackService > fn_callPack_Select() Access : " + DateTime.Now);

            List<CellStackModel> cellList = new List<CellStackModel>();

            string _strSP_Name = "SP_PDA_CellStack";
            string[] param = new string[2];
            param[0] = "@cell_cd:" + cellStackModel.cell_cd;
            param[1] = "@pallet_cd:" + cellStackModel.pallet_cd;

            //팩정보 조회
            string gubun = "pack_Select";
            DataTable dt = _bllSpExecute.SpExecuteTable(_strSP_Name, gubun, param);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                CellStackModel cs = new CellStackModel();

                cs.ck = row["ck"].ToString();
                cs.receipt_pack_barcode = row["receipt_pack_barcode"].ToString();
                cs.item_cd = row["item_cd"].ToString();
                cs.item_nm = row["item_nm"].ToString();
                cs.test_no = row["test_no"].ToString();
                cs.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();
                cs.item_unit = row["item_unit"].ToString();

                cellList.Add(cs);
            }

            return cellList;
        }

        public string PackStack(CellStackModel cellStackModel)
        {
            string SP_name = "SP_PDA_CellStack"; // procedure 명 
            string gubun = cellStackModel.gubun; // Gunbun 명
            string[] strParameter = new string[6];
            //param[0] = "@pack_barcode:" + cellStackModel.barcode;
            //param[1] = "@user_cd:" + cellStackModel.user_cd;

            if (cellStackModel.receipt_pack_barcode.ToString().Substring(0, 1).ToString() == Public_Function.BarcodePrefix_Pack)
            {
                gubun = "stack_pack"; // 구분

                strParameter[0] = "@receipt_pack_barcode:" + cellStackModel.receipt_pack_barcode.ToString();
                strParameter[1] = "@workroom_cd:" + cellStackModel.workroom_cd.ToString();
                strParameter[2] = "@zone_cd:" + cellStackModel.zone_cd.ToString();
                strParameter[3] = "@cell_cd:" + cellStackModel.cell_cd.ToString();
                strParameter[4] = "@pallet_cd:" + cellStackModel.pallet_cd.ToString();
                strParameter[5] = "@user_cd:" + Public_Function.User_cd;
            }
            // box 바코드로 적치 로직은 보류
            else
            {
                gubun = "stack_box"; // 구분

                strParameter[0] = "@receipt_pack_barcode:" + cellStackModel.receipt_pack_barcode.ToString();
                strParameter[1] = "@workroom_cd:" + cellStackModel.workroom_cd.ToString();
                strParameter[2] = "@zone_cd:" + cellStackModel.zone_cd.ToString();
                strParameter[3] = "@cell_cd:" + cellStackModel.cell_cd.ToString();
                strParameter[4] = "@pallet_cd:" + cellStackModel.pallet_cd.ToString();
                strParameter[5] = "@user_cd:" + Public_Function.User_cd;
            }

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, strParameter);

            return dt;
        }

        public List<CellStackModel> AddPack(CellStackModel cellStackModel)
        {
            // 리스트 추가
            _logger.LogInformation(" [ logger ] :  CellStackService > AddPack() Access : " + DateTime.Now);

            List<CellStackModel> cellList = new List<CellStackModel>();

            string _strSP_Name = "SP_PDA_CellStack";
            string[] param = new string[1];
            param[0] = "";

            //팩 또는 지함 정보 조회
            string gubun = "";
            if (cellStackModel.barcode.Contains("P"))
            {
                param[0] = "@receipt_pack_barcode:" + cellStackModel.barcode;
                gubun = "pack";

            } else if (cellStackModel.barcode.Contains("G"))
            {
                param[0] = "@box_barcode_no:" + cellStackModel.barcode;
                gubun = "box";
            }

            DataTable dt = _bllSpExecute.SpExecuteTable(_strSP_Name, gubun, param);
            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                CellStackModel cs = new CellStackModel();

                cs.ck = row["ck"].ToString(); // SP 결과값 무조건 1
                cs.receipt_pack_barcode = row["receipt_pack_barcode"].ToString();
                cs.item_cd = row["item_cd"].ToString();
                cs.item_nm = row["item_nm"].ToString();
                cs.test_no = row["test_no"].ToString();
                cs.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();
                cs.item_unit = row["item_unit"].ToString();

                cellList.Add(cs);
            }

            return cellList;
        }
    }
}
