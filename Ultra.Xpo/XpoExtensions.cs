using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.Generators;
using DevExpress.Xpo.Metadata;
using System;
using System.ComponentModel;
using System.Linq;
using Ultra.Xpo;


public static class XpoExtensions
{
    public static XPView CreateViewWithProperties(this Type ClassType, Session session, CriteriaOperator criteria)
    {
        XPClassInfo classInfo = session.GetClassInfo(ClassType);
        return classInfo.CreateViewWithProperties(session, criteria);
    }
    public static XPView CreateViewWithProperties(this XPClassInfo classInfo, Session session, CriteriaOperator criteria = null)
    {
        return CreateViewWithProperties(classInfo, session, classInfo.Members.Select(x => x.Name).ToList(), criteria);
    }
    public static XPView CreateViewWithProperties(this XPClassInfo classInfo, Session session, List<string> Properties, CriteriaOperator criteria = null)
    {
        var view = new XPView(session, classInfo.ClassType);
        view.Criteria = criteria;

        foreach (XPMemberInfo memberInfo in classInfo.Members)
        {
            if (!memberInfo.IsPersistent || memberInfo.IsCollection)
                continue;

            if (memberInfo.ReferenceType != null)
            {
                // Get key property of the associated object
                XPClassInfo nestedClassInfo = memberInfo.ReferenceType;//session.GetClassInfo(memberInfo.ReferenceType);
                XPMemberInfo keyProperty = nestedClassInfo.KeyProperty;

                // Attempt to find a property marked with DefaultPropertyAttribute
                var defaultPropertyAttribute = nestedClassInfo.FindAttributeInfo(typeof(DefaultPropertyAttribute)) as DefaultPropertyAttribute;

                string defaultPropertyName = defaultPropertyAttribute != null ? defaultPropertyAttribute.Name : keyProperty.Name;

                // Add key property of the associated object to the view
                view.Properties.Add(new ViewProperty(memberInfo.Name + "." + keyProperty.Name, SortDirection.None, memberInfo.Name + "." + keyProperty.Name, false, true));

                // If the default property is different from the key, add it as well
                if (defaultPropertyAttribute != null && defaultPropertyName != keyProperty.Name)
                {
                    view.Properties.Add(new ViewProperty(memberInfo.Name + "." + defaultPropertyName, SortDirection.None, memberInfo.Name + "." + defaultPropertyName, false, true));
                }
            }
            else
            {
                // Add the simple property to the view
                view.Properties.Add(new ViewProperty(memberInfo.Name, SortDirection.None, memberInfo.Name, false, true));
            }
        }

        return view;
    }
    //public static UltraXPView CreateUltraViewWithProperties(this XPClassInfo classInfo, Session session, List<string> Properties, CriteriaOperator criteria = null)
    //{
    //    var view = new UltraXPView(session, classInfo.ClassType);
    //    view.Criteria = criteria;

    //    foreach (XPMemberInfo memberInfo in classInfo.Members)
    //    {
    //        if (!memberInfo.IsPersistent || memberInfo.IsCollection)
    //            continue;

    //        if (memberInfo.ReferenceType != null)
    //        {
    //            // Get key property of the associated object
    //            XPClassInfo nestedClassInfo = memberInfo.ReferenceType;//session.GetClassInfo(memberInfo.ReferenceType);
    //            XPMemberInfo keyProperty = nestedClassInfo.KeyProperty;

    //            // Attempt to find a property marked with DefaultPropertyAttribute
    //            var defaultPropertyAttribute = nestedClassInfo.FindAttributeInfo(typeof(DefaultPropertyAttribute)) as DefaultPropertyAttribute;

    //            string defaultPropertyName = defaultPropertyAttribute != null ? defaultPropertyAttribute.Name : keyProperty.Name;

    //            // Add key property of the associated object to the view
    //            view.Properties.Add(new UltraViewProperty(memberInfo.Name + "." + keyProperty.Name, SortDirection.None, memberInfo.Name + "." + keyProperty.Name, false, true));

    //            // If the default property is different from the key, add it as well
    //            if (defaultPropertyAttribute != null && defaultPropertyName != keyProperty.Name)
    //            {
    //                view.Properties.Add(new ViewProperty(memberInfo.Name + "." + defaultPropertyName, SortDirection.None, memberInfo.Name + "." + defaultPropertyName, false, true));
    //            }
    //        }
    //        else
    //        {
    //            // Add the simple property to the view
    //            view.Properties.Add(new ViewProperty(memberInfo.Name, SortDirection.None, memberInfo.Name, false, true));
    //        }
    //    }

    //    return view;
    //}

}
