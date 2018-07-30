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
#endregion

namespace Movie.Common.Utils
{
    /// <summary>
    /// ö�ٲ���������
    /// </summary>
    public class EnumHelper
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
    }
}
