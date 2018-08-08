using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWMIS.DataMap.Entity;

namespace Movie.Model
{
    public class EntityBaseExtension : EntityBase
    {

        public bool UpdateBoolValue(string propertyName)
        {
            EntityBaseExtension t = this as EntityBaseExtension;
            if (t == null)
            {
                throw new Exception("必须是 EntityBaseExtension 类的子类的实例才可以调用 UpdateBoolValue 方法");
            }
            bool Value = base.getProperty<bool>(propertyName);
            base.setProperty(propertyName, !Value);


            return EntityQuery<EntityBaseExtension>.Instance.Update(t) > 0; ;
        }

        //根据属性名 统计
        public bool UpdateIntValue(string propertyName)
        {
            EntityBaseExtension t = this as EntityBaseExtension;
            if (t == null)
            {
                throw new Exception("必须是 EntityBaseExtension 类的子类的实例才可以调用 UpdateIntValue 方法");
            }
            int Value = base.getProperty<int>(propertyName);
            base.setProperty(propertyName, Value + 1);


            return EntityQuery<EntityBaseExtension>.Instance.Update(t) > 0; ;
        }

        public bool UpdateIntValue(string propertyName, int val)
        {
            EntityBaseExtension t = this as EntityBaseExtension;
            if (t == null)
            {
                throw new Exception("必须是 EntityBaseExtension 类的子类的实例才可以调用 UpdateIntValue 方法");
            }
            //int Value = base.getProperty<int>(propertyName);
            base.setProperty(propertyName, val);


            return EntityQuery<EntityBaseExtension>.Instance.Update(t) > 0; ;
        }

        public string GetDBFieldStr(string prop)
        {
            EntityFields ef = EntityFieldsCache.Item(this.GetType());
            string fieldName = ef.GetPropertyField(prop);
            return fieldName;
        }

    }
}
