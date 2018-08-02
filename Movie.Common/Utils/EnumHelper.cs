/** 1. ���ܣ�ö�ٲ���������
 *  2. ���ߣ���ƽ 
 *  3. �������ڣ�2008-9-27
 *  4. ����޸����ڣ�2008-9-27
**/
#region ���������ռ�
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.Concurrent;
#endregion

namespace Movie.Common.Utils
{
    /// <summary>
    /// ö�ٲ���������
    /// </summary>
    public static class EnumHelper
    {
        #region ͨ���ַ�����ȡö�ٳ�Աʵ��
        /// <summary>
        /// ͨ���ַ�����ȡö�ٳ�Աʵ��
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">ö�ٳ�Ա�ĳ���������ֵ,
        /// ����:Enum1ö����������ԱA=0,B=1,����"A"��"0"��ȡ Enum1.A ö������</param>
        public static T GetInstance<T>( string member )
        {
            return ConvertHelper.ConvertTo<T>( Enum.Parse( typeof( T ), member, true ) );
        }
        #endregion

        #region ��ȡö�ٳ�Ա���ƺͳ�Աֵ�ļ�ֵ�Լ���
        /// <summary>
        /// ��ȡö�ٳ�Ա���ƺͳ�Աֵ�ļ�ֵ�Լ���
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        public static Hashtable GetMemberKeyValue<T>()
        {
            //������ϣ��
            Hashtable ht = new Hashtable();

            //��ȡö�����г�Ա����
            string[] memberNames = GetMemberNames<T>();

            //����ö�ٳ�Ա
            foreach ( string memberName in memberNames )
            {
                ht.Add( memberName, GetMemberValue<T>( memberName ) );
            }

            //���ع�ϣ��
            return ht;
        }
        #endregion

        #region ��ȡö�����г�Ա����
        /// <summary>
        /// ��ȡö�����г�Ա����
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        public static string[] GetMemberNames<T>()
        {
            return Enum.GetNames( typeof( T ) );
        }
        #endregion

        #region ��ȡö�ٳ�Ա������
        /// <summary>
        /// ��ȡö�ٳ�Ա������
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">ö�ٳ�Աʵ�����Աֵ,
        /// ����:Enum1ö����������ԱA=0,B=1,����Enum1.A��0,��ȡ��Ա����"A"</param>
        public static string GetMemberName<T>( object member )
        {
            //ת�ɻ������͵ĳ�Աֵ
            Type underlyingType = GetUnderlyingType( typeof(T) );
            object memberValue = ConvertHelper.ConvertTo( member, underlyingType );

            //��ȡö�ٳ�Ա������
            return Enum.GetName( typeof( T ), memberValue );
        }
        #endregion

        #region ��ȡö�����г�Աֵ
        /// <summary>
        /// ��ȡö�����г�Աֵ
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        public static Array GetMemberValues<T>()
        {
            return Enum.GetValues( typeof( T ) );
        }
        #endregion

        #region ��ȡö�ٳ�Ա��ֵ
        /// <summary>
        /// ��ȡö�ٳ�Ա��ֵ
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="memberName">ö�ٳ�Ա�ĳ�����,
        /// ����:Enum1ö����������ԱA=0,B=1,����"A"��ȡ0</param>
        public static object GetMemberValue<T>( string memberName )
        {
            //��ȡ��������
            Type underlyingType = GetUnderlyingType( typeof( T ) );

            //��ȡö��ʵ��
            T instance = GetInstance<T>( memberName );

            //��ȡö�ٳ�Ա��ֵ
            return ConvertHelper.ConvertTo( instance, underlyingType );
        }
        #endregion

        #region ��ȡö�ٵĻ�������
        /// <summary>
        /// ��ȡö�ٵĻ�������
        /// </summary>
        /// <param name="enumType">ö������</param>
        public static Type GetUnderlyingType( Type enumType )
        {
            //��ȡ��������
            return Enum.GetUnderlyingType( enumType );
        }
        #endregion

        #region ���ö���Ƿ����ָ����Ա
        /// <summary>
        /// ���ö���Ƿ����ָ����Ա
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">ö�ٳ�Ա�����Աֵ</param>
        public static bool IsDefined<T>( string member )
        {
            return Enum.IsDefined( typeof( T ), member );
        }
        #endregion

        #region Field

        private static ConcurrentDictionary<Type, Dictionary<int, string>> enumDisplayValueDict = new ConcurrentDictionary<Type, Dictionary<int, string>>();
        private static ConcurrentDictionary<Type, Dictionary<string, int>> enumValueDisplayDict = new ConcurrentDictionary<Type, Dictionary<string, int>>();
        private static ConcurrentDictionary<Type, Dictionary<int, string>> enumNameValueDict = new ConcurrentDictionary<Type, Dictionary<int, string>>();
        private static ConcurrentDictionary<Type, Dictionary<string, int>> enumValueNameDict = new ConcurrentDictionary<Type, Dictionary<string, int>>();

        private static ConcurrentDictionary<Type, Dictionary<int, Tuple<string, int>>> enumSeqDisplayValueDict = new ConcurrentDictionary<Type, Dictionary<int, Tuple<string, int>>>();
        private static ConcurrentDictionary<string, Type> enumTypeDict = null;

        #endregion

        #region Method
        /// <summary>
        /// ��ȡö�ٶ���Key����ʾ���Ƶ��ֵ�
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumDictionary(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("���������Ͳ���ö������");

            Dictionary<int, string> names = enumNameValueDict.ContainsKey(enumType) ? enumNameValueDict[enumType] : new Dictionary<int, string>();

            if (names.Count == 0)
            {
                names = GetEnumDictionaryItems(enumType);
                enumNameValueDict[enumType] = names;
            }
            return names;
        }

        private static Dictionary<int, string> GetEnumDictionaryItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<int, string> names = new Dictionary<int, string>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);
                names[intValue] = enumItem.Name;
            }
            return names;
        }

        /// <summary>
        /// ��ȡö�ٶ�����ʾ������Key���ֵ�
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetEnumValueNameItems(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new Exception("���������Ͳ���ö������");

            Dictionary<string, int> values = enumValueNameDict.ContainsKey(enumType) ? enumValueNameDict[enumType] : new Dictionary<string, int>();

            if (values.Count == 0)
            {
                values = TryToGetEnumValueNameItems(enumType);
                enumValueNameDict[enumType] = values;
            }
            return values;
        }

        private static Dictionary<string, int> TryToGetEnumValueNameItems(Type enumType)
        {
            FieldInfo[] enumItems = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            Dictionary<string, int> values = new Dictionary<string, int>(enumItems.Length);

            foreach (FieldInfo enumItem in enumItems)
            {
                int intValue = (int)enumItem.GetValue(enumType);
                values[enumItem.Name] = intValue;
            }
            return values;
        }






        #endregion
        /// <summary>
        /// ö����ʾ��(������չ)
        /// </summary>
        public class EnumDisplayNameAttribute : Attribute
        {
            private string _displayName;

            public EnumDisplayNameAttribute(string displayName)
            {
                this._displayName = displayName;
            }

            public string DisplayName
            {
                get { return _displayName; }
            }
        }

        public class EnumExt
        {
            /// <summary>
            /// ����ö�ٳ�Ա��ȡ�Զ�������EnumDisplayNameAttribute������DisplayName
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public static string GetEnumDisplayName(object o)
            {
                //��ȡö�ٵ�Type���Ͷ���
                Type t = o.GetType();

                //��ȡö�ٵ������ֶ�
                FieldInfo[] ms = t.GetFields();

                //��������ö�ٵ������ֶ�
                foreach (FieldInfo f in ms)
                {
                    if (f.Name != o.ToString())
                    {
                        continue;
                    }

                    //�ڶ�������true��ʾ����EnumDisplayNameAttribute�ļ̳���
                    if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                    {
                        return
                            (f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute)
                                .DisplayName;
                    }
                }

                //���û���ҵ��Զ������ԣ�ֱ�ӷ��������������
                return o.ToString();
            }

            /// <summary>
            /// ����ö��ת����SelectList
            /// </summary>
            /// <param name="enumType">ö��</param>
            /// <returns></returns>
            public static List<SelectListItem> GetSelectList(Type enumType)
            {
                List<SelectListItem> selectList = new List<SelectListItem>();
                foreach (object e in Enum.GetValues(enumType))
                {
                    selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString() });
                }
                return selectList;
            }
        }

        /// <summary>
        /// ����ö��ת����SelectList��������Ĭ��ѡ����
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="ObjDefaultValue">Ĭ��ѡ����</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType, object ObjDefaultValue)
        {
            int defaultValue = Int32.Parse(ObjDefaultValue.ToString());
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                try
                {
                    if ((int)e == defaultValue)
                    {
                        selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString(), Selected = true });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString() });
                    }
                }
                catch (Exception ex)
                {
                    string exs = ex.Message;
                }
            }
            return selectList;
        }

        /// <summary>
        /// ����ö��ת����SelectList
        /// </summary>
        /// <param name="enumType">ö��</param>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectList(Type enumType)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (object e in Enum.GetValues(enumType))
            {
                selectList.Add(new SelectListItem() { Text = GetDescription(e), Value = ((int)e).ToString() });
            }
            return selectList;
        }
        /// <summary>
        /// ����ö�ٳ�Ա��ȡ�Զ�������EnumDisplayNameAttribute������DisplayName
        /// </summary>
        /// <param name="objEnumType"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetDescriptionAndValue(Type enumType)
        {
            Dictionary<string, int> dicResult = new Dictionary<string, int>();

            foreach (object e in Enum.GetValues(enumType))
            {
                dicResult.Add(GetDescription(e), (int)e);
            }

            return dicResult;
        }

        /// <summary>
        /// ����ö�ٳ�Ա��ȡDescriptionAttribute������Description
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetDescription(object o)
        {
            //��ȡö�ٵ�Type���Ͷ���
            Type t = o.GetType();

            //��ȡö�ٵ������ֶ�
            FieldInfo[] ms = t.GetFields();

            //��������ö�ٵ������ֶ�
            foreach (FieldInfo f in ms)
            {
                if (f.Name != o.ToString())
                {
                    continue;
                }
                ////  Description
                //  //�ڶ�������true��ʾ����EnumDisplayNameAttribute�ļ̳���
                //  if (f.IsDefined(typeof(EnumDisplayNameAttribute), true))
                //  {
                //      return
                //        (f.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true)[0] as EnumDisplayNameAttribute)
                //          .DisplayName;
                //  } 
                FieldInfo fi = o.GetType().GetField(o.ToString());
                try
                {
                    var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return (attributes != null && attributes.Length > 0) ? attributes[0].Description : o.ToString();
                }
                catch
                {
                    return "(Unknow)";
                }
            }

            //���û���ҵ��Զ������ԣ�ֱ�ӷ��������������
            return o.ToString();
        }

        #region ������չ����

        /// <summary>  
        /// ��չ����������ö��ֵ�õ���Ӧ��ö�ٶ����ַ���  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static String ToEnumString(this int value, Type enumType)
        {
            NameValueCollection nvc = GetEnumStringFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary>  
        /// ����ö�����͵õ������е� ֵ �� ö�ٶ����ַ��� �ļ���  
        /// </summary>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static NameValueCollection GetEnumStringFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    nvc.Add(strValue, field.Name);
                }
            }
            return nvc;
        }

        /// <summary>  
        /// ��չ����������ö��ֵ�õ�����Description�е�����, ���û�ж���������򷵻ؿմ�  
        /// </summary>  
        /// <param name="value"></param>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static String ToEnumDescriptionString(this int value, Type enumType)
        {
            NameValueCollection nvc = GetNVCFromEnumValue(enumType);
            return nvc[value.ToString()];
        }

        /// <summary>  
        /// ����ö�����͵õ������е� ֵ �� ö�ٶ���Description���� �ļ���  
        /// </summary>  
        /// <param name="enumType"></param>  
        /// <returns></returns>  
        public static NameValueCollection GetNVCFromEnumValue(Type enumType)
        {
            NameValueCollection nvc = new NameValueCollection();
            Type typeDescription = typeof(DescriptionAttribute);
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    strValue = ((int)enumType.InvokeMember(field.Name, BindingFlags.GetField, null, null, null)).ToString();
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        strText = aa.Description;
                    }
                    else
                    {
                        strText = "";
                    }
                    nvc.Add(strValue, strText);
                }
            }
            return nvc;
        }

        #endregion
    }
}
