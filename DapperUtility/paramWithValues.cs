using System.Data;

namespace DapperUtility
{
    /// <summary>
    /// This class is used as a structure for sending parameters in a stored procedure
    /// </summary>
    public class paramWithValues
    {
        /// <summary>
        /// Param name
        /// </summary>
        public string param { get; set; }
        /// <summary>
        /// Param value
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// Param direction: Usually In
        /// </summary>
        public ParameterDirection paramDirection { get; set; }
        /// <summary>
        /// In case of output the Db type is used
        /// </summary>
        public DbType dbType { get; set; }

        /// <summary>
        /// Param initializer
        /// </summary>
        public paramWithValues()
        {

        }

        /// <summary>
        /// Param of string type
        /// </summary>
        /// <param name="_param"></param>
        /// <param name="_value"></param>
        /// <param name="_paramDirection"></param>
        /// <param name="_dbType"></param>
        public paramWithValues(string _param, string _value, ParameterDirection _paramDirection = ParameterDirection.Input, DbType _dbType = DbType.String)
        {
            param = _param;
            value = _value;
            paramDirection = _paramDirection;
            dbType = _dbType;
        }

        /// <summary>
        /// Param of int type
        /// </summary>
        /// <param name="_param"></param>
        /// <param name="_value"></param>
        /// <param name="_paramDirection"></param>
        /// <param name="_dbType"></param>
        public paramWithValues(string _param, int _value, ParameterDirection _paramDirection = ParameterDirection.Input, DbType _dbType = DbType.String)
        {
            param = _param;
            value = _value.ToString();
            paramDirection = _paramDirection;
            dbType = _dbType;
        }

        /// <summary>
        /// Param of long type
        /// </summary>
        /// <param name="_param"></param>
        /// <param name="_value"></param>
        /// <param name="_paramDirection"></param>
        /// <param name="_dbType"></param>
        public paramWithValues(string _param, long _value, ParameterDirection _paramDirection = ParameterDirection.Input, DbType _dbType = DbType.String)
        {
            param = _param;
            value = _value.ToString();
            paramDirection = _paramDirection;
            dbType = _dbType;
        }

        /// <summary>
        /// Param of double type
        /// </summary>
        /// <param name="_param"></param>
        /// <param name="_value"></param>
        /// <param name="_paramDirection"></param>
        /// <param name="_dbType"></param>
        public paramWithValues(string _param, double _value, ParameterDirection _paramDirection = ParameterDirection.Input, DbType _dbType = DbType.String)
        {
            param = _param;
            value = _value.ToString();
            paramDirection = _paramDirection;
            dbType = _dbType;
        }
    }
}
