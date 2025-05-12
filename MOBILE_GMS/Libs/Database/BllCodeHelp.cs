namespace mobile_gms.Libs.Database
{
	/// <summary>
	/// BllCodeHelp에 대한 요약 설명입니다.
	/// </summary>
	public class BllCodeHelp
	{

		private DbAgent myDbAgent;

		public BllCodeHelp()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
            myDbAgent = new DbAgent("", "", System.Data.CommandType.StoredProcedure, Public_Function.selectedDB);
		}

		#region Data 관련 함수
		//코드헬프를 위한 각종마스터 조회
		public System.Data.DataTable GetData(string SP_name, string strsql)
		{
			try
			{
				myDbAgent.CommandText = SP_name;
				myDbAgent.MyCommand.Parameters.Clear(); // SP를 새로 시작하기 위해 파라메터 Clear
				myDbAgent.MyCommand.Parameters.AddWithValue("@strsql", strsql);
			}
			finally { }
			return myDbAgent.ExcuteDataSet().Tables[0];
		}
	
		#endregion
	}
}
