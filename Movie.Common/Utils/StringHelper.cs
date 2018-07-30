/** 1. ���ܣ������ַ�������Ĺ���������
 *  2. ���ߣ���ƽ 
 *  3. �������ڣ�2008-9-8
 *  4. ����޸����ڣ�2008-9-12
**/
#region �����ռ�����
using System;
using System.Data;
using System.Configuration;
using System.Text;
#endregion

namespace Movie.Common.Utils
{
    /// <summary>
    /// �����ַ�������Ĺ���������
    /// </summary>
    public sealed class StringHelper
    {
        #region �Խű��е���Ϣ���й��˴���
        /// <summary>
        /// �Խű��е���Ϣ���й��˴���
        /// </summary>
        /// <param name="msg">�ű��е���Ϣ�ַ���,���������ű�����.
        /// ������alert('ab\n\rc'),ֻ����ab\n\rc,��Ҫ��alert('')��������</param>
        public static string GetValidScriptMsg( string msg )
        {
            StringBuilder validMsg = new StringBuilder( msg );
            validMsg.Replace( "\\", @"\\" );
            validMsg.Replace( "\n", "\\n" );
            validMsg.Replace( "\t", "\\t" );
            validMsg.Replace( "\r", "\\r" );
            validMsg.Replace( "'", "\\'" );

            //������Ч���ַ���
            return validMsg.ToString();
        }
        #endregion

        #region ȥ���ַ������Ķ���
        /// <summary>
        /// ȥ���ַ������Ķ���,�����µ��ַ���
        /// </summary>
        /// <param name="text">ԭʼ�ַ���</param>
        public static string RemoveLastComma( ref string text )
        {
            //����ַ�������Ƿ���ڶ���
            if ( text.EndsWith( "," ) )
            {
                //ȥ������
                text = text.Remove( text.Length - 1, 1 );                
            }

            //�����µ��ַ���
            return text;
        }

        /// <summary>
        /// ȥ���ַ������Ķ���,�����µ��ַ���
        /// </summary>
        /// <param name="text">ԭʼ�ַ���</param>
        public static string RemoveLastComma( StringBuilder text )
        {
            //��ȡstring����
            string temp = text.ToString();

            //����ַ�������Ƿ���ڶ���
            if ( temp.EndsWith( "," ) )
            {
                //ȥ������
                text.Remove( text.Length - 1, 1 );
            }

            //�����µ��ַ���
            return text.ToString();
        }
        #endregion

        #region ����ַ���
        /// <summary>
        /// ����ַ���
        /// </summary>
        /// <param name="text">ԭʼ�ַ���</param>
        public static void Clear( StringBuilder text )
        {
            text.Remove( 0, text.Length );
        }
        #endregion

        #region ��ȡ�ַ��������һ���ַ�
        /// <summary>
        /// ��ȡ�ַ��������һ���ַ�
        /// </summary>
        /// <param name="text">ԭʼ�ַ���</param>        
        public static string GetLastChar( string text )
        {
            //����ַ���Ϊ�գ��򷵻�
            if ( ValidationHelper.IsNullOrEmpty( text ) )
            {
                return "";
            }

            return text.Substring( text.Length - 1, 1 );
        }
        #endregion

        #region �ö���ƴ������

        #region ���ط���1
        /// <summary>
        /// ��ȡ�ö���ƴ������Ԫ�ص��ַ����������ַ���������Ԫ��Ĭ�ϲ������ţ������Ҫ������ʹ�����ط�����
        /// ����: ����Ϊ:string[] a = new string[] { "1","2","3" };����ֵ:1,2,3
        /// </summary>
        /// <param name="stringArray">ԭʼ�ַ�������</param>
        public static string GetCommaString( params string[] stringArray )
        {
            return GetCommaString( false, stringArray );
        } 
        #endregion

        #region ���ط���2
        /// <summary>
        /// ��ȡ�ö���ƴ������Ԫ�ص��ַ�����
        /// ����: ����Ϊ:string[] a = new string[] { "1","2","3" };����ֵ:1,2,3
        /// </summary>
        /// <param name="isAddQuotationMarks">�Ƿ���ӵ�����,�������true���򷵻�ֵΪ'1','2','3'</param>
        /// <param name="stringArray">ԭʼ�ַ�������</param>
        public static string GetCommaString( bool isAddQuotationMarks, params string[] stringArray )
        {
            //��ʱ�ַ���
            StringBuilder list = new StringBuilder();

            //ѭ���ַ������飬��ӵ���ʱ�ַ�����
            foreach ( string text in stringArray )
            {
                if ( isAddQuotationMarks )
                {
                    list.AppendFormat( "'{0}',", text );
                }
                else
                {
                    list.AppendFormat( "{0},", text );
                }
            }

            //�����ַ���
            return RemoveLastComma( list );
        } 
        #endregion

        #region ���ط���3
        /// <summary>
        /// ��ȡ�ö���ƴ������Ԫ�ص��ַ����������ַ���������Ԫ��Ĭ�ϲ������ţ������Ҫ������ʹ�����ط�����
        /// ����: ����Ϊ:int[] a = new int[] { 1,2,3 };����ֵ:1,2,3
        /// </summary>
        /// <param name="intArray">ԭʼ��������</param>
        public static string GetCommaString( params int[] intArray )
        {
            return GetCommaString( false, intArray );
        }
        #endregion

        #region ���ط���4
        /// <summary>
        /// ��ȡ�ö���ƴ������Ԫ�ص��ַ�����
        /// ����: ����Ϊ:int[] a = new int[] { 1,2,3 };����ֵ:1,2,3
        /// </summary>
        /// <param name="isAddQuotationMarks">�Ƿ���ӵ�����,�������true���򷵻�ֵΪ'1','2','3'</param>
        /// <param name="intArray">ԭʼ��������</param>
        public static string GetCommaString( bool isAddQuotationMarks, params int[] intArray )
        {
            //��ʱ�ַ���
            StringBuilder list = new StringBuilder();

            //ѭ���ַ������飬��ӵ���ʱ�ַ�����
            foreach ( int text in intArray )
            {
                if ( isAddQuotationMarks )
                {
                    list.AppendFormat( "'{0}',", text );
                }
                else
                {
                    list.AppendFormat( "{0},", text );
                }
            }

            //�����ַ���
            return RemoveLastComma( list );
        }
        #endregion

        #endregion

        #region ��ȡʱ�����������ַ���
        /// <summary>
        /// ��ȡʱ�����������ַ���
        /// </summary>
        public static string DateTimeRandomString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                //��ӵ�ǰʱ��
                sb.AppendFormat( "{0}", DateTime.Now.ToString().Replace( " ", "_" ).Replace( ":", "_" ) );
                //��������
                sb.AppendFormat( "{0}", new RandomHelper().GetRandomInt( 1, 9999999 ) );
                
                //�����ַ���
                return sb.ToString();
            }
        }
        #endregion

        #region �������һ��ID
        /// <summary>
        /// �������һ��ID
        /// </summary>
        /// <remarks>
        /// ���ɹ��򣺹�10λ��
        /// 1. ȡ��������һλ��
        /// 2. ȡ��λ�����룬������λ���㡣
        /// 3. ȡ��λ���ķ֣�������λ���㡣
        /// 4. ȡСʱ�����һλ��
        /// 5. ȡ�������ڵ����һλ��
        /// 6. ȡ���µ����һλ��
        /// 7. ȡ1����99֮�����λ�������������λ���㡣
        /// </remarks>
        public static string GenerateID()
        {
            //ȡ��������һλ
            string ms = StringHelper.GetLastChar( DateTime.Now.Millisecond.ToString() );

            //ȡ��λ�����룬������λ����
            string ss = ConvertHelper.RepairZero( DateTime.Now.Second.ToString(), 2 );

            //ȡ��λ���ķ֣�������λ���㡣
            string mm = ConvertHelper.RepairZero( DateTime.Now.Minute.ToString(), 2 );

            //ȡСʱ�����һλ
            string h = StringHelper.GetLastChar( DateTime.Now.Hour.ToString() );

            //ȡ�������ڵ����һλ
            string d = StringHelper.GetLastChar( DateTime.Now.Date.ToString() );

            //ȡ���µ����һλ
            string m = StringHelper.GetLastChar( DateTime.Now.Month.ToString() );

            //ȡ1����99֮�����λ�����
            RandomHelper random = new RandomHelper();
            string randomNumber = random.GetRandomInt( 1, 99 ).ToString();
            //������λ
            randomNumber = ConvertHelper.RepairZero( randomNumber, 2 );

            //�������ID
            return ms + ss + mm + h + d + m + randomNumber;
        }
        #endregion
    }
}
