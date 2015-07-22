using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ZFrameCore.Common;
using ZFrameCore.Entity;

namespace ZFrameCore.BLL
{
    public class TBLLBase<EntityObjectType>
         where EntityObjectType : TEntityBase
    {

        #region 全局变量

        //object _LoginData ;
        ///// <summary>
        ///// 日志实体
        ///// </summary>
        //public object LoginData
        //{
        //    get { return _LoginData; }
        //    set { _LoginData = value; }
        //}


        Boolean _IsLogicDelete = true;
        /// <summary>
        /// 是否逻辑删除
        /// </summary>
        public Boolean IsLogicDelete
        {
            get { return _IsLogicDelete; }
            set { _IsLogicDelete = value; }
        }

        public String DBConnectString
        {
            get
            {
                return ZFrameDAL.TConnConfig.SQLConnStr;
            }
            set
            {
                ZFrameDAL.TConnConfig.SQLConnStr = value;
            }
        }

        /// <summary>
        /// 当前操作者ID
        /// </summary>
        public String CurrentUPU { get; set; }

        #endregion

        #region 原生查询SQL语句组装

        /// <summary>
        /// SQL Where 条件集合(默认业务对象中定义的默认SQL条件也自动解析于此，前台可自行添加)
        /// </summary>
        public String WhereStr
        {
            get;
            set;
        }
        /// <summary>
        /// SQL 排序字段集合默认业务对象中定义的默认SQL排序也自动解析于此，前台可自行添加)
        /// </summary>
        public String OrderStr
        {
            get;
            set;
        }

        public String TempOrderStr
        {
            get;
            set;
        }

        String _SQLString;


        /// <summary>
        /// 基础查询SQL语句
        /// </summary>
        public String SQLString
        {
            get
            {
                String whereStr = String.IsNullOrEmpty(WhereStr) ? "" : " WHERE " + WhereStr;
                String orderStr = String.IsNullOrEmpty(OrderStr) ? "" : " ORDER BY " + OrderStr;
                return _SQLString + whereStr + orderStr;
            }
            set
            {

                _SQLString = value;
            }
        }
        /// <summary>
        /// 基本导出SQL
        /// </summary>
        //public String ExportSQLString
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region 过滤排序分页查询SQL
        //public String QueryFilterSortSQL
        //{
        //    get;
        //    set;
        //}
        //public String WhereFilterStr
        //{
        //    get;
        //    set;
        //}
        //public String OrderFilterStr
        //{
        //    get;
        //    set;
        //}
        //public String QueryForFilterSQLString(String whereStrFilter, String orderStrFilter)
        //{
        //    if (String.IsNullOrEmpty(whereStrFilter) && String.IsNullOrEmpty(orderStrFilter))
        //    {
        //        this.QueryFilterSortSQL = "";
        //        this.WhereFilterStr = "";
        //        this.OrderFilterStr = "";
        //        return this.SQLString;
        //    }
        //    else
        //    {

        //        String TempWhere = String.IsNullOrEmpty(this.WhereStr) ?
        //            this.WhereFilterStr : " WHERE " + this.WhereStr +
        //            (String.IsNullOrEmpty(whereStrFilter) ? "" : " AND " + whereStrFilter);
        //        String TempOrder = String.IsNullOrEmpty(this.OrderStr) ?
        //            this.OrderFilterStr : " ORDER BY " + this.OrderStr +
        //            (String.IsNullOrEmpty(orderStrFilter) ? "" : " , " + orderStrFilter);
        //        QueryFilterSortSQL = this._SQLString + TempWhere + TempOrder;
        //        return QueryFilterSortSQL;
        //    }
        //}
        //public String GetExportSQLString(String whereStrFilter, String orderStrFilter)
        //{
        //    String TempWhere = String.IsNullOrEmpty(this.WhereStr) ?
        //        this.WhereFilterStr : " WHERE " + this.WhereStr +
        //        (String.IsNullOrEmpty(whereStrFilter) ? "" : " AND " + whereStrFilter);
        //    String TempFilterStr = String.IsNullOrEmpty(this.OrderStr) ?
        //        this.OrderFilterStr : " ORDER BY " + this.OrderStr +
        //        (String.IsNullOrEmpty(orderStrFilter) ? "" : " , " + orderStrFilter);
        //    String ExportSQL = this.ExportSQLString + TempWhere + TempFilterStr;
        //    return ExportSQL;
        //}

        #endregion

        #region 实体操作 (查询 分页查询 插入 更新 删除)
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <returns></returns>
        public List<EntityObjectType> Select()
        {
            this.EntityList = ToList<EntityObjectType>(ZFrameDAL.TSqlHelper.ExecuteDataset(ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text, this.SQLString).Tables[0]);
            return this.EntityList;
        }

        /// <summary>
        /// 获取单条数据（主键）
        /// </summary>
        /// <param name="F_SN">主键</param>
        /// <returns></returns>
        public EntityObjectType SelectSingleEntityBySN(String F_SN)
        {
            List<EntityObjectType> ReturnList = ToList<EntityObjectType>(ZFrameDAL.TSqlHelper.ExecuteDataset(ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text, EntityToSQL.MakeSelectSingleRowBySN(typeof(EntityObjectType).Name, F_SN)).Tables[0]);
            if (ReturnList != null && ReturnList.Count != 0)
            {
                return ReturnList[0];
            }
            return null;
        }

        /// <summary>
        /// 获取多条数据
        /// </summary>
        /// <param name="WhereEntityObj">条件实体</param>
        /// <returns></returns>
        public List<EntityObjectType> SelectEntitiesByWhere(EntityObjectType WhereEntityObj)
        {
            List<EntityObjectType> ReturnList = ToList<EntityObjectType>(ZFrameDAL.TSqlHelper.ExecuteDataset(ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text, EntityToSQL.MakeSelectRowsByEntityWhere(WhereEntityObj)).Tables[0]);
            return ReturnList;
        }







        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页面容量</param>
        /// <param name="curPage">当前页码</param>
        /// <param name="count">输出数据总数</param>
        /// <param name="pageCount">输出页面总数</param>
        /// <returns></returns>
        public List<EntityObjectType> Select(int pageSize, int curPage, out int count, out int pageCount)
        {
            List<SqlParameter> Parems = new List<SqlParameter>();
            SqlParameter PStartPageIndex = new SqlParameter("@StartPageIndex", curPage);
            Parems.Add(PStartPageIndex);

            SqlParameter PPageCount = new SqlParameter("@PageCount", pageSize);
            Parems.Add(PPageCount);

            SqlParameter PSqlString = new SqlParameter("@SqlString ", this.SQLString);
            Parems.Add(PSqlString);

            SqlParameter POALlCount = new SqlParameter();
            POALlCount.ParameterName = "@ALlCount";
            POALlCount.Value = 0;
            POALlCount.Direction = ParameterDirection.Output;
            Parems.Add(POALlCount);

            SqlParameter PAllPageCount = new SqlParameter();
            PAllPageCount.ParameterName = "@AllPageCount";
            PAllPageCount.Value = 0;
            PAllPageCount.Direction = ParameterDirection.Output;
            Parems.Add(PAllPageCount);

            Int32 Execresult = 0;
            DataSet retutnDataSet = this.ExecProceureRetrunList("USP_PageForDataSource", Parems, out Execresult);
            count = Convert.ToInt32(POALlCount.Value);
            pageCount = Convert.ToInt32(PAllPageCount.Value);
            if (retutnDataSet.Tables.Count == 0)
            {
                return this.EntityList;
            }

            this.EntityList = ToList<EntityObjectType>(retutnDataSet.Tables[0]);
            return this.EntityList;

        }


        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="InsertObject"></param>
        /// <returns></returns>
        public Int32 Insert(EntityObjectType InsertObject, SqlTransaction sqlTransaction = null)
        {

            Int32 ExecReuslt = 0;
            if (sqlTransaction == null)
            {

                ExecReuslt = ZFrameDAL.TSqlHelper.ExecuteNonQuery(ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text, EntityToSQL.MakeInsertSQLString(InsertObject));
            }
            else
            {
                ExecReuslt = ZFrameDAL.TSqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, EntityToSQL.MakeInsertSQLString(InsertObject));
            }
            return ExecReuslt;
        }



        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="DeleteObject">删除对象</param>
        /// <returns></returns>
        public Int32 Delete(EntityObjectType DeleteObject, SqlTransaction sqlTransaction = null)
        {
            if (sqlTransaction == null)
            {
                Int32 ReturnInt = ZFrameDAL.TSqlHelper.ExecuteNonQuery(
                    ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text,
                    this.IsLogicDelete ? EntityToSQL.MakeLogicDeleteString(DeleteObject, CurrentUPU) : EntityToSQL.MakeDeleteString(DeleteObject));
                if (ReturnInt != 1) throw new Exception("删除错误");
                // this.EntityList.Remove(DeleteObject);
                return ReturnInt;
            }
            else
            {
                Int32 ReturnInt = ZFrameDAL.TSqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text,
                    this.IsLogicDelete ? EntityToSQL.MakeLogicDeleteString(DeleteObject, CurrentUPU) : EntityToSQL.MakeDeleteString(DeleteObject));
                if (ReturnInt != 1) throw new Exception("删除错误");
                //this.EntityList.Remove(DeleteObject);
                return ReturnInt;
            }
        }


        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="SaveObjcet"></param>
        /// <returns></returns>
        public Int32 Save(EntityObjectType SaveObjcet, SqlTransaction sqlTransaction = null)
        {
            if (sqlTransaction == null)
            {
                Int32 ReturnInt = ZFrameDAL.TSqlHelper.ExecuteNonQuery(
                   ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text,
                  EntityToSQL.MakeUpdateString(SaveObjcet));
                if (ReturnInt != 1) throw new Exception("保存错误");
                return ReturnInt;
            }
            else
            {
                Int32 ReturnInt = ZFrameDAL.TSqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, EntityToSQL.MakeUpdateString(SaveObjcet));
                if (ReturnInt != 1) throw new Exception("保存错误");
                return ReturnInt;
            }
        }



        /// <summary>
        /// 执行SQL(高阶)
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public Int32 ExecSQL(String SQLString, SqlTransaction sqlTransaction = null)
        {
            if (sqlTransaction == null)
            {
                return ZFrameDAL.TSqlHelper.ExecuteNonQuery(ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text, SQLString);
            }
            else
            {

                return ZFrameDAL.TSqlHelper.ExecuteNonQuery(sqlTransaction, CommandType.Text, SQLString);
            }
        }
        /// <summary>
        /// 执行SQL 返回数据集 (高阶)
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public DataSet ExecSQLReturnDataSet(String SQLString, SqlTransaction sqlTransaction = null)
        {
            if (sqlTransaction == null)
            {
                return ZFrameDAL.TSqlHelper.ExecuteDataset(ZFrameDAL.TConnConfig.SQLConnStr, CommandType.Text, SQLString);
            }
            else
            {

                return ZFrameDAL.TSqlHelper.ExecuteDataset(sqlTransaction, CommandType.Text, SQLString);
            }
        }
        /// <summary>
        /// 执行存过(高阶)
        /// </summary>
        /// <param name="ProceureName"></param>
        /// <param name="SQLParmeter"></param>
        /// <returns></returns>
        public Int32 ExecProceure(String ProceureName, List<SqlParameter> SQLParmeter, SqlTransaction sqlTransaction = null)
        {
            if (sqlTransaction == null)
            {
                return ZFrameDAL.TSqlHelper.ExecuteNonQuery(ZFrameDAL.TConnConfig.SQLConnStr, ProceureName, SQLParmeter.ToArray());
            }
            else
            {
                return ZFrameDAL.TSqlHelper.ExecuteNonQuery(sqlTransaction, ProceureName, SQLParmeter.ToArray());
            }

        }
        /// <summary>
        /// 执行存储过程返回DataSet
        /// </summary>
        /// <param name="ProceureName"></param>
        /// <param name="SQLParmeter"></param>
        /// <returns></returns>
        public DataSet ExecProceureRetrunList(String ProceureName, List<SqlParameter> SQLParmeter, out int ExecResult, SqlTransaction sqlTransaction = null, Boolean AutoAddReturnValue = true)
        {
            if (sqlTransaction == null)
            {
                return ZFrameDAL.TSqlHelper.ExecProceureRetrunDataSet(ZFrameDAL.TConnConfig.SQLConnStr, ProceureName, SQLParmeter, out ExecResult, AutoAddReturnValue);
            }
            else
            {
                return ZFrameDAL.TSqlHelper.ExecProceureRetrunDataSet(sqlTransaction, ProceureName, SQLParmeter, out ExecResult, AutoAddReturnValue);
            }
        }


        /// <summary>
        /// 事务中执行指定方法
        /// </summary>
        /// <param name="DelegateMethod">委托方法名</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <returns>执行成功标记 0 成功 -1 失败 失败后自动回滚</returns>
        public virtual Int32 TransactionDo(Action<SqlTransaction, Object> DelegateMethod, out String ErrorMessage, Object Arg)
        {
            using (SqlConnection connection = new SqlConnection(ZFrameDAL.TConnConfig.SQLConnStr))
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                try
                {

                    DelegateMethod(transaction, Arg);
                    transaction.Commit();
                    ErrorMessage = "";
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ErrorMessage = ex.Message;
                    return -1;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }
        /// <summary>
        /// 事务中执行指定方法
        /// </summary>
        /// <param name="DelegateMethod">委托方法名</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <returns>执行成功标记 0 成功 -1 失败 失败后自动回滚</returns>
        public virtual Int32 TransactionDo(Action<SqlTransaction> DelegateMethod, out String ErrorMessage)
        {
            using (SqlConnection connection = new SqlConnection(ZFrameDAL.TConnConfig.SQLConnStr))
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                try
                {

                    DelegateMethod(transaction);
                    transaction.Commit();
                    ErrorMessage = "";
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ErrorMessage = ex.Message;
                    return -1;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }
        #endregion

        #region 事务处理
        /// <summary>
        /// 事务中执行指定方法
        /// </summary>
        /// <param name="DelegateMethod">委托方法名</param>
        /// <param name="ErrorMessage">错误信息</param>
        /// <returns>执行成功标记 0 成功 -1 失败 失败后自动回滚</returns>
        public virtual Int32 TransactionDo(Action<SqlTransaction, Object> DelegateMethod, Object Arg, out String ErrorMessage)
        {
            using (SqlConnection connection = new SqlConnection(ZFrameDAL.TConnConfig.SQLConnStr))
            {
                connection.Open();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction();
                try
                {

                    DelegateMethod(transaction, Arg);
                    transaction.Commit();
                    ErrorMessage = "";
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ErrorMessage = ex.Message;
                    return -1;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

        }
        #endregion
        #region 对象列表容器
        List<EntityObjectType> _EntityList;
        /// <summary>
        /// 初始化数据列表
        /// </summary>
        public List<EntityObjectType> EntityList
        {
            get
            {
                return _EntityList;
            }
            set
            {
                _EntityList = value;
            }
        }

        /// <summary> 实体数据是否修改
        /// </summary>



        #endregion

        #region DataTable 实体化
        /// <summary>
        /// DataTable 转 List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SourceDataTable"></param>
        /// <returns></returns>
        public List<T> ToList<T>(DataTable SourceDataTable) where T : TEntityBase
        {
            return ToEntityByEmit.GetList<T>(SourceDataTable);
        }

        #endregion
    }
}
