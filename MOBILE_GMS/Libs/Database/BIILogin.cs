using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace mobile_gms.Libs.Database
{
	/// <summary>
	/// BIILogin에 대한 요약 설명입니다.
	/// </summary>
	public class BIILogin
	{
		private string _user_id;
		private string _pass;
		private string _user_id_nm;
		private string _user_cd;
		private string _user_nm;
		private string _dept_nm;
		private string _dept_cd;
		private string _company;
		private string _product_type;
		private string _version;
		private string _emp_charge;

		private string _end_time;
		private string _new_user;

		#region	//접근자
		public string user_id
		{
			set 
			{
				_user_id=value;
			}
		}

		public string pass
		{	
			set
			{
				_pass=value;
			}
		}

		public string user_id_nm
		{
			get
			{
				return _user_id_nm;
			}
		}

		public string user_cd
		{
			get
			{
				return _user_cd;
			}
		}

		public string user_nm
		{
			get
			{
				return _user_nm;
			}
		}
		public string dept_nm
		{
			get
			{
				return _dept_nm;
			}
		}

		public string log
		{
			get
			{
				return ID_Search();
			}
		}
		public string dept_cd
		{
			get
			{
				return _dept_cd;
			}
		}

		public string company
		{
			get 
			{
				return _company;
			}
		}

		public string product_type
		{
			get
			{
				return _product_type;
			}
		}

		public string version
		{	
			get
			{
				return _version;
			}
		}

		public string cv
		{
			get
			{
				return CV_Search();
			}
		}

		public string emp_charge
		{
			get
			{
				return _emp_charge;
			}
		}

		public string end_time
		{
			get
			{
				return _end_time;
			}
		}

		public string new_user
		{
			get
			{
				return _new_user;
			}
		}
		#endregion

		public BIILogin()
		{
            //
		}

		//private int ID_Search(string user_id,string pass, out string user_nm,out string dept_nm)
		#region //사용자 조회
		private string ID_Search()
		{
			try
			{
				DataSet myDataSet=CheckLogin(_user_id,_pass);

				if(myDataSet.Tables[0].Rows.Count==0)
				{
					return "NO";
				}
				else if(""==myDataSet.Tables[0].Rows[0]["user_id"].ToString().Trim())
				{
					return "_NO";
				}
				else
				{
					_user_id_nm=myDataSet.Tables[0].Rows[0]["user_id_nm"].ToString().Trim();
					_user_cd=myDataSet.Tables[0].Rows[0]["user_cd"].ToString().Trim();
					_user_nm=myDataSet.Tables[0].Rows[0]["user_nm"].ToString().Trim();
					_dept_cd=myDataSet.Tables[0].Rows[0]["user_dept_cd"].ToString().Trim();
					_dept_nm=myDataSet.Tables[0].Rows[0]["user_dept_nm"].ToString().Trim();
					_emp_charge=myDataSet.Tables[0].Rows[0]["emp_charge"].ToString().Trim();
					_end_time=myDataSet.Tables[0].Rows[0]["end_time"].ToString().Trim();
					_new_user=myDataSet.Tables[0].Rows[0]["new_user"].ToString().Trim();
					
					return "OK";
				}
			}
			catch(Exception e)
			{
				string message = "Error : "+ e.Message.ToString();
				return message;
			}
		}

		#endregion

		#region 사용자 갱신(NewUser --> 'N')
		public bool  RenewalUser()
		{
            DbAgent myDbAgent = new DbAgent("", "", System.Data.CommandType.StoredProcedure, Public_Function.selectedDB);

			try
			{
				myDbAgent.CommandText="SP_Login"; //Login 프로시저이름
				myDbAgent.MyCommand.Parameters.Clear();	//sp를 시작하기전 파라메터 clear
			
				myDbAgent.MyCommand.Parameters.AddWithValue("@YorN","U");
                myDbAgent.MyCommand.Parameters.AddWithValue("@user_id",_user_id);

                //2012.04.08 최석중 추가 (전체적으로 사업장 반영, 로그인 사원 추가하여 audit trail에서 사용)
                myDbAgent.MyCommand.Parameters.AddWithValue("@sys_plant_cd", Public_Function.selectedPLANT);
                myDbAgent.MyCommand.Parameters.AddWithValue("@sys_emp_cd", Public_Function.User_cd);

				myDbAgent.ExcuteNonQuery();

			}
			catch
			{
				return false;
			}

			return true;
		}
		#endregion

		#region    //사용자 check
		private DataSet CheckLogin(string user_id, string Pass)
		{
			DbAgent myDbAgent = new DbAgent("", "", System.Data.CommandType.StoredProcedure, Public_Function.selectedDB);

			myDbAgent.CommandText = "SP_Login"; //Login 프로시저이름
			myDbAgent.MyCommand.Parameters.Clear(); //sp를 시작하기전 파라메터 clear

			// UTF 인코딩 
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			var estEncoding = Encoding.GetEncoding(1252);
			var utf = Encoding.UTF8;

			user_id = utf.GetString(Encoding.Convert(estEncoding, utf, estEncoding.GetBytes(user_id)));
			Pass = utf.GetString(Encoding.Convert(estEncoding, utf, estEncoding.GetBytes(Pass)));

			myDbAgent.MyCommand.Parameters.AddWithValue("@YorN", "S");
			myDbAgent.MyCommand.Parameters.AddWithValue("@user_id", Encryption.Encrypt("100", user_id, true));
			myDbAgent.MyCommand.Parameters.AddWithValue("@pass", Encryption.Encrypt("100", Pass, true));
			
			myDbAgent.MyCommand.Parameters.AddWithValue("@sys_emp_cd", "a2003850");
			myDbAgent.MyCommand.Parameters.AddWithValue("@sys_plant_cd", "PC001");
			myDbAgent.MyCommand.Parameters.AddWithValue("@message", "");

			return myDbAgent.ExcuteDataSet();
		}
		
		#endregion

		#region //사용자 조회
		private string CV_Search()
		{
			try
			{
				DataSet myDataSet=CV_Check();

				if(myDataSet.Tables.Count != 3)
				{
					return "NO";
				}
				else
				{
					_product_type = myDataSet.Tables[0].Rows[0][0].ToString();
					_version = myDataSet.Tables[1].Rows[0][0].ToString();
					_company = myDataSet.Tables[2].Rows[0][0].ToString();
					return "OK";
				}
			}
			catch(Exception e)
			{
				string message = "Error : "+ e.Message.ToString();
				return message;
			}
		}

		#endregion

		#region	//프로그램 버젼 및 상호 check
		private DataSet CV_Check()
		{
            DbAgent myDbAgent = new DbAgent("", "", System.Data.CommandType.StoredProcedure, Public_Function.selectedDB);

			myDbAgent.CommandText="SP_Login"; //Login 프로시저이름
			myDbAgent.MyCommand.Parameters.Clear();	//sp를 시작하기전 파라메터 clear
			
			myDbAgent.MyCommand.Parameters.AddWithValue("@Gubun","SF");

            //2012.04.08 최석중 추가 (전체적으로 사업장 반영, 로그인 사원 추가하여 audit trail에서 사용)
            myDbAgent.MyCommand.Parameters.AddWithValue("@sys_plant_cd", Public_Function.selectedPLANT);
            myDbAgent.MyCommand.Parameters.AddWithValue("@sys_emp_cd", Public_Function.User_cd);

			return myDbAgent.ExcuteDataSet();
		}
		#endregion

	}
}
