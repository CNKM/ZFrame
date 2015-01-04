using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
using ZFrameCore.Entity;


namespace ZFrameCore.Common
{

    #region Emit DataTable => List<T>
    public static class ToEntityByEmit
    {
        public static List<T> GetList<T>(DataTable dt)
        {
            List<T> lst = new List<T>();
            if (dt == null)
            {
                return lst;
            }
            if (dt.Rows.Count == 0)
            {
                return lst;
            }
            DataTableEntityBuilder<T> eblist = DataTableEntityBuilder<T>.CreateBuilder(dt.Rows[0]);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(eblist.Build(dr));
            }
            dt.Dispose();
            dt = null;
            return lst;
        }

        public static ObservableCollection<T> GetObservableCollectionList<T>(DataTable dt)
        {
            ObservableCollection<T> lst = new ObservableCollection<T>();
            if (dt == null)
            {
                return lst;
            }
            if (dt.Rows.Count == 0)
            {
                return lst;
            }
            DataTableEntityBuilder<T> eblist = DataTableEntityBuilder<T>.CreateBuilder(dt.Rows[0]);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(eblist.Build(dr));
            }
            dt.Dispose();
            dt = null;
            return lst;
        }


        public class DataTableEntityBuilder<T>
        {
            private static readonly MethodInfo getValueMethod = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(int) });
            private static readonly MethodInfo isDBNullMethod = typeof(DataRow).GetMethod("IsNull", new Type[] { typeof(int) });
            private delegate T Load(DataRow dr);

            private Load handler;
            private DataTableEntityBuilder() { }

            public T Build(DataRow dr)
            {
                return handler(dr);
            }

            public static DataTableEntityBuilder<T> CreateBuilder(DataRow dr)
            {



                DataTableEntityBuilder<T> dynamicBuilder = new DataTableEntityBuilder<T>();
                DynamicMethod method = new DynamicMethod("DynamicCreateEntity", typeof(T), new Type[] { typeof(DataRow) }, typeof(T), true);
                ILGenerator generator = method.GetILGenerator();
                LocalBuilder result = generator.DeclareLocal(typeof(T));
                generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
                generator.Emit(OpCodes.Stloc, result);

                for (int i = 0; i < dr.ItemArray.Length; i++)
                {
                    PropertyInfo pi = typeof(T).GetProperty(dr.Table.Columns[i].ColumnName);
                    Label endIfLabel = generator.DefineLabel();
                    if (pi != null && pi.GetSetMethod() != null)
                    {

                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, i);
                        generator.Emit(OpCodes.Callvirt, isDBNullMethod);
                        generator.Emit(OpCodes.Brtrue, endIfLabel);
                        generator.Emit(OpCodes.Ldloc, result);
                        generator.Emit(OpCodes.Ldarg_0);
                        generator.Emit(OpCodes.Ldc_I4, i);
                        generator.Emit(OpCodes.Callvirt, getValueMethod);
                        generator.Emit(OpCodes.Unbox_Any, pi.PropertyType);
                        generator.Emit(OpCodes.Callvirt, pi.GetSetMethod());
                        generator.MarkLabel(endIfLabel);
                    }
                }
                generator.Emit(OpCodes.Ldloc, result);
                generator.Emit(OpCodes.Ret);
                dynamicBuilder.handler = (Load)method.CreateDelegate(typeof(Load));
                return dynamicBuilder;
            }
        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                // HERE IS WHERE THE ERROR IS THROWN FOR NULLABLE TYPES
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
              prop.PropertyType) ?? prop.PropertyType);
            }

            return table;
        }
    }
    #endregion

    #region Get SQL Stirng By Entity
    public static class EntityToSQL
    {
        #region 反射取值
        /// <summary>
        /// 获取实体属性值以及属性标记
        /// </summary>
        /// <param name="EntityObject">实体对象</param>
        /// <param name="PropertyName">属性名称</param>
        /// <param name="FieldType">输出 属性类型</param>
        /// <returns>属性值</returns>
        static Object GetEntityPropertyValue(object EntityObject, String PropertyName, out EntityPropertyType FieldType)
        {
            BindingFlags flag = BindingFlags.Instance | BindingFlags.Public;
            Type EntityType = EntityObject.GetType();
            PropertyInfo field = EntityType.GetProperty(PropertyName, flag);
            Object ValueObject = field.GetValue(EntityObject, null);
            Object[] fieldType = field.GetCustomAttributes(typeof(PropertyType), true);
            if (fieldType.Length != 0)
            {
                PropertyType fieldP = fieldType[0] as PropertyType;
                switch (fieldP.entityPropertyType)
                {
                    case EntityPropertyType.DBFieldKey:
                        FieldType = EntityPropertyType.DBFieldKey;
                        break;

                    case EntityPropertyType.DBField:
                        FieldType = EntityPropertyType.DBField;
                        break;
                    //case EntityPropertyType.RelationshipField:
                    //    FieldType = EntityPropertyType.RelationshipField;
                    //    break;
                    case EntityPropertyType.DesignField:
                        FieldType = EntityPropertyType.DesignField;
                        break;
                    default:
                        FieldType = EntityPropertyType.DBField;
                        break;
                }
            }
            else
            {
                FieldType = EntityPropertyType.DBField;
            }

            if (ValueObject != null)
            {
                return ValueObject;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// 根据属性名称获取属性值
        /// </summary>
        /// <param name="tEntityObject">实体对象</param>
        /// <param name="PropertyName">属性名称</param>
        /// <returns></returns>
        public static Object GetPropertyValueByName(this TEntityBase tEntityObject, String PropertyName)
        {
            return tEntityObject.GetType().GetProperty(PropertyName).GetValue(tEntityObject, null);
        }
        /// <summary>
        /// 设置对象属性值
        /// </summary>
        /// <param name="tEntityObject"></param>
        /// <param name="PropertyName"></param>
        /// <param name="PropertyValue"></param>
        public static void SetPropertyValueByName(this TEntityBase tEntityObject, String PropertyName, Object PropertyValue)
        {
            tEntityObject.GetType().GetProperty(PropertyName).SetValue(tEntityObject, PropertyValue, null);
        }
        public static String GetEntityKeyFiledValue(this TEntityBase tEntityObject)
        {
            String ReturnString = "";
            Type EntityType = tEntityObject.GetType();
            PropertyInfo[] Properties = EntityType.GetProperties();
            for (int i = 0; i < Properties.Length; i++)
            {
                EntityPropertyType PType;
                Object ValueObject = GetEntityPropertyValue(tEntityObject, Properties[i].Name, out PType);

                if (PType == EntityPropertyType.DBFieldKey)
                {
                    ReturnString += Properties[i].Name + "='" + ValueObject + "'";
                    break;
                }
            }
            return ReturnString;
        }


        #endregion

        #region INSERT 语句构建
        /// <summary>
        /// 生成INSERT语句
        /// </summary>
        /// <param name="_EntityObject"></param>
        /// <returns></returns>
        public static string MakeInsertSQLString(TEntityBase _EntityObject)
        {
            string sResult = "INSERT INTO " + _EntityObject.TableName + " (";
            string Values = "";
            Type EntityType = _EntityObject.GetType();
            PropertyInfo[] Properties = EntityType.GetProperties();
            for (int i = 0; i < Properties.Length; i++)
            {
                EntityPropertyType PType;
                Object ValueObject = GetEntityPropertyValue(_EntityObject, Properties[i].Name, out PType);
                if (ValueObject == null)
                {
                    continue;
                }
                if ((PType == EntityPropertyType.DBFieldKey) || (PType == EntityPropertyType.DBField))
                {
                    sResult += Properties[i].Name + ",";
                    Values += "'" + ValueObject + "',";
                }
            }
            sResult = sResult.TrimEnd(',') + ") VALUES (" + Values.TrimEnd(',') + ")";
            return sResult;
        }
        #endregion

        #region 生成更新SQL语句
        public static String MakeUpdateString(TEntityBase _EntityObject)
        {
            String updateCoreString = String.Empty;
            String SQLUPDateWhere = " Where ";
            Type EntityType = _EntityObject.GetType();
            PropertyInfo[] Properties = EntityType.GetProperties();
            for (int i = 0; i < Properties.Length; i++)
            {
                EntityPropertyType PType;
                object Value = GetEntityPropertyValue(_EntityObject, Properties[i].Name, out PType);
                if (Value == null)
                {
                    continue;
                }
                if (PType == EntityPropertyType.DBFieldKey)
                {
                    SQLUPDateWhere += Properties[i].Name + "='" + Value + "'";
                }
                else if (PType == EntityPropertyType.DBField)
                {
                    updateCoreString += Properties[i].Name + "='" + Value + "',";
                }
            }
            updateCoreString = updateCoreString.TrimEnd(',') + SQLUPDateWhere;
            String ReturnString = "UPDATE " + _EntityObject.TableName + " Set " + updateCoreString;
            return ReturnString;
        }
        #endregion

        #region 生成删除语句
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="_EntityObject"></param>
        /// <param name="OperatorTableName"></param>
        /// <returns></returns>
        public static string MakeLogicDeleteString(TEntityBase _EntityObject, String UPU)
        {
            string sResult = "UPDATE " + _EntityObject.TableName + " SET F_IsDel =1, F_UpdateDate=GETDATE(),F_Updater='" + UPU + "' ";
            string sWhere = " WHERE ";
            sWhere += _EntityObject.GetEntityKeyFiledValue();
            String ResultStirng = sResult + sWhere;
            return ResultStirng;
        }

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="_EntityObject">传入实体对象</param>
        /// <param name="IsBatchDelete">是否批量删除 默认是单删除根据实体对象主键，反之采用实体对象属性条件删除</param>
        /// <returns></returns>
        public static string MakeDeleteString(TEntityBase _EntityObject, Boolean IsBatchDelete = false)
        {
            string sResult = "DELETE " + _EntityObject.TableName;
            string sWhere = " WHERE ";
            Type EntityType = _EntityObject.GetType();
            PropertyInfo[] Properties = EntityType.GetProperties();
            for (int i = 0; i < Properties.Length; i++)
            {
                EntityPropertyType PType;
                Object ValueObject = GetEntityPropertyValue(_EntityObject, Properties[i].Name, out PType);

                if (IsBatchDelete)
                {
                    //生成Delete From Where Filed ='' 型的批量删除SQL
                    if (ValueObject == null)
                    {
                        continue;
                    }
                    if (i == Properties.Length - 1)
                    {
                        if (PType == EntityPropertyType.DBFieldKey | PType == EntityPropertyType.DBField)
                        {
                            sWhere += Properties[i].Name + "='" + ValueObject + "'";
                        }
                    }
                    else
                    {
                        if (PType == EntityPropertyType.DBFieldKey | PType == EntityPropertyType.DBField)
                        {
                            sWhere += Properties[i].Name + "='" + ValueObject + "'" + " AND ";
                        }
                    }
                }
                else
                {
                    //生成根据主键删除的SQL
                    if (PType == EntityPropertyType.DBFieldKey)
                    {
                        sWhere += Properties[i].Name + "='" + ValueObject + "'";
                        break;
                    }
                }
            }
            String ResultStirng = sResult + sWhere;
            return ResultStirng;
        }


        #endregion

        #region 生成查询单条语句(主键)
        public static String MakeSelectSingleRowBySN(String TableName, String F_SN)
        {
            string sResult = "Select * From " + TableName;
            string sWhere = " WHERE F_SN ='" + F_SN + "'";
            String ResultStirng = sResult + sWhere;
            return ResultStirng;
        }
        #endregion

        #region 生成查询单条语句(条件)
        public static String MakeSelectRowsByEntityWhere(TEntityBase _EntityObject)
        {
            String SQLString = "Select * From" + _EntityObject.TableName;
            String SQLUPDateWhere = " Where ";
            List<String> WhereCon = new List<String>();
            Type EntityType = _EntityObject.GetType();
            PropertyInfo[] Properties = EntityType.GetProperties();
            for (int i = 0; i < Properties.Length; i++)
            {
                EntityPropertyType PType;
                object Value = GetEntityPropertyValue(_EntityObject, Properties[i].Name, out PType);
                if (Value == null)
                {
                    continue;
                }
                if (PType == EntityPropertyType.DBFieldKey)
                {
                    WhereCon.Add(Properties[i].Name + "='" + Value + "'");
                }
                else if (PType == EntityPropertyType.DBField)
                {
                    WhereCon.Add(Properties[i].Name + "='" + Value + "',");
                }
            };

            for (int i = 0; i < WhereCon.Count; i++)
            {
                SQLUPDateWhere += WhereCon[i] + " AND ";
            }
            SQLUPDateWhere = SQLUPDateWhere.Substring(0, SQLUPDateWhere.Length - 4);

            return SQLString + SQLUPDateWhere;
        }
        #endregion



    }
    #endregion

    #region EntityAttribute
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyType : Attribute
    {
        /// <summary>
        /// 实体属性类型
        /// </summary>
        public EntityPropertyType entityPropertyType
        {
            get;
            set;
        }

        public PropertyType(EntityPropertyType _PropertyType)
        {
            entityPropertyType = _PropertyType;
        }
    }

    /// <summary>
    /// 实体对象属性类型
    /// </summary>
    public enum EntityPropertyType
    {
        /// <summary>
        /// 数据库表字段属性主健（可用于增删改）
        /// </summary>
        DBFieldKey,

        /// <summary>
        /// 数据库表字段属性（可用于增删改）
        /// </summary>
        DBField,

        ///// <summary>
        ///// 数据库关联表字段属性（不可用于增删改)
        ///// </summary>
        //RelationshipField,
        /// <summary>
        /// 设计属性(不可用于增删改）
        /// </summary>
        DesignField
    }


    /// <summary>
    /// 实体对象类型
    /// </summary>
    public enum EntityModelType
    {
        /// <summary>
        /// 数据库单表模型(可用于增删改)
        /// </summary>
        DBModel,
        /// <summary>
        /// 数据库关联表模型(不可用于更新操作)
        /// </summary>
        RelationshipModel,
    }
    #endregion

    #region JSON<=>T
    public static class JsonHelper
    {
        /// <summary>
        /// JSON字符串=>对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="JsonString">Json 字符串</param>
        /// <returns>返回对象</returns>
        public static T FromJsonString<T>(this String JsonString)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JsonString);
        }

        /// <summary>
        /// 对象=>Json字符串
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static String ToJsonString(this Object Obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(Obj);
        }

    }
    #endregion

    #region String Helper
    public static class StringHelper
    {
        /// <summary>
        /// 生成随机字符串(没有 欧O)
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public static string CreateRandomCode(int codeCount)
        {
            String chars = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[codeCount];
            Random random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
    }

    #endregion

    #region Json Extend
    public class ZJsonObject : Dictionary<String, Object>
    {
        Dictionary<String, Object> TempJsonObject;

        public ZJsonObject(String JsonString)

        {
            this.Clear();
            TempJsonObject = JsonString.FromJsonString<Dictionary<String, Object>>();
            foreach (var item in TempJsonObject)
            {
                this.Add(item.Key,item.Value);
            }
           
        }


    }
    #endregion

}


