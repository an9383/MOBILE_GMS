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
    public class CodeHelpService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public CodeHelpService(ILogger<Controller> logger)
        {
            _logger = logger;
        }
         
        internal List<CodeHelpModel> CodeHelpSearch(CodeHelpModel model)
        {
            _logger.LogInformation(" [ logger ] :  CellSelectService > GridSelectCell() Access : " + DateTime.Now);

            List<CodeHelpModel> list = new List<CodeHelpModel>();

            string SP_name = "SP_PDA_CodeHelp_V20"; //  procedure 명 
            string gubun = model.gubun;             //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@wherevalue:" + model.tb_wherevalue;
            param[1] = "@company_cd:" + Public_Function.company;
            param[2] = "@plant_cd:" + Public_Function.selectedPLANT; 
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CodeHelpModel cm = new CodeHelpModel();
                DataRow row = dt.Rows[i];
                cm.srch_cd1 = row["srch_cd1"].ToString();
                cm.srch_nm1 = row["srch_nm1"].ToString();
                cm.srch_cd2 = row["srch_cd2"].ToString();
                cm.srch_nm2 = row["srch_nm2"].ToString();

                list.Add(cm);
            }
            return list;
        }

        //ListCommonCode
        internal List<CodeHelpModel> ListCommonCode(CodeHelpModel model)
        {
            _logger.LogInformation(" [ logger ] :  CellSelectService > GridSelectCell() Access : " + DateTime.Now);

            List<CodeHelpModel> list = new List<CodeHelpModel>();

            string SP_name = "SP_GETMASTER";    //  procedure 명 
            string gubun = model.gb;                //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@gb:" + model.gb;
            param[1] = "@div:" + model.div;
            param[2] = "@strwhere:" + model.strwhere;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CodeHelpModel cm = new CodeHelpModel();
                DataRow row = dt.Rows[i];
                cm.keyfield = row["keyfield"].ToString();
                cm.displayfield = row["displayfield"].ToString();
                list.Add(cm);
            }
            return list;
        }
    }
}
